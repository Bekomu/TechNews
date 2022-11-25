<template>
  <div>
    <br /><br /><br /><br />
    <div id="createNewsMain" class="row">
      <div id="leftCol" class="col-sm-6 my-2">
        <form
          v-if="mode === 'Create'"
          @submit.prevent="manageNews"
          id="newsForm"
          class="mb-5"
        >
          <div class="form-row"></div>
          <div class="form-group">
            <label for="inputTitle">Title</label>
            <input
              v-model="post.newsTitle"
              type="text"
              class="form-control"
              id="inputTitle"
            />
          </div>

          <div class="form-group">
            <label for="inputContent">Content</label>
            <textarea
              v-model="post.newsContent"
              class="form-control"
              id="inputContent"
              cols="40"
              rows="10"
              maxlength="1024"
            ></textarea>
          </div>
          <div class="form-group">
            <label for="inputImageURL">Image Url</label>
            <input
              type="text"
              class="form-control"
              id="inputImageURL"
              v-model="post.newsImageUrl"
            />
          </div>

          <button type="submit" class="btn btn-primary">{{ mode }} News</button>
        </form>

        <form v-else @submit.prevent="manageNews" id="newsForm" class="mb-5">
          <div class="form-row"></div>
          <div class="form-group">
            <label for="inputTitle">Title</label>
            <input
              v-model="editPost.title"
              type="text"
              class="form-control"
              id="inputTitle"
            />
          </div>

          <div class="form-group">
            <label for="inputContent">Content</label>
            <textarea
              v-model="editPost.content"
              class="form-control"
              id="inputContent"
              cols="40"
              rows="10"
              maxlength="1024"
            ></textarea>
          </div>
          <div class="form-group">
            <label for="inputImageURL">Image Url</label>
            <input
              type="text"
              class="form-control"
              id="inputImageURL"
              v-model="editPost.imageURL"
            />
          </div>

          <button type="submit" class="btn btn-primary">{{ mode }} News</button>
        </form>
      </div>
      <div id="rightCol" class="col-sm-6">
        <news-box :post="editPost"></news-box>
      </div>
    </div>
  </div>
</template>

<script>
import NewsBox from "./newsBox.vue";
export default {
  components: {
    newsBox: NewsBox,
  },
  props: ["mode"],

  data() {
    return {
      editPost: "",

      post: {
        newsTitle: "",
        newsContent: "",
        newsImageUrl: "",
        newsId: "",
      },

      userId: "",
      manageMode: this.mode,
      queryId: "",
    };
  },

  mounted() {
    this.queryId = this.$route.params?.id;
    this.userId = this.$auth.user?.id;
    this.getData();
  },

  methods: {
    async getData() {
      try {
        const response = await this.$axios.get("/posts/" + this.queryId);
        this.editPost = response.data.data;
      } catch (err) {
        console.log(err);
      }
    },

    async manageNews() {
      console.log(this.post);
      try {
        if (this.mode === "Create") {
          const response = await this.$axios.post("/posts", {
            title: this.post.newsTitle,
            content: this.post.newsContent,
            imageURL: this.post.newsImageUrl,
            authorId: this.userId,
          });
          this.$router.push("/");
        } else if (this.mode === "Edit") {
          const response = await this.$axios.put("/posts", {
            id: this.editPost.id,
            title: this.editPost.title,
            content: this.editPost.content,
            imageURL: this.editPost.imageURL,
          });
          this.$router.push("/");
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
#createNewsMain {
  box-shadow: rgba(0, 0, 0, 0.25) 0px 25px 50px -12px;
  border-radius: 5px 5px 50px 50px;
  margin-bottom: 50px;
}

#newsForm {
  max-width: 80%;
  margin: auto;
}

#inputContent {
  min-height: 250px;
  max-height: 500px;
  columns: 40;
}
</style>
