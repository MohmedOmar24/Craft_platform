import { type FormEvent, useEffect, useState } from 'react'
import { listCategories } from '../api/categories'
import { listInventories } from '../api/inventories'
import {
  createProduct,
  deleteProduct,
  listProducts,
  updateProduct,
  updateProductCategory,
} from '../api/products'
import { ApiError } from '../api/client'
import type { Category, Inventory, Product } from '../api/types'
import { Modal, ModalForm } from '../components/Modal'
import { Banner, EmptyState, PageHeader } from '../components/PageHeader'
import { money, shortId } from '../lib/format'

type CreateForm = {
  categoryId: string
  inventoryId: string
  name: string
  description: string
  unitPrice: number
  width: number
  weight: number
  length: number
  height: number
  taxCost: number
  profitPerUnit: number
  productionCost: number
}

const emptyCreate: CreateForm = {
  categoryId: '',
  inventoryId: '',
  name: '',
  description: '',
  unitPrice: 0,
  width: 0,
  weight: 0,
  length: 0,
  height: 0,
  taxCost: 0,
  profitPerUnit: 0,
  productionCost: 0,
}

export function ProductsPage() {
  const [items, setItems] = useState<Product[]>([])
  const [categories, setCategories] = useState<Category[]>([])
  const [inventories, setInventories] = useState<Inventory[]>([])
  const [error, setError] = useState<string | null>(null)
  const [busy, setBusy] = useState(false)
  const [creating, setCreating] = useState(false)
  const [createForm, setCreateForm] = useState<CreateForm>(emptyCreate)
  const [editing, setEditing] = useState<Product | null>(null)
  const [editForm, setEditForm] = useState({ name: '', description: '', categoryId: '' })

  async function refresh() {
    try {
      const [products, cats, locs] = await Promise.all([
        listProducts(),
        listCategories(),
        listInventories(),
      ])
      setItems(products)
      setCategories(cats)
      setInventories(locs)
      setError(null)
    } catch (err) {
      setError(err instanceof ApiError ? err.message : 'Could not load products.')
    }
  }

  useEffect(() => {
    void refresh()
  }, [])

  function categoryName(id: string) {
    return categories.find((item) => item.categoryId === id)?.name ?? shortId(id)
  }

  function locationName(id: string) {
    return inventories.find((item) => item.inventoryId === id)?.location ?? shortId(id)
  }

  function openCreate() {
    setCreateForm({
      ...emptyCreate,
      categoryId: categories[0]?.categoryId ?? '',
      inventoryId: inventories[0]?.inventoryId ?? '',
    })
    setCreating(true)
  }

  async function onCreate(event: FormEvent) {
    event.preventDefault()
    setBusy(true)
    try {
      await createProduct(createForm)
      setCreating(false)
      await refresh()
    } catch (err) {
      setError(err instanceof ApiError ? err.message : 'Create failed.')
    } finally {
      setBusy(false)
    }
  }

  async function onUpdate(event: FormEvent) {
    event.preventDefault()
    if (!editing) return
    setBusy(true)
    try {
      await updateProduct(editing.productId, {
        name: editForm.name,
        description: editForm.description,
      })
      if (editForm.categoryId && editForm.categoryId !== editing.categoryId) {
        await updateProductCategory(editing.productId, editForm.categoryId)
      }
      setEditing(null)
      await refresh()
    } catch (err) {
      setError(err instanceof ApiError ? err.message : 'Update failed.')
    } finally {
      setBusy(false)
    }
  }

  async function onDelete(item: Product) {
    if (!confirm(`Delete product “${item.name}”?`)) return
    try {
      await deleteProduct(item.productId)
      await refresh()
    } catch (err) {
      setError(err instanceof ApiError ? err.message : 'Delete failed.')
    }
  }

  return (
    <>
      <PageHeader
        title="Products"
        subtitle="A product needs a category and a stock location."
        action={
          <button type="button" onClick={openCreate} disabled={!categories.length || !inventories.length}>
            New product
          </button>
        }
      />
      <Banner
        message={
          !categories.length || !inventories.length
            ? 'Create at least one category and one stock location before adding products.'
            : null
        }
        kind="info"
      />
      <Banner message={error} />
      {items.length === 0 ? (
        <EmptyState title="No products yet" text="Add a finished good or material once categories and locations exist." />
      ) : (
        <table>
          <thead>
            <tr>
              <th>Name</th>
              <th>Category</th>
              <th>Location</th>
              <th>Price</th>
              <th />
            </tr>
          </thead>
          <tbody>
            {items.map((item) => (
              <tr key={item.productId}>
                <td>
                  <div>{item.name}</div>
                  <small className="muted">{item.description}</small>
                </td>
                <td>{categoryName(item.categoryId)}</td>
                <td>{locationName(item.inventoryId)}</td>
                <td>{money(item.unitPrice)}</td>
                <td className="row-actions">
                  <button
                    type="button"
                    className="ghost"
                    onClick={() => {
                      setEditForm({
                        name: item.name,
                        description: item.description,
                        categoryId: item.categoryId,
                      })
                      setEditing(item)
                    }}
                  >
                    Edit
                  </button>
                  <button type="button" className="danger" onClick={() => onDelete(item)}>
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}

      <Modal title="New product" open={creating} onClose={() => setCreating(false)}>
        <ModalForm onSubmit={onCreate} submitLabel="Create" busy={busy}>
          <label>
            Name
            <input
              required
              value={createForm.name}
              onChange={(event) => setCreateForm({ ...createForm, name: event.target.value })}
            />
          </label>
          <label>
            Description
            <textarea
              required
              value={createForm.description}
              onChange={(event) => setCreateForm({ ...createForm, description: event.target.value })}
            />
          </label>
          <label>
            Category
            <select
              required
              value={createForm.categoryId}
              onChange={(event) => setCreateForm({ ...createForm, categoryId: event.target.value })}
            >
              {categories.map((item) => (
                <option key={item.categoryId} value={item.categoryId}>
                  {item.name}
                </option>
              ))}
            </select>
          </label>
          <label>
            Stock location
            <select
              required
              value={createForm.inventoryId}
              onChange={(event) => setCreateForm({ ...createForm, inventoryId: event.target.value })}
            >
              {inventories.map((item) => (
                <option key={item.inventoryId} value={item.inventoryId}>
                  {item.location}
                </option>
              ))}
            </select>
          </label>
          <div className="grid-2">
            <NumberField
              label="Unit price"
              value={createForm.unitPrice}
              onChange={(unitPrice) => setCreateForm({ ...createForm, unitPrice })}
            />
            <NumberField
              label="Production cost"
              value={createForm.productionCost}
              onChange={(productionCost) => setCreateForm({ ...createForm, productionCost })}
            />
            <NumberField
              label="Tax cost"
              value={createForm.taxCost}
              onChange={(taxCost) => setCreateForm({ ...createForm, taxCost })}
            />
            <NumberField
              label="Profit per unit"
              value={createForm.profitPerUnit}
              onChange={(profitPerUnit) => setCreateForm({ ...createForm, profitPerUnit })}
            />
            <NumberField
              label="Weight"
              value={createForm.weight}
              onChange={(weight) => setCreateForm({ ...createForm, weight })}
            />
            <NumberField
              label="Length"
              value={createForm.length}
              onChange={(length) => setCreateForm({ ...createForm, length })}
            />
            <NumberField
              label="Width"
              value={createForm.width}
              onChange={(width) => setCreateForm({ ...createForm, width })}
            />
            <NumberField
              label="Height"
              value={createForm.height}
              onChange={(height) => setCreateForm({ ...createForm, height })}
            />
          </div>
        </ModalForm>
      </Modal>

      <Modal title="Edit product" open={Boolean(editing)} onClose={() => setEditing(null)}>
        <p className="muted">The API currently updates name, description, and category on this screen.</p>
        <ModalForm onSubmit={onUpdate} submitLabel="Update" busy={busy}>
          <label>
            Name
            <input
              required
              value={editForm.name}
              onChange={(event) => setEditForm({ ...editForm, name: event.target.value })}
            />
          </label>
          <label>
            Description
            <textarea
              required
              value={editForm.description}
              onChange={(event) => setEditForm({ ...editForm, description: event.target.value })}
            />
          </label>
          <label>
            Category
            <select
              required
              value={editForm.categoryId}
              onChange={(event) => setEditForm({ ...editForm, categoryId: event.target.value })}
            >
              {categories.map((item) => (
                <option key={item.categoryId} value={item.categoryId}>
                  {item.name}
                </option>
              ))}
            </select>
          </label>
        </ModalForm>
      </Modal>
    </>
  )
}

function NumberField({
  label,
  value,
  onChange,
}: {
  label: string
  value: number
  onChange: (value: number) => void
}) {
  return (
    <label>
      {label}
      <input
        type="number"
        step="any"
        min={0}
        value={value}
        onChange={(event) => onChange(Number(event.target.value))}
      />
    </label>
  )
}
