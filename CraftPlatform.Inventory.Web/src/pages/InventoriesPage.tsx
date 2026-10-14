import { type FormEvent, useEffect, useState } from 'react'
import {
  createInventory,
  deleteInventory,
  listInventories,
  updateInventory,
} from '../api/inventories'
import { ApiError } from '../api/client'
import type { Inventory } from '../api/types'
import { Modal, ModalForm } from '../components/Modal'
import { Banner, EmptyState, PageHeader } from '../components/PageHeader'

type FormState = { quantity: number; reorderLevel: number; location: string }

const emptyForm: FormState = { quantity: 0, reorderLevel: 0, location: '' }

export function InventoriesPage() {
  const [items, setItems] = useState<Inventory[]>([])
  const [error, setError] = useState<string | null>(null)
  const [busy, setBusy] = useState(false)
  const [form, setForm] = useState<FormState>(emptyForm)
  const [editing, setEditing] = useState<Inventory | null>(null)
  const [creating, setCreating] = useState(false)

  async function refresh() {
    try {
      setItems(await listInventories())
      setError(null)
    } catch (err) {
      setError(err instanceof ApiError ? err.message : 'Could not load stock locations.')
    }
  }

  useEffect(() => {
    void refresh()
  }, [])

  function openCreate() {
    setForm(emptyForm)
    setCreating(true)
  }

  function openEdit(item: Inventory) {
    setForm({
      quantity: item.quantity,
      reorderLevel: item.reorderLevel,
      location: item.location,
    })
    setEditing(item)
  }

  async function onSubmit(event: FormEvent) {
    event.preventDefault()
    setBusy(true)
    try {
      if (editing) {
        await updateInventory(editing.inventoryId, form)
        setEditing(null)
      } else {
        await createInventory(form)
        setCreating(false)
      }
      await refresh()
    } catch (err) {
      setError(err instanceof ApiError ? err.message : 'Save failed.')
    } finally {
      setBusy(false)
    }
  }

  async function onDelete(item: Inventory) {
    if (!confirm(`Delete location “${item.location}”?`)) return
    try {
      await deleteInventory(item.inventoryId)
      await refresh()
    } catch (err) {
      setError(err instanceof ApiError ? err.message : 'Delete failed.')
    }
  }

  return (
    <>
      <PageHeader
        title="Stock locations"
        subtitle="Quantity and reorder level live on the location, then products point at it."
        action={
          <button type="button" onClick={openCreate}>
            New location
          </button>
        }
      />
      <Banner message={error} />
      {items.length === 0 ? (
        <EmptyState title="No locations yet" text="Add a shelf, bin, or workshop area first." />
      ) : (
        <table>
          <thead>
            <tr>
              <th>Location</th>
              <th>Quantity</th>
              <th>Reorder at</th>
              <th>Status</th>
              <th />
            </tr>
          </thead>
          <tbody>
            {items.map((item) => {
              const low = item.quantity <= item.reorderLevel
              return (
                <tr key={item.inventoryId}>
                  <td>{item.location}</td>
                  <td>{item.quantity}</td>
                  <td>{item.reorderLevel}</td>
                  <td>
                    <span className={`pill ${low ? 'warn' : 'ok'}`}>{low ? 'Reorder' : 'OK'}</span>
                  </td>
                  <td className="row-actions">
                    <button type="button" className="ghost" onClick={() => openEdit(item)}>
                      Edit
                    </button>
                    <button type="button" className="danger" onClick={() => onDelete(item)}>
                      Delete
                    </button>
                  </td>
                </tr>
              )
            })}
          </tbody>
        </table>
      )}

      <Modal
        title={editing ? 'Edit location' : 'New location'}
        open={creating || Boolean(editing)}
        onClose={() => {
          setCreating(false)
          setEditing(null)
        }}
      >
        <ModalForm onSubmit={onSubmit} submitLabel={editing ? 'Update' : 'Create'} busy={busy}>
          <label>
            Location
            <input
              required
              value={form.location}
              onChange={(event) => setForm({ ...form, location: event.target.value })}
            />
          </label>
          <label>
            Quantity
            <input
              type="number"
              required
              min={0}
              value={form.quantity}
              onChange={(event) => setForm({ ...form, quantity: Number(event.target.value) })}
            />
          </label>
          <label>
            Reorder level
            <input
              type="number"
              required
              min={0}
              value={form.reorderLevel}
              onChange={(event) => setForm({ ...form, reorderLevel: Number(event.target.value) })}
            />
          </label>
        </ModalForm>
      </Modal>
    </>
  )
}
