<template>
  <client-only>
    <div class="editNewsMain">
      <manage-news mode="Edit"></manage-news>
    </div>
  </client-only>
</template>

<script>
import { axios } from "@nuxtjs/axios";
import ManageNews from "../../../components/manageNewsBox.vue";
export default {
  layout: "MainLayout",
  components: {
    manageNews: ManageNews,
  },

  data() {
    return {
    };
  },

  mounted() {
    
  },

  methods: {
    
  },
};
</script>

<style>
.editNewsMain {
  margin: auto;
  max-width: 870px;
}
</style>
