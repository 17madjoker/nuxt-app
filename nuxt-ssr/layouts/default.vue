<template>
  <v-app dark>
    <v-app-bar fixed app>
      <v-toolbar-title v-text="title" />
      <v-spacer />
      <v-toolbar-items class="hidden-xs-only">
        <v-btn text v-for="item in items" :key="item.title" :to="item.to">
          <v-icon left dark>{{ item.icon }}</v-icon>
          {{ item.title }}
        </v-btn>

        <template v-if="$auth.loggedIn">
          <v-btn text to="/weather">
            <v-icon left dark>mdi-weather-sunny</v-icon>
            Weather
          </v-btn>
          <v-btn text @click.prevent='() => $auth.logout("social")'>
            <v-icon left dark>mdi-logout</v-icon>
            Logout
          </v-btn>
          <v-btn text disabled>
            <v-icon left dark>mdi-face</v-icon>
            {{ $auth.user.preferred_username }}
          </v-btn>
        </template>
        <template v-else>
          <v-btn text @click.prevent='() => $auth.loginWith("social")'>
            <v-icon left dark>mdi-login</v-icon>
            Login
          </v-btn>
        </template>
      </v-toolbar-items>
    </v-app-bar>

    <v-main>
      <v-container>
        <nuxt />
      </v-container>
    </v-main>
  </v-app>
</template>

<script>
export default {
  data() {
    return {
      items: [
        { title: "Home", to: "/", icon: "mdi-home" },
        { title: "Register", to: "/register", icon: "mdi-account-plus" }
      ],
      title: "Nuxt SSR"
    };
  }
};
</script>
