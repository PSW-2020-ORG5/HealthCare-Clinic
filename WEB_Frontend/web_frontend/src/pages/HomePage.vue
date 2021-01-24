<template>
    <div>
        <div class="row"
            style="background: radial-gradient(circle, #35a2ff 0%, #014a88 100%)">
            <div class="col-6 q-pa-md" style="height: 100px">
              <div class="row">
              <q-img src="../assets/hospital.png"
              height="75px"
              width="75px"></q-img>
               <h4 class="text-white q-mt-md q-mr-sm q-ml-sm">Klinika HealthCare</h4>
              </div>
            </div>
        </div>
  <div class="row q-pa-md">
    <q-carousel
      height="600px"
      style="width:1500px"
      arrows
      animated
      v-model="slide"
      navigation
      infinite
      :autoplay="autoplay"
      transition-prev="slide-right"
      transition-next="slide-left"
      @mouseenter="autoplay = false"
      @mouseleave="autoplay = true"
    >
      <q-carousel-slide name="first" img-src="../assets/doctor.jpg">
      <div class="row">
      <div class="col-10 q-pa-md" style="height: 100px"></div>
      <div class="col-2 q-pa-md" style="height: 100px">
      <q-card class="my-card" style="width:150px height:100px">
      <q-card-section>
          <div class="text-h6 text-bold">Već imate nalog?</div>
          <div class="row justify-center q-pa-md">
          <q-btn v-on:click="login" push color="primary" label="Prijavite se" />
          </div>
        </q-card-section>
      </q-card>
      </div>
      </div>
        <div class="absolute-bottom custom-caption">
          <q-card class="my-card">
            <q-card-section>
            <div class="text-h2 text-bold">Mi pružamo najbolje zdravstvene usluge u regionu!</div>
                <div class="text-h5">Preko milion zadovoljnih pacijenata će to potvrditi</div>
            </q-card-section>
          </q-card>
        </div>
      </q-carousel-slide>
      <q-carousel-slide name="second" img-src="../assets/hospital2.png">
      <div class="row">
      <div class="col-10 q-pa-md" style="height: 100px"></div>
      <div class="col-2 q-pa-md" style="height: 100px">
      <q-card class="my-card" style="width:150px height:100px">
      <q-card-section>
          <div class="text-h6 text-bold">Već imate nalog?</div>
          <div class="row justify-center q-pa-md">
          <q-btn v-on:click="login" push color="primary" label="Prijavite se" />
          </div>
        </q-card-section>
      </q-card>
      </div>
      </div>
        <div class="absolute-bottom custom-caption">
          <q-card class="my-card">
            <q-card-section>
          <div class="text-h2 text-bold">Naš cilj je da brinemo o Vama!</div>
          <div class="text-h5">Svetski priznati doktori čine naš tim</div>
            </q-card-section>
          </q-card>
        </div>
      </q-carousel-slide>
      <q-carousel-slide name="third" img-src="../assets/doctors1.jpg">
      <div class="row">
      <div class="col-10 q-pa-md" style="height: 100px"></div>
      <div class="col-2 q-pa-md" style="height: 100px">
      <q-card class="my-card" style="width:150px height:100px">
      <q-card-section>
          <div class="text-h6 text-bold">Već imate nalog?</div>
          <div class="row justify-center q-pa-md">
          <q-btn v-on:click="login" push color="primary" label="Prijavite se" />
          </div>
        </q-card-section>
      </q-card>
      </div>
      </div>
        <div class="absolute-bottom custom-caption">
          <q-card class="my-card">
            <q-card-section>
          <div class="text-h2 text-bold">Vaša sigurnost je naš prioritet!</div>
          <div class="text-h5">Doktori kojima verujete</div>
            </q-card-section>
          </q-card>
        </div>
      </q-carousel-slide>
    </q-carousel>
  </div>
        <div class="row">
          <div class="col-3 q-pa-md">
          <q-card
            class="my-card text-white"
            style="background: radial-gradient(circle, #35a2ff 0%, #014a88 100%)"
          >
            <q-card-section>
              <div class="row justify-center">
                <div class="text-h6">Kvalifikovano osoblje</div>
                <div class="q-pa-md">
                  <q-img src="../assets/doctor.png"
                    height="75px"
                    width="75px"></q-img>
                </div>
              </div>
            </q-card-section>
          </q-card>
          </div>
          <div class="col-3 q-pa-md">
          <q-card
            class="my-card text-white"
            style="background: radial-gradient(circle, #35a2ff 0%, #014a88 100%)"
          >
            <q-card-section>
              <div class="row justify-center">
                <div class="text-h6">Redovni pregledi</div>
                <div class="q-pa-md">
                  <q-img src="../assets/stethoscope.png"
                height="75px"
                width="75px"></q-img>
                </div>
              </div>
            </q-card-section>
          </q-card>
          </div>
          <div class="col-3 q-pa-md">
          <q-card
            class="my-card text-white"
            style="background: radial-gradient(circle, #35a2ff 0%, #014a88 100%)"
          >
            <q-card-section>
              <div class="row justify-center">
                <div class="text-h6">Savremena oprema</div>
                <div class="q-pa-md">
                  <q-img src="../assets/ultrasound.png"
                    height="75px"
                    width="75px"></q-img>
                </div>
              </div>
            </q-card-section>
          </q-card>
          </div>
          <div class="col-3 q-pa-md">
          <q-card
            class="my-card text-white"
            style="background: radial-gradient(circle, #35a2ff 0%, #014a88 100%)"
          >
            <q-card-section>
              <div class="row justify-center">
                <div class="text-h6">Laboratorijski testovi</div>
                <div class="q-pa-md">
                  <q-img src="../assets/dna.png"
                  height="75px"
                  width="75px"></q-img>
                </div>
              </div>
            </q-card-section>
          </q-card>
          </div>
        </div>
    </div>
</template>
<script>
export default {
  data () {
    return {
      slide: 'first',
      autoplay: true
    }
  },
  methods: {
    login () {
      this.$router.push('/login')
    }
  }
}
</script>
