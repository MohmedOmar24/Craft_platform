import { NavLink, Outlet } from 'react-router-dom'

const links = [
  { to: '/', label: 'Overview', end: true },
  { to: '/categories', label: 'Categories' },
  { to: '/products', label: 'Products' },
  { to: '/inventories', label: 'Stock locations' },
  { to: '/transactions', label: 'Movements' },
]

export function Layout() {
  return (
    <div className="app-shell">
      <aside className="sidebar">
        <div className="brand">
          <span className="mark">CP</span>
          <div>
            <strong>Craft inventory</strong>
            <small>Workshop stock</small>
          </div>
        </div>
        <nav>
          {links.map((link) => (
            <NavLink key={link.to} to={link.to} end={link.end}>
              {link.label}
            </NavLink>
          ))}
        </nav>
      </aside>
      <main className="content">
        <Outlet />
      </main>
    </div>
  )
}
