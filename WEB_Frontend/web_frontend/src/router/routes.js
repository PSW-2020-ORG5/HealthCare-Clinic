
const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: '', component: () => import('pages/Index.vue') }
    ],
    beforeEnter: (to, from, next) => {
      if (localStorage.getItem('user') !== null) {
        next()
      } else { next('/login') }
    }
  },
  {
    path: '/login',
    component: () => import('pages/Login.vue')
  },
  {
    path: '/adminhome'
    // component: () => import('pages/Admin.vue')
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: '*',
    component: () => import('pages/Error404.vue')
  }
]

export default routes
