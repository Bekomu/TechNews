<template>
  <client-only>
    <div>
      <nav
        id="mainNavBar"
        class="navbar navbar-expand-sm navbar-dark bg-dark fixed-top"
      >
        <span class="navbar-brand"
          >TechNews -
          {{
            $route.name == "news-create"
              ? "Create"
              : $route.name == "news-edit"
              ? "Edit"
              : $route.name == "login"
              ? "Author Login"
              : $route.name == "register"
              ? "Author Register"
              : ""
          }}
          News Page</span
        >
          <ul class="navbar-nav mr-auto">
            <li class="nav-item active">
              <nuxt-link to="/"
              ><a>Home</a></nuxt-link
            >
            <nuxt-link v-if="!isPageCreate" to="/news/create"
              ><a>Create Post</a></nuxt-link
            >
            </li>
          </ul>
            <div v-if="!loggedInUser" class="navbar-text">
    
              <nuxt-link to="/register"
                ><span class="btn btn-secondary mr-3">Register</span></nuxt-link
              >
              <nuxt-link to="/login"
                ><span class="btn btn-success mr-3">Login</span></nuxt-link
              >
    
            </div>
          <div v-else>
              <span v-if="loggedInUser" class="user mr-3">({{ loggedInUser.email }})</span>
              <button @click="logoutUser" class="btn btn-danger mr-3">Logout</button
            >
          </div>
      </nav>
      <div class="content">
        <Nuxt />
      </div>
      <footer class="w-100 py-1">
        <div class="container mt-2">
          <div class="row gy-4 gx-5">
            <div class="col-lg-4 col-md-6">
              <h5 class="h1 text-white">TechNews</h5>
              <p class="small text-muted">News has now met with technology.</p>
              <p class="small text-muted mb-0">
                &copy; Copyrights. All rights reserved.
                <a class="text-primary" href="github.com/bekomu"
                  >github.com/bekomu</a
                >
              </p>
            </div>
            <div class="col-lg-2 col-md-6">
              <h5 class="text-white mb-3">Quick links</h5>
              <ul class="list-unstyled text-muted">
                <li><a href="#">Home</a></li>
                <li><a href="#">Post News</a></li>
                <li><a href="#">Edit News</a></li>
              </ul>
            </div>
            <div class="col-lg-2 col-md-6">
              <h5 class="text-white mb-3">About Us</h5>
              <ul class="list-unstyled text-muted">
                <li><a href="#">Get Started</a></li>
                <li><a href="#">About</a></li>
                <li><a href="#">FAQ</a></li>
              </ul>
            </div>
            <div class="col-lg-4 col-md-6">
              <h5 class="text-white mb-3">Newsletter</h5>
              <p class="small text-muted">
                Your ideas are important to us, what about our news ? Please
                subscribe and get TechNews.
              </p>
              <form action="#">
                <div class="input-group mb-3">
                  <input
                    class="form-control"
                    type="text"
                    placeholder="Your mail adress..."
                    aria-label="Recipient's username"
                    aria-describedby="button-addon2"
                  />
                  <a
                    class="btn btn-primary"
                    id="button-addon2"
                    type="button"
                  >Send</a>
                </div>
              </form>
            </div>
          </div>
        </div>
      </footer>
    </div>
  </client-only>
</template>

<script>
import { showAt, hideAt } from "vue-breakpoints";
export default {
  data() {
    return {
      loggedInUser: null,
      isPageCreate : false
    };
  },

  components: {
    hideAt,
    showAt,
  },

  mounted() {
    this.loggedInUser = this.$auth.user
    console.log(this.$auth.loggedIn)
    const page = this.$route.name
    if (page === 'news-create' && this.$auth.loggedIn) {this.isPageCreate = true}
  },

  methods : {
    logoutUser() {
        try {
          this.$auth.logout().then(() => {
          this.$router.push('/home?m=unauthorized');
        });
        } catch(err) {
          console.log(err)
        }
    },
  }
};
</script>

<style >
a {
  color : white;
  margin-left: 20px;
}

#mainNavBar {
  height: 50px;
  box-shadow: rgba(0, 0, 0, 0.09) 0px 2px 1px, rgba(0, 0, 0, 0.09) 0px 4px 2px,
    rgba(0, 0, 0, 0.09) 0px 8px 4px, rgba(0, 0, 0, 0.09) 0px 16px 8px,
    rgba(0, 0, 0, 0.09) 0px 32px 16px;
}

.user {
  color : white
}

.content {
  min-height: calc(
    100vh - 168px
  ); 
  max-width: 75%;
  margin: auto;
}

footer {
  margin-top: 0; 
  margin-bottom: -10px; 
  padding-bottom: 5px;
  background: #212529; 
}

</style>
