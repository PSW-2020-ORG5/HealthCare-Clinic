
const routes = [
  {
    path: '/',
    component: () => import('layouts/PatientLayout.vue'),
    children: [
      { path: '', component: () => import('pages/Index.vue') }
    ],
    beforeEnter: (to, from, next) => {
      var user = localStorage.getItem('user')
      var role = localStorage.getItem('role')
      if (user !== null) {
        if (role === '1') {
          next()
        } else { next('/forbidden') }
      } else { next('/login') }
    }
  },
  {
    path: '/login',
    component: () => import('pages/Login.vue')
  },
  {
    path: '/adminhome',
    component: () => import('pages/Admin.vue'),
    beforeEnter: (to, from, next) => {
      var user = localStorage.getItem('user')
      var role = localStorage.getItem('role')
      if (user !== null) {
        if (role === '0') {
          next()
        } else { next('/forbidden') }
      } else { next('/login') }
    }
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: '*',
    component: () => import('pages/Error404.vue')
  },
  {
    path: '/forbidden',
    component: () => import('pages/Forbidden.vue')
  }

]

export default routes
