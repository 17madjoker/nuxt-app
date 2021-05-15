export const state = () => ({
  weather: []
})

export const mutations = {
  setWeather(state, weather) {
    state.weather = weather
  }
}

export const actions = {
  async loadWeather({commit}) {
    await this.$axios
      .get(`${process.env.ContentBaseUrl}/api/WeatherForecast/weather`)
      .then(response => {
        commit('setWeather', response.data)
      })
  }
}

export const getters = {
  weather: state => state.weather
}