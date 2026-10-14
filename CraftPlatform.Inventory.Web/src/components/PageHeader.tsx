import { type ReactNode } from 'react'

type PageHeaderProps = {
  title: string
  subtitle: string
  action?: ReactNode
}

export function PageHeader({ title, subtitle, action }: PageHeaderProps) {
  return (
    <div className="page-header">
      <div>
        <h1>{title}</h1>
        <p>{subtitle}</p>
      </div>
      {action}
    </div>
  )
}

export function Banner({ message, kind = 'error' }: { message: string | null; kind?: 'error' | 'info' }) {
  if (!message) return null
  return <div className={`banner ${kind}`}>{message}</div>
}

export function EmptyState({ title, text }: { title: string; text: string }) {
  return (
    <div className="empty">
      <strong>{title}</strong>
      <p>{text}</p>
    </div>
  )
}
