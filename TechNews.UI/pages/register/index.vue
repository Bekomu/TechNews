<template>
  <client-only>
      <register-box></register-box>
  </client-only>
</template>

<script>
import RegisterBox from '../components/registerBox.vue'
export default {
    layout : "MainLayout",
    components : {
        registerBox : RegisterBox
    }
}
</script>

<style>

</style>