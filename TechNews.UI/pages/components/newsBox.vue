<template>
  <div>
    <div id="newsCard" class="card my-2">
      <img :src="imageUrl" class="card-img-top" />
      <div class="card-body">
        <h5 class="card-title">{{title}}</h5>
        <p class="card-content">
          {{ content }}
        </p>
      </div>

      <div id="manageButtons" v-if="loggedInUser" class="card-body">
        <nuxt-link class="card-link" :to="'/news/edit/' + newsId">Edit</nuxt-link>
        <nuxt-link class="card-link" :to="'/news/delete/' + newsId">Delete</nuxt-link>
      </div>

    </div>
  </div>
</template>

<script>
export default {
  props: ["post"],

  data() {
    return {
      news: this.post,
      imageUrl: this.post?.imageURL ?? "/default_news.jpg",
      title : this.post?.title ?? "News Title",
      content : this.post?.content ?? "News Content...",
      newsId : this.post?.id ?? "null",
      loggedInUser: null
    };
  },

  mounted() {
    this.loggedInUser = this.$auth.user
  }
};
</script>

<style>

.card-link {
  color: black;
}

#manageButtons {
  position: absolute;
  bottom: 0px;
}


#newsCard {
  max-width: 350px;
  height: 450px;
  box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
  border-radius: 50px 50px 15px 15px;
  margin: auto;
}

.card-img-top {
  border-radius: 0px 0px 50px 50px;
  box-shadow: rgba(0, 0, 0, 0.09) 0px 2px 1px, rgba(0, 0, 0, 0.09) 0px 4px 2px,
    rgba(0, 0, 0, 0.09) 0px 8px 4px, rgba(0, 0, 0, 0.09) 0px 16px 8px,
    rgba(0, 0, 0, 0.09) 0px 32px 16px;
    height: 250px;
    width: 100%;
}

.card-title {
  overflow: hidden;
  font-size: 18px;
  text-overflow: ellipsis;
  display: -webkit-box;
  -webkit-line-clamp: 1;
  line-clamp: 1;
  -webkit-box-orient: vertical;
}

.card-content {
  overflow: hidden;
  font-size: 15px;
  text-overflow: ellipsis;
  display: -webkit-box;
  -webkit-line-clamp: 4;
  line-clamp: 2;
  -webkit-box-orient: vertical;
}
</style>
