
const routes = [
  {
    path: '/homePage',
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
    path: '/',
    component: () => import('pages/HomePage.vue')
  },
  {
    path: '/schedule',
    component: () => import('layouts/PatientLayout.vue'),
    children: [
      { path: '', component: () => import('pages/AllAppointments.vue') }
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
    path: '/newAppointment',
    component: () => import('layouts/PatientLayout.vue'),
    children: [
      { path: '', component: () => import('pages/CreateAppointment.vue') }
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
    component: () => import('layouts/AdminLayout.vue'),
    children: [
      { path: '', component: () => import('pages/Admin.vue') }
    ],
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
