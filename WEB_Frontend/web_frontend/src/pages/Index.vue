<template>
  <q-page class="flex flex-center">
     <div class="q-pa-md">
     <q-carousel
      arrows
      animated
      v-model="slide"
      height="600px"
      style="width:1100px"
    >
      <q-carousel-slide name="first" img-src="../assets/pharmacy1.jpg">
        <div class="absolute-bottom custom-caption">
          <div class="text-h2">{{actions[0].pharmacy}}</div>
          <div class="text-h4">{{actions[0].message}}</div>
        </div>
      </q-carousel-slide>
      <q-carousel-slide name="second" img-src="../assets/pharmacy2.jpg">
        <div class="absolute-bottom custom-caption ">
          <div class="text-h2">{{actions[1].pharmacy}}</div>
          <div class="text-h4">{{actions[1].message}}</div>
        </div>
      </q-carousel-slide>
      <q-carousel-slide name="third" img-src="../assets/pharmacy3.jpg">
        <div class="absolute-bottom custom-caption">
          <div class="text-h2">{{actions[2].pharmacy}}</div>
          <div class="text-h4">{{actions[2].message}}</div>
        </div>
      </q-carousel-slide>
    </q-carousel>
  </div>
  </q-page>
</template>

<script>
export default {
  name: 'PageIndex',
  data () {
    return {
      slide: 'first',
      actions: [],
      bla: 'a'
    }
  },
  beforeCreate () {
    this.$axios.get('http://localhost:62946/api/actionbenefit')
      .then(response => {
        this.actions = response.data
        this.bla = 'af'
        alert(response.data[0].message)
      })
  }
}
</script>
<style lang="sass" scoped>
.custom-caption
  text-align: center
  padding: 12px
  color: white
  background-color: rgba(0, 0, 0, .3)
</style>
