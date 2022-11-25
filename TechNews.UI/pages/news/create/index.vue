<template>
  <client-only>
    <div class="createNewsMain">
      <manage-news mode="Create"></manage-news>
    </div>
  </client-only>
</template>

<script>
import ManageNews from "../../components/manageNewsBox.vue";
export default {
  layout: "MainLayout",
  components: {
    manageNews: ManageNews,
  },

  mounted() {
    if (!this.$auth.loggedIn) {
      this.$router.push("/home?m=unauthorized");
    }
  },
};
</script>

<style>
.createNewsMain {
  margin: auto;
  max-width: 870px;
}
</style>
