import { request } from './client'
import type { Category, CategoryWrite } from './types'

export async function listCategories() {
  return (await request<Category[] | null>('/categories')) ?? []
}

export function getCategory(id: string) {
  return request<Category>(`/categories/${id}`)
}

export function createCategory(body: CategoryWrite) {
  return request<void>('/categories', {
    method: 'POST',
    body: JSON.stringify(body),
  })
}

export function updateCategory(id: string, body: CategoryWrite) {
  return request<void>(`/categories/${id}`, {
    method: 'PUT',
    body: JSON.stringify(body),
  })
}

export function deleteCategory(id: string) {
  return request<void>(`/categories/${id}`, { method: 'DELETE' })
}
