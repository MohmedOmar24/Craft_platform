import { request } from './client'
import type { Transaction, TransactionWrite } from './types'

export async function listTransactions() {
  return (await request<Transaction[] | null>('/transactions')) ?? []
}

export function getTransaction(id: string) {
  return request<Transaction>(`/transactions/${id}`)
}

export function createTransaction(body: TransactionWrite) {
  return request<{ transactionId: string }>('/transactions', {
    method: 'POST',
    body: JSON.stringify(body),
  })
}

export function deleteTransaction(id: string) {
  return request<void>(`/transactions/${id}`, { method: 'DELETE' })
}
