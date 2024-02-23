import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      redirect: '/dashboard',
      name: 'dashboard',
      component: () => import("@/layouts/Layout.vue"),
      children:[
        {
          path: '/dashboard',
          name: 'dashboard',
          component: () => import('@/views/dashboard/Index.vue'),
        },
        {
          path: '/bank',
          name: 'bank',
          component: () => import('@/views/bank/Index.vue'),
        },
        {
          path: '/investments',
          name: 'investments',
          component: () => import('@/views/investments/Index.vue'),
        }
      ]
    },
    {
      path: '/',
      redirect: '/login',
      component: () => import('@/layouts/LayoutBlank.vue'),
      children:[
        {
          path: '/login',
          name: 'login',
          component: () => import('@/views/authentication/Login.vue'),
        }
      ]
    }
  ]
})

export default router
