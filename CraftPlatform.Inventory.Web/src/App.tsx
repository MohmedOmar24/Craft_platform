import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom'
import { Layout } from './components/Layout'
import { CategoriesPage } from './pages/CategoriesPage'
import { Dashboard } from './pages/Dashboard'
import { InventoriesPage } from './pages/InventoriesPage'
import { ProductsPage } from './pages/ProductsPage'
import { TransactionsPage } from './pages/TransactionsPage'

export default function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route element={<Layout />}>
          <Route index element={<Dashboard />} />
          <Route path="categories" element={<CategoriesPage />} />
          <Route path="products" element={<ProductsPage />} />
          <Route path="inventories" element={<InventoriesPage />} />
          <Route path="transactions" element={<TransactionsPage />} />
          <Route path="*" element={<Navigate to="/" replace />} />
        </Route>
      </Routes>
    </BrowserRouter>
  )
}
