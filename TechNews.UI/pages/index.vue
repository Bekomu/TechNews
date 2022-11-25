<template>
  <client-only>
    <div>
    </div>
  </client-only>
</template>

<script>
import NewsMain from "./components/newsMain.vue";
export default {
  layout: "MainLayout",
  data() {
    return {
      datas: null,
      user: null,
    };
  },

  methods : {
    delay(time) {
      return new Promise((resolve) => setTimeout(resolve, time));
    }
  },

  mounted() {
      this.delay(2000);
      this.$router.push('/news');
  },


};
</script>

<style>
</style>
