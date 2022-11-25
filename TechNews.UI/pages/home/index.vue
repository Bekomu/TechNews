<template>
  <client-only> </client-only>
</template>

<script>
export default {
  name: "IndexPage",
  layout: "MainLayout",

  data() {
    return {
      message: "",
    };
  },

  methods: {
  activate() {
    setTimeout(() => this.isHidden = false, 500);
  }
  },

  mounted() {
    this.layout = null,
    this.message = this.$route.query.m;
    console.log(this.message);
    setTimeout(() => {
      this.layout = 'MainLayout';
      if (this.message === 'loggedIn') this.$router.push('/news?m=loggedIn');
      if (this.message === 'unauthorized') this.$router.push("/login?m=unauthorized");
    }, 1500);
  },

};
</script>
