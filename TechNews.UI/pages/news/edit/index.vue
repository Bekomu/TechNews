<template>
  <client-only>
    <div class="editNewsMain">
      <manage-news mode="Edit"></manage-news>
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

  data() {
    return {
      queryId: "",
    };
  },

  mounted() {
    if (this.$route.params.id != null || this.$route.params.id != undefined) {
      this.queryId = this.$route.params?.id;
    } else {
      this.$router.push("/news");
    }
  },
};
</script>

<style>
.editNewsMain {
  margin: auto;
  max-width: 870px;
}
</style>