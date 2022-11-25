<template>
  <div class="latestNewsBox mb-5">
    <div class="row">
      <div
        :class="
          windowWidth < 1140 ? 'col-sm-12 pt-5 mt-5' : 'col-sm-12 pt-5 mt-5'
        "
      >
        <ul class="list-group list-group-light">
          <li id="pageTitle" class="list-group-item mb-2">Latest News</li>
          <li id="pageBaner" class="list-group-item mb-2">
            <img id="pageBanerImage" src="/newsMain.jpg" alt="">
          </li>

          <li class="list-group-item" v-for="item in last7" :key="item.id">
            <strong>{{ item.title }}</strong> - {{item.content}}
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: ["posts"],
  data() {
    return {
      news: "",
      last7: "",
    };
  },

  mounted() {
    this.news = this.posts ?? JSON.parse(localStorage.getItem("newsData"));
    this.last7 = this.news.reverse().slice(0, 7);
    this.$nextTick(() => {
      window.addEventListener("resize", this.onResize);
    });
  },

  beforeDestroy() {
    window.removeEventListener("resize", this.onResize);
  },

  methods: {
    onResize() {
      this.windowWidth = window.innerWidth;
    },
  },
};
</script>

<style>

#pageBanerImage {
  width: 100%;
}

#pageBaner {
  background-color: rgb(0, 0, 0);
}

.list-group-item {
  font-size: 15px;
  text-overflow: ellipsis;
  overflow: hidden;
  white-space: nowrap;
}

#pageTitle {
  background-color: blueviolet;
  color: white;
  box-shadow: rgba(0, 0, 0, 0.45) 0px 25px 20px -20px;
}

.latestNewsBox {
  box-shadow: rgba(0, 0, 0, 0.45) 0px 25px 20px -20px;
  margin-right: 20px;
  margin-left: 20px;
}
</style>