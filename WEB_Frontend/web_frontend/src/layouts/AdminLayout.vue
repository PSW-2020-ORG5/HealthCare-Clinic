<template>
  <q-layout view="lHh Lpr lFf">
    <q-header elevated>
      <q-toolbar>
        <q-toolbar-title>
          HealthCare klinika-Admin
        </q-toolbar-title>

        <q-btn v-on:click="logout">Odjava</q-btn>
      </q-toolbar>
    </q-header>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>
<script>
export default {
  name: 'MainLayout',
  data () {
    return {
    }
  },
  methods: {
    logout () {
      localStorage.removeItem('user')
      this.$router.push('/login')
    }
  }
}
</script>
