<template>
    <div>
        <q-dialog v-model="alert">
      <q-card>
        <q-card-section>
          <div class="text-h6">Obaveštenje</div>
        </q-card-section>

        <q-card-section class="q-pt-none">
          Uspešno ste zakazali pregled kod željenog doktora!
        </q-card-section>

        <q-card-actions align="right">
          <q-btn flat label="U redu" color="primary" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>
        <div class="col text-center">
            <h3 class="text-primary">Zakažite svoj pregled kod željenog doktora:</h3>
        </div>
    <div class="q-pa-md">
      <div>
    <div class="row justify-center">
    <q-stepper
      v-model="step"
      ref="stepper"
      color="primary"
      animated
      style="max-width:500px"
    >
      <q-step
        :name="1"
        title="Izaberite datum pregleda"
        icon="date_range"
        :done="step > 1"
        :header-nav="step > 1"
      >
      <h4 class="text-primary">Izaberite datum:</h4>
        <div class="q-pa-md">
            <div class="q-gutter-md row items-start justify-center">
            <q-date
                v-model="date"
                minimal
                mask="YYYY-MM-DDTHH:mm:ss"
            />
            </div>
        </div>

        <q-stepper-navigation>
          <q-btn v-on:click="choosenDate" color="primary" label="Nastavi dalje" />
        </q-stepper-navigation>
      </q-step>

      <q-step
        :name="2"
        title="Izaberite specijalnost"
        icon="list_alt"
        :done="step > 2"
        :header-nav="step > 2"
      >
        <h4 class="text-primary">Izaberite specijalnost doktora:</h4>
        <div class="q-pa-md">
          <div class="q-gutter-sm">
            <q-radio v-model="doctorType" val="0" label="Lekar opšte prakse" />
          </div>
          <div class="q-gutter-sm">
            <q-radio v-model="doctorType" val="1" label="Kardiolog" />
          </div>
          <div class="q-gutter-sm">
            <q-radio v-model="doctorType" val="2" label="Dermatolog" />
          </div>
          <div class="q-gutter-sm">
            <q-radio v-model="doctorType" val ="3" label="Neurolog" />
          </div>
          <div class="q-gutter-sm">
            <q-radio v-model="doctorType" val="4" label="Onkolog" />
          </div>
          <div class="q-gutter-sm">
            <q-radio v-model="doctorType" val="5" label="Otorinolaringolog" />
          </div>
        </div>
        <q-stepper-navigation>
          <q-btn v-on:click="chooseDoctor" color="primary" label="Nastavi dalje" />
          <q-btn flat @click="step = 1;postEvent(0)" color="primary" label="Vrati se" class="q-ml-sm" />
        </q-stepper-navigation>
      </q-step>

      <q-step
        :name="3"
        title="Izaberite doktora"
        icon="person"
        :done="step > 3"
        :header-nav="step > 3"
      >
        <h4 class="text-primary">Izaberite doktora:</h4>
        <div class="q-pa-md">
          <div class="q-gutter-sm" v-for="doctor in doctors" :key="doctor.id">
            <q-radio v-model="selectedDoctor" v-bind:val="doctor" v-bind:label="doctor.name+' '+doctor.surname" />
          </div>
        </div>

        <q-stepper-navigation>
          <q-btn v-on:click="goToStep4" color="primary" label="Nastavi dalje" />
          <q-btn flat @click="step = 2;postEvent(1)" color="primary" label="Vrati se" class="q-ml-sm" />
        </q-stepper-navigation>
      </q-step>

      <q-step
        :name="4"
        title="Zakazite pregled"
        icon="post_add"
        :header-nav="step > 4"
      >
        <h4 class="text-primary">Zakažite pregled:</h4>
        <div class="q-pa-md">
          <div class="q-gutter-sm" v-for="c in freeCheckups" :key="c.startTime">
            <q-radio v-model="selectedCheckup" v-bind:val="c" v-bind:label="c.dateF" />
          </div>
        </div>
        <q-stepper-navigation>
          <q-btn color="primary" v-on:click="scheduleCheckup" label="Zakaži pregled" />
          <q-btn flat @click="step = 3;postEvent(2)" color="primary" label="Vrati se" class="q-ml-sm" />
        </q-stepper-navigation>
      </q-step>
    </q-stepper>
  </div>
    </div>
    </div>
    </div>
