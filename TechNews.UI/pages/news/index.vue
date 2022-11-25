<template>
  <client-only>
    <div>
      <news-main :posts="datas"></news-main>
    </div>
  </client-only>
</template>

<script>
import NewsMain from "../components/newsMain.vue";
export default {
  layout: "MainLayout",
  components: {
    newsMain: NewsMain,
  },

  data() {
    return {
      datas: null,
      user: null,
    };
  },

  async mounted() {
    try {
      const response = await this.$axios.$get("/posts");
      this.datas = response.data;
      localStorage.setItem("newsData", JSON.stringify(response.data));
    } catch (err) {
      console.log(err);
    }
  },
};
</script>

<style>
</style>
