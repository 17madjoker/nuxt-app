<template>
  <v-row justify="center" align="center">
    <!-- <v-col cols="12" sm="8" md="6">
      <v-card>
        <v-card-title>
          Login form
        </v-card-title>
        <v-card-text>
          <v-form ref="form" v-model="valid">
            <v-text-field
              label="Login"
              outlined
              required
              :rules="loginRules"
              v-model="login"
            ></v-text-field>
            <v-text-field
              label="Password"
              outlined
              required
              :append-icon="isPasswordType ? 'mdi-eye-off' : 'mdi-eye'"
              :type="isPasswordType ? 'password' : 'text'"
              :rules="passwordRules"
              @click:append="isPasswordType = !isPasswordType"
              v-model="password"
            ></v-text-field>
          </v-form>
        </v-card-text>
        <v-card-actions>
          <v-spacer />
          <v-btn color="primary" :disabled="!valid" @click.prevent="signIn">
            Login
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-col> -->
  </v-row>
</template>

<script>
export default {
  data() {
    return {
      valid: false,
      login: "",
      password: "",
      isPasswordType: true,
      loginRules: [v => !!v || "Login is required"],
      passwordRules: [v => !!v || "Password is required"]
    };
  },
  mounted() {
    this.$refs.form.validate();
  },
  methods: {
    async signIn() {
      var self = this;
      
      this.$auth.loginWith("social").then(async () => {
        await self.$auth.fetchUser();
      });
    }
  }
};
</script>

<style></style>
