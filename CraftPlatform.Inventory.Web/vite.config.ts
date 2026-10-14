import react from '@vitejs/plugin-react'
import { defineConfig } from 'vite'

export default defineConfig({
  plugins: [react()],
  server: {
    port: 5173,
    proxy: {
      '/categories': { target: 'http://localhost:5175', changeOrigin: true },
      '/products': { target: 'http://localhost:5175', changeOrigin: true },
      '/inventories': { target: 'http://localhost:5175', changeOrigin: true },
      '/transactions': { target: 'http://localhost:5175', changeOrigin: true },
      '/category': { target: 'http://localhost:5175', changeOrigin: true },
    },
  },
})