</template>

<script>
import { v4 as uuidv4 } from 'uuid'
export default {
  data () {
    return {
      alert: false,
      step: 1,
      date: '',
      doctorType: '',
      doctors: [],
      selectedDoctor: null,
      freeCheckups: [],
      selectedCheckup: null,
      scheduledCheckup: {},
      uuid: ''
    }
  },
  created () {
    var uuid = uuidv4()
    this.uuid = uuid
    this.$axios.post('https://localhost:44340/events', {
      SessionId: this.uuid,
      Type: 0,
      User: parseInt(localStorage.getItem('user'))
    })
  },
  methods: {
    postEvent (type) {
      this.$axios.post('https://localhost:44340/events/', {
        SessionId: this.uuid,
        Type: type,
        User: parseInt(localStorage.getItem('user'))
      })
    },
    choosenDate () {
      if (this.date === '') {
        this.$q.notify({
          color: 'red-5',
          textColor: 'white',
          icon: 'warning',
          message: 'Morate izabrati datum!'
        })
        return
      }
      this.done1 = true
      this.postEvent(1)
      this.step = 2
    },
    getSpecialist () {
      this.$axios.get('https://localhost:44340/users/docSpec/' + this.doctorType)
        .then(response => {
          this.doctors = response.data
        })
    },
    chooseDoctor () {
      if (this.doctorType === '') {
        this.$q.notify({
          color: 'red-5',
          textColor: 'white',
          icon: 'warning',
          message: 'Morate izabrati specijalnost doktora!'
        })
        return
      }
      this.getSpecialist()
      this.postEvent(2)
      this.step = 3
    },
    getAvaliableAppointments () {
      this.$axios.post('https://localhost:44340/appointments/freeCheckups', {
        doctorId: this.selectedDoctor.id,
        fromDate: this.selectedDoctor.businessHours.fromDate,
        toDate: this.selectedDoctor.businessHours.toDate,
        fromHour: this.selectedDoctor.businessHours.fromHour,
        toHour: this.selectedDoctor.businessHours.toHour,
        checkupStartTime: this.date
      })
        .then(response => {
          this.noCheckups = false
          if (response.data.length === 0) {
            this.noCheckups = true
            this.$q.notify({
              color: 'red-5',
              textColor: 'white',
              icon: 'warning',
              message: 'Nema termina za izabrane parametre,pokusajte ponovo!'
            })
            this.postEvent(5)
            return
          }
          this.freeCheckups = response.data
          this.freeCheckups.forEach(c => {
            var date = new Date(c.startTime)
            c.dateF = date.toLocaleString()
          })
        })
    },
    goToStep4 () {
      if (this.selectedDoctor === null) {
        this.$q.notify({
          color: 'red-5',
          textColor: 'white',
          icon: 'warning',
          message: 'Morate izabrati doktora!'
        })
        return
      }
      this.getAvaliableAppointments()
      this.postEvent(3)
      this.step = 4
    },
    scheduleCheckup () {
      if (this.selectedCheckup === null) {
        this.$q.notify({
          color: 'red-5',
          textColor: 'white',
          icon: 'warning',
          message: 'Morate izabrati termin!'
        })
        return
      }
      this.$axios.post('https://localhost:44340/appointments/schedule', {
        doctorId: this.selectedDoctor.id,
        fromDate: this.selectedDoctor.businessHours.fromDate,
        toDate: this.selectedDoctor.businessHours.toDate,
        fromHour: this.selectedDoctor.businessHours.fromHour,
        toHour: this.selectedDoctor.businessHours.toHour,
        checkupStartTime: this.selectedCheckup.startTime,
        checkupEndTime: this.selectedCheckup.endTime,
        patientId: parseInt(localStorage.getItem('user'))
      })
        .then(response => {
          this.scheduledCheckup = response.data
          this.postEvent(4)
          this.finishCheckup()
        })
        .catch(error => {
          console.log(error)
          this.$q.notify({
            color: 'red-5',
            textColor: 'white',
            icon: 'warning',
            message: 'Greška prilikom zakazivanja termina'
          })
        })
    },
    finishCheckup () {
      this.done4 = true
      this.alert = true
    }
  }
}
</script>
