<template></template>

<script>
export default {
  mounted() {
    console.log(this.$route.params.id);

    if (!this.$auth.loggedIn) {
      this.$router.push("/home?m=unauthorized");
    } else {
      this.deleteData(this.$route.params.id);
      this.$router.push("/");
    }
  },

  methods: {
    async deleteData(id) {
      try {
        if (id != null) {
          const response = await this.$axios.delete("/posts/" + id);
        }
      } catch ({ response, err }) {
        console.log(err);
        if (response?.status == 401) {
          localStorage.setItem("user", null);
          this.$router.push("/login?m=unauthorized");
        }
      }
    },
  },
};
</script>

<style>
</style>