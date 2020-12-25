<template>
    <div>
  <div class="col text-center">
      <h2>Dobrodosli klinika Bla</h2>
      <h4>Unesite vase podatke za prijavu:</h4>
  </div>
  <div class="row q-pa-md  justify-center">
    <div style="width:300px;">
    <q-form @submit="submit" class="q-gutter-md">
        <q-input standout="bg-teal text-white" v-model="username" label="Korisnicko ime" :dense="dense" />
        <q-input v-model="password" filled type="password" hint="Sifra" standout="bg-teal text-white" />
        <div>
        <q-btn label="Prijavi se" type="submit" color="teal"/>
      </div>
    </q-form>
    </div>
  </div>
    </div>
</template>

<script>
export default {
  name: 'Login',
  data: function () {
    return {
      dense: false,
      username: '',
      password: ''
    }
  },
  methods: {
    submit () {
      alert('klik')
    }
  }
}
</script>
