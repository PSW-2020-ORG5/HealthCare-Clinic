<template>
<div id="q-app">
  <div class="q-pa-md q-gutter-md row justify-around">
          <q-card v-for="c in checkups" :key="c.termId" style="max-width:400px">
            <q-list>
              <q-item >
                <div class="">
                <q-item>
                  <q-item-label>Ime doktora</q-item-label>
                </q-item>
                <q-item >
                  <q-item-label >Datum i vreme pregleda</q-item-label>
                </q-item>
                </div>
                <div class="">
                <q-item>
                  <q-item-label caption>{{ c.doctorName }}</q-item-label>
                </q-item>
                <q-item >
                  <q-item-label caption>{{ c.dateF }}</q-item-label>
                </q-item>
                </div>
              </q-item>
            <q-separator />
            <q-card>
              <div class="row justify-end items-center q-gutter-y-sm">
              <q-btn v-on:click="cancelCheckup(c.termId)"  push color="primary" label="Otkaži pregled" />
              </div>
            </q-card>
            </q-list>
          </q-card>
        </div>
</div>
</template>

<script>
export default {
  data () {
    return {
      doctor: {},
      checkups: [],
      checkupId: '',
      columns: [
        {
          name: 'doctorId',
          required: true,
          label: 'Ime i prezime doktora',
          align: 'left',
          field: 'doctorName',
          sortable: true
        },
        { name: 'date', align: 'center', label: 'Datum i vreme pregleda', field: 'dateF', sortable: true }
      ]
    }
  },
  async created () {
    await this.getCheckups()
  },
  methods: {
    getCheckups () {
      this.$axios.get('https://localhost:44397/api/checkups/patientCheckups/' + localStorage.getItem('user'))
        .then(response => {
          response.data.forEach(c => {
            c.doctorName = ''
            this.$axios.get('https://localhost:44395/api/users/' + c.doctorId)
              .then(response => {
                c.doctorName = response.data.name + ' ' + response.data.surname
              })
            var date = new Date(c.startTime)
            c.dateF = date.toLocaleString()
            this.checkups.push(c)
          })
        })
    },
    showButton () {

    },
    async cancelCheckup (id) {
      this.checkups = []
      await this.$axios.delete('https://localhost:44397/api/checkups/cancel/' + id)
        .then(response => {
          this.getCheckups()
        })
    }
  }
}
</script>
