import { request } from './client'
import type { Product, ProductWrite } from './types'

export async function listProducts() {
  return (await request<Product[] | null>('/products')) ?? []
}

export function getProduct(id: string) {
  return request<Product>(`/products/${id}`)
}

export function listProductsByCategory(categoryId: string) {
  return request<Product[]>(`/category/${categoryId}/products`)
}

export function createProduct(body: ProductWrite) {
  return request<{ productId: string }>('/products', {
    method: 'POST',
    body: JSON.stringify(body),
  })
}

export function updateProduct(id: string, body: { name: string; description: string }) {
  return request<void>(`/products/${id}`, {
    method: 'PUT',
    body: JSON.stringify(body),
  })
}

export function updateProductCategory(productId: string, categoryId: string) {
  return request<void>(`/category/products/${productId}`, {
    method: 'PUT',
    body: JSON.stringify({ categoryId }),
  })
}

export function deleteProduct(id: string) {
  return request<void>(`/products/${id}`, { method: 'DELETE' })
}
