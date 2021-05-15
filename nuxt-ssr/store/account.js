export const state = () => ({
})

export const mutations = {
}

export const actions = {
  async register(context, payload) {   
    await this.$axios
      .post(`${process.env.AuthBaseUrl}/account/register`, payload)
      .then(response => {
        this.$router.push('/');
      })
      .catch(error => {
        this.$toast.error(error.response.data)
      })
  }
}

export const getters = {
}