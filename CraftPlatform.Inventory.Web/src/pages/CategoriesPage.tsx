import { type FormEvent, useEffect, useState } from 'react'
import {
  createCategory,
  deleteCategory,
  listCategories,
  updateCategory,
} from '../api/categories'
import { ApiError } from '../api/client'
import type { Category } from '../api/types'
import { Modal, ModalForm } from '../components/Modal'
import { Banner, EmptyState, PageHeader } from '../components/PageHeader'
import { dateTime } from '../lib/format'

type FormState = { name: string; description: string }

const emptyForm: FormState = { name: '', description: '' }

export function CategoriesPage() {
  const [items, setItems] = useState<Category[]>([])
  const [error, setError] = useState<string | null>(null)
  const [busy, setBusy] = useState(false)
  const [form, setForm] = useState<FormState>(emptyForm)
  const [editing, setEditing] = useState<Category | null>(null)
  const [creating, setCreating] = useState(false)

  async function refresh() {
    try {
      setItems(await listCategories())
      setError(null)
    } catch (err) {
      setError(err instanceof ApiError ? err.message : 'Could not load categories.')
    }
  }

  useEffect(() => {
    void refresh()
  }, [])

  function openCreate() {
    setForm(emptyForm)
    setCreating(true)
  }

  function openEdit(item: Category) {
    setForm({ name: item.name, description: item.description })
    setEditing(item)
  }

  async function onSubmit(event: FormEvent) {
    event.preventDefault()
    setBusy(true)
    try {
      if (editing) {
        await updateCategory(editing.categoryId, form)
        setEditing(null)
      } else {
        await createCategory(form)
        setCreating(false)
      }
      await refresh()
    } catch (err) {
      setError(err instanceof ApiError ? err.message : 'Save failed.')
    } finally {
      setBusy(false)
    }
  }

  async function onDelete(item: Category) {
    if (!confirm(`Delete category “${item.name}”?`)) return
    try {
      await deleteCategory(item.categoryId)
      await refresh()
    } catch (err) {
      setError(err instanceof ApiError ? err.message : 'Delete failed.')
    }
  }

  return (
    <>
      <PageHeader
        title="Categories"
        subtitle="Group products before you add stock."
        action={
          <button type="button" onClick={openCreate}>
            New category
          </button>
        }
      />
      <Banner message={error} />
      {items.length === 0 ? (
        <EmptyState title="No categories yet" text="Create one to start adding products." />
      ) : (
        <table>
          <thead>
            <tr>
              <th>Name</th>
              <th>Description</th>
              <th>Updated</th>
              <th />
            </tr>
          </thead>
          <tbody>
            {items.map((item) => (
              <tr key={item.categoryId}>
                <td>{item.name}</td>
                <td>{item.description}</td>
                <td>{dateTime(item.updatedAt)}</td>
                <td className="row-actions">
                  <button type="button" className="ghost" onClick={() => openEdit(item)}>
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

      <Modal
        title={editing ? 'Edit category' : 'New category'}
        open={creating || Boolean(editing)}
        onClose={() => {
          setCreating(false)
          setEditing(null)
        }}
      >
        <ModalForm onSubmit={onSubmit} submitLabel={editing ? 'Update' : 'Create'} busy={busy}>
          <label>
            Name
            <input
              required
              value={form.name}
              onChange={(event) => setForm({ ...form, name: event.target.value })}
            />
          </label>
          <label>
            Description
            <textarea
              required
              value={form.description}
              onChange={(event) => setForm({ ...form, description: event.target.value })}
            />
          </label>
        </ModalForm>
      </Modal>
    </>
  )
}
