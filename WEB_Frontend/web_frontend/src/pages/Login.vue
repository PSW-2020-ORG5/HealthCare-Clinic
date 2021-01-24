<template>
    <div>
  <div class="col text-center">
      <h2 class="text-bold">Dobrodošli klinika HealthCare</h2>
      <h4>Unesite vaše podatke za prijavu:</h4>
  </div>
  <div class="row q-pa-md  justify-center">
    <div style="width:300px;">
    <q-form @submit="submit" class="q-gutter-md">
       <q-input standout="bg-primary text-white" v-model="username" label="Korisnicko ime" :dense="dense"  lazy-rules
        :rules="[ val => val && val.length > 0 || 'Polje ne sme biti prazno']" />
        <q-input v-model="password" filled type="password" label="Sifra" standout="bg-primary text-white" lazy-rules
        :rules="[ val => val && val.length > 0 || 'Polje ne sme biti prazno']"  />
        <div>
        <q-btn label="Prijavi se" type="submit" color="primary"/>
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
      this.$axios.post('https://localhost:44340/users/login', {
        username: this.username,
        password: this.password
      })
        .then(response => {
          localStorage.setItem('user', response.data.id)
          localStorage.setItem('role', response.data.role)
          localStorage.setItem('token', response.data.token)
          if (response.data.role === 0) { this.$router.push('/adminhome') } else this.$router.push('/homePage')
        })
        .catch(error => {
          console.log(error)
          this.$q.notify({
            color: 'red-5',
            textColor: 'white',
            icon: 'warning',
            message: 'Greška prilikom prijave'
          })
        })
    }
  }
}
</script>
