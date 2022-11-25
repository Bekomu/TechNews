<template>
  <client-only>
    <login-box></login-box>
  </client-only>
</template>

<script>
import LoginBox from '../components/loginBox.vue'
export default {
  layout : "MainLayout",
  components : {
    loginBox : LoginBox,
  },

}
</script>

<style scoped>

</style>