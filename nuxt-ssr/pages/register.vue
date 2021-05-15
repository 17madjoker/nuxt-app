<template>
  <v-row justify="center" align="center">
    <v-col cols="12" sm="8" md="6">
      <v-card>
        <v-card-title>
          Register form
        </v-card-title>
        <v-card-text>
          <v-form ref="form" v-model="valid">
            <v-text-field
              label="UserName"
              outlined
              required
              :rules="userNameRules"
              v-model="user.userName"
            ></v-text-field>
            <v-text-field
              label="Email"
              outlined
              required
              :rules="emailRules"
              v-model="user.email"
            ></v-text-field>
            <v-text-field
              label="Phone"
              outlined
              required
              v-mask="'+7-###-###-####'"
              :rules="phoneNumberRules"
              v-model="user.phoneNumber"
            ></v-text-field>
            <v-text-field
              label="Password"
              outlined
              required
              :append-icon="isPasswordType ? 'mdi-eye-off' : 'mdi-eye'"
              :type="isPasswordType ? 'password' : 'text'"
              :rules="passwordRules"
              @click:append="isPasswordType = !isPasswordType"
              v-model="user.password"
            ></v-text-field>
            <v-text-field
              label="ConfirmPassword"
              outlined
              required
              :append-icon="isComparePasswordType ? 'mdi-eye-off' : 'mdi-eye'"
              :type="isComparePasswordType ? 'password' : 'text'"
              :rules="confirmPasswordRules"
              @click:append="isComparePasswordType = !isComparePasswordType"
              v-model="user.confirmPassword"
            ></v-text-field>
          </v-form>
        </v-card-text>
        <v-card-actions>
          <v-spacer />
          <v-btn color="primary" :disabled="!valid" @click.prevent="register">
            Register
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
import Vue from 'vue';
import { VueMaskDirective } from 'v-mask';

import {
  formatMobileNumberToDigits
} from '../static/js/utils';

Vue.directive('mask', VueMaskDirective);

export default {
  data() {
    return {
      valid: false,
      user: {
        userName: "",
        email: "",
        phoneNumber: "",
        password: "",
        confirmPassword: ""
      },
      isPasswordType: true,
      isComparePasswordType: true,
      userNameRules: [v => !!v || "Login is required"],
      emailRules: [
        v => !!v || 'E-mail is required',
        v => !v || /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(v) || 'E-mail must be valid'
      ],
      phoneNumberRules: [v => !!v || 'Phone is required'],
      passwordRules: [
        v => !!v || "Password is required",
        v => ( v && v.length >= 8 ) || "Password must have atleast 8 characters",
        v => /[A-ZА-Я]/.test(v) || "Password must have one more upper",
        v => /[a-zа-я]/.test(v) || "Password must have one more lower",
        v => /[!@#$%^&*()_+.]/.test(v) || "Password must have one more special character",
        v => /[0-9]/.test(v) || "Password must have one more digit",
      ],
      confirmPasswordRules: [
        v => !!v || "ConfirmPassword is required",
        () => this.user.password == this.user.confirmPassword || "Password and ConfirmPassword must match"
      ]
    };
  },
  mounted() {
    this.$refs.form.validate();
  },
  methods: {
    register() {
      this.$store.dispatch('account/register', {...this.user, phoneNumber: formatMobileNumberToDigits(this.user.phoneNumber)});
    }
  }
};
</script>

<style></style>
