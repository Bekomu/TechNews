<template>
  <client-only>
    <div>
      <div class="newsMain mb-5">
        <latest-news-box :posts="news"></latest-news-box>

        <div
          class="wrapper"
          :style="
            windowWidth < 575
              ? 'grid-template-columns: repeat(1, 1fr);'
              : windowWidth < 965
              ? 'grid-template-columns: repeat(2, 1fr);'
              : ''
          "
        >
          <news-box v-for="item in news" :key="item.id" :post="item"></news-box>
        </div>
      </div>
    </div>
  </client-only>
</template>

<script>
import NewsBox from "./newsBox.vue";
import LatestNews from "./latestNewsBox.vue";
export default {
  components: {
    newsBox: NewsBox,
    latestNewsBox: LatestNews,
  },

  props: ["posts"],

  data() {
    return {
      windowWidth: window.innerWidth,
      news: this.posts ?? JSON.parse(localStorage.getItem("newsData")),
    };
  },

  mounted() {
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
.wrapper {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 10px;
}

.newsMain {
  max-width: 950px;
  margin: auto;
}
</style>