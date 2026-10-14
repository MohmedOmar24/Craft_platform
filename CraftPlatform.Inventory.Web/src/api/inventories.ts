import { request } from './client'
import type { Inventory, InventoryWrite } from './types'

export async function listInventories() {
  return (await request<Inventory[] | null>('/inventories')) ?? []
}

export function getInventory(id: string) {
  return request<Inventory>(`/inventories/${id}`)
}

export function createInventory(body: InventoryWrite) {
  return request<{ inventoryId?: string; invenoryId?: string }>('/inventories', {
    method: 'POST',
    body: JSON.stringify(body),
  })
}

export function updateInventory(id: string, body: InventoryWrite) {
  return request<void>(`/inventories/${id}`, {
    method: 'PUT',
    body: JSON.stringify(body),
  })
}

export function deleteInventory(id: string) {
  return request<void>(`/inventories/${id}`, { method: 'DELETE' })
}
