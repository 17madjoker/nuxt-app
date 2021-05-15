<template>
  <div>
    <h1>Authorize api content page</h1>
    <v-data-table
      :headers="headers"
      :items="weather"
      :items-per-page="5"
      class="elevation-1"
    >
    </v-data-table>
  </div>
</template>

<script>
import { mapState } from 'vuex';

export default {
  middleware: ['authenticated'],
  async fetch({store}) {
    if (store.getters['content/weather'].length == 0)
      await store.dispatch('content/loadWeather')
  },
  data() {
    return {
      headers: [
        { text: 'Date', value: 'date' },
        { text: 'Summary', value: 'summary' },
        { text: 'TemperatureC', value: 'temperatureC' },
        { text: 'TemperatureF', value: 'temperatureF' }
      ]
    }
  },
  computed: {
    ...mapState('content', ['weather'])
  }
}
</script>

<style>

</style>