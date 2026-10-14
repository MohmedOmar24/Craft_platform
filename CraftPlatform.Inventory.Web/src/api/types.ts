export type Category = {
  categoryId: string
  name: string
  description: string
  createdBy: string
  updatedBy: string
  createdAt: string
  updatedAt: string
}

export type CategoryWrite = {
  name: string
  description: string
}

export type Product = {
  productId: string
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

export type ProductWrite = {
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

export type Inventory = {
  inventoryId: string
  quantity: number
  reorderLevel: number
  location: string
}

export type InventoryWrite = {
  quantity: number
  reorderLevel: number
  location: string
}

export type Transaction = {
  transactionId: string
  employeeId: string
  transactionDate: string
  quantity: number
  transactionType: number
  notes: string
  createdBy: string
  updatedBy: string
  createdOn: string
  updatedOn: string
}

export type TransactionWrite = {
  employeeId: string
  quantity: number
  transactionDate: string
  transactionType: number
  notes: string
}
