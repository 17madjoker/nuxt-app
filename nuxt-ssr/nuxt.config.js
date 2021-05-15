import colors from 'vuetify/es5/util/colors'

const AUTH_BASE_URL = 'https://localhost:44315'
const CONTENT_BASE_URL = 'https://localhost:44316'
const CLIENT_BASE_URL = 'http://localhost:3000'

export default {
  head: {
    titleTemplate: '%s - nuxt-ssr',
    title: 'nuxt-ssr',
    htmlAttrs: {
      lang: 'en'
    },
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { hid: 'description', name: 'description', content: '' }
    ],
    link: [
      { rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' }
    ]
  },

  css: [
  ],

  plugins: [
  ],

  components: true,

  buildModules: [
    '@nuxtjs/vuetify',
  ],

  modules: [
    '@nuxtjs/axios',
    '@nuxtjs/auth-next',
    '@nuxtjs/toast',
  ],

  axios: {},

  toast: {
    position: 'top-right',
    duration: 5000,
    closeOnSwipe: true
  },

  // router: {
  //   middleware: ['auth']
  // },

  auth: {
    strategies: {
      social: {
        scheme: 'oauth2',
        endpoints: {
          authorization: `${AUTH_BASE_URL}/connect/authorize`,
          userInfo: `${AUTH_BASE_URL}/connect/userinfo`,
          logout: `${AUTH_BASE_URL}/connect/endsession`,
        },
        responseType: 'code id_token token',
        grantType: 'authorization_code',
        redirect_uri: `${CLIENT_BASE_URL}`,
        logoutRedirectUri: `${CLIENT_BASE_URL}`,
        clientId: 'nuxt_ssr',
        scope: ['openid', 'profile', 'auth.admin'],
      }
    }
  },

  vuetify: {
    customVariables: ['~/assets/variables.scss'],
    theme: {
      dark: true,
      themes: {
        dark: {
          primary: colors.blue.darken2,
          accent: colors.grey.darken3,
          secondary: colors.amber.darken3,
          info: colors.teal.lighten1,
          warning: colors.amber.base,
          error: colors.deepOrange.accent4,
          success: colors.green.accent3
        }
      }
    }
  },

  env: {
    AuthBaseUrl: AUTH_BASE_URL,
    ContentBaseUrl: CONTENT_BASE_URL,
    ClientBaseUrl: CLIENT_BASE_URL,
  },

  build: {
  }
}
