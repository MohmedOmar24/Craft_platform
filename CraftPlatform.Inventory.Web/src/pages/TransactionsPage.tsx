import { type FormEvent, useEffect, useState } from 'react'
import { createTransaction, deleteTransaction, listTransactions } from '../api/transactions'
import { ApiError } from '../api/client'
import type { Transaction } from '../api/types'
import { Modal, ModalForm } from '../components/Modal'
import { Banner, EmptyState, PageHeader } from '../components/PageHeader'
import { dateTime, getOrCreateEmployeeId, shortId } from '../lib/format'

const typeLabels = ['Incoming', 'Outgoing'] as const

type FormState = {
  employeeId: string
  quantity: number
  transactionDate: string
  transactionType: number
  notes: string
}

function nowLocal() {
  const date = new Date()
  date.setMinutes(date.getMinutes() - date.getTimezoneOffset())
  return date.toISOString().slice(0, 16)
}

export function TransactionsPage() {
  const [items, setItems] = useState<Transaction[]>([])
  const [error, setError] = useState<string | null>(null)
  const [busy, setBusy] = useState(false)
  const [creating, setCreating] = useState(false)
  const [form, setForm] = useState<FormState>({
    employeeId: '',
    quantity: 1,
    transactionDate: nowLocal(),
    transactionType: 0,
    notes: '',
  })

  async function refresh() {
    try {
      setItems(await listTransactions())
      setError(null)
    } catch (err) {
      setError(err instanceof ApiError ? err.message : 'Could not load movements.')
    }
  }

  useEffect(() => {
    void refresh()
  }, [])

  function openCreate() {
    setForm({
      employeeId: getOrCreateEmployeeId(),
      quantity: 1,
      transactionDate: nowLocal(),
      transactionType: 0,
      notes: '',
    })
    setCreating(true)
  }

  async function onSubmit(event: FormEvent) {
    event.preventDefault()
    setBusy(true)
    try {
      await createTransaction({
        ...form,
        transactionDate: new Date(form.transactionDate).toISOString(),
      })
      setCreating(false)
      await refresh()
    } catch (err) {
      setError(err instanceof ApiError ? err.message : 'Create failed.')
    } finally {
      setBusy(false)
    }
  }

  async function onDelete(item: Transaction) {
    if (!confirm('Delete this movement?')) return
    try {
      await deleteTransaction(item.transactionId)
      await refresh()
    } catch (err) {
      setError(err instanceof ApiError ? err.message : 'Delete failed.')
    }
  }

  return (
    <>
      <PageHeader
        title="Movements"
        subtitle="Incoming is 0, outgoing is 1. There is no update endpoint yet."
        action={
          <button type="button" onClick={openCreate}>
            Record movement
          </button>
        }
      />
      <Banner message={error} />
      {items.length === 0 ? (
        <EmptyState title="No movements yet" text="Record stock coming in or going out." />
      ) : (
        <table>
          <thead>
            <tr>
              <th>When</th>
              <th>Type</th>
              <th>Qty</th>
              <th>Notes</th>
              <th>Employee</th>
              <th />
            </tr>
          </thead>
          <tbody>
            {items.map((item) => (
              <tr key={item.transactionId}>
                <td>{dateTime(item.transactionDate)}</td>
                <td>
                  <span className={`pill ${item.transactionType === 0 ? 'ok' : 'warn'}`}>
                    {typeLabels[item.transactionType] ?? item.transactionType}
                  </span>
                </td>
                <td>{item.quantity}</td>
                <td>{item.notes}</td>
                <td>{shortId(item.employeeId)}</td>
                <td className="row-actions">
                  <button type="button" className="danger" onClick={() => onDelete(item)}>
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}

      <Modal title="Record movement" open={creating} onClose={() => setCreating(false)}>
        <ModalForm onSubmit={onSubmit} submitLabel="Create" busy={busy}>
          <label>
            Type
            <select
              value={form.transactionType}
              onChange={(event) => setForm({ ...form, transactionType: Number(event.target.value) })}
            >
              <option value={0}>Incoming</option>
              <option value={1}>Outgoing</option>
            </select>
          </label>
          <label>
            Quantity
            <input
              type="number"
              required
              min={1}
              value={form.quantity}
              onChange={(event) => setForm({ ...form, quantity: Number(event.target.value) })}
            />
          </label>
          <label>
            Date
            <input
              type="datetime-local"
              required
              value={form.transactionDate}
              onChange={(event) => setForm({ ...form, transactionDate: event.target.value })}
            />
          </label>
          <label>
            Notes
            <textarea
              required
              value={form.notes}
              onChange={(event) => setForm({ ...form, notes: event.target.value })}
            />
          </label>
          <label>
            Employee id
            <input
              required
              value={form.employeeId}
              onChange={(event) => setForm({ ...form, employeeId: event.target.value })}
            />
          </label>
        </ModalForm>
      </Modal>
    </>
  )
}
