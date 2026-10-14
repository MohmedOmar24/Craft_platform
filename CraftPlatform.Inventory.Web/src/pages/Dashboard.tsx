import { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import { listCategories } from '../api/categories'
import { listInventories } from '../api/inventories'
import { listProducts } from '../api/products'
import { listTransactions } from '../api/transactions'
import { Banner, PageHeader } from '../components/PageHeader'
import { ApiError } from '../api/client'

export function Dashboard() {
  const [error, setError] = useState<string | null>(null)
  const [stats, setStats] = useState({
    categories: 0,
    products: 0,
    locations: 0,
    movements: 0,
    lowStock: 0,
  })

  useEffect(() => {
    let cancelled = false
    Promise.all([listCategories(), listProducts(), listInventories(), listTransactions()])
      .then(([categories, products, inventories, transactions]) => {
        if (cancelled) return
        setStats({
          categories: categories.length,
          products: products.length,
          locations: inventories.length,
          movements: transactions.length,
          lowStock: inventories.filter((item) => item.quantity <= item.reorderLevel).length,
        })
        setError(null)
      })
      .catch((err: unknown) => {
        if (cancelled) return
        setError(err instanceof ApiError ? err.message : 'Could not load overview. Is the API running?')
      })
    return () => {
      cancelled = true
    }
  }, [])

  return (
    <>
      <PageHeader
        title="Overview"
        subtitle="Start with a category, then a stock location, then products and movements."
      />
      <Banner message={error} />
      <div className="cards">
        <StatCard to="/categories" label="Categories" value={stats.categories} />
        <StatCard to="/products" label="Products" value={stats.products} />
        <StatCard to="/inventories" label="Stock locations" value={stats.locations} />
        <StatCard to="/transactions" label="Movements" value={stats.movements} />
        <StatCard to="/inventories" label="At or below reorder" value={stats.lowStock} warn />
      </div>
    </>
  )
}

function StatCard({
  to,
  label,
  value,
  warn,
}: {
  to: string
  label: string
  value: number
  warn?: boolean
}) {
  return (
    <Link to={to} className={`stat-card ${warn && value > 0 ? 'warn' : ''}`}>
      <span>{label}</span>
      <strong>{value}</strong>
    </Link>
  )
}
