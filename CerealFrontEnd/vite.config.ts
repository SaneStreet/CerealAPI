import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    port: 5173,
    host: true,
    strictPort: false,
    watch: {
      usePolling: true,
    },
    proxy: {
      '/api': {
        target: 'http://api:5556', // api = service-name in docker-compose
        changeOrigin: true,
      }
    }
  }
})
