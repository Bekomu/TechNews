<template>
  <div>
    <br /><br />
    <div
      :id="windowWidth > 910 ? 'cols' : 'colsSmall'"
      :class="windowWidth > 910 ? 'row w-75 m-auto' : 'row'"
    >
      <div
        :id="windowWidth > 910 ? 'leftCol' : 'leftColSmall'"
        :class="
          windowWidth > 910 ? 'col-sm-8 mt-5 pt-5' : 'col-md-12 mt-5 pt-5'
        "
      >
        <form @submit.prevent="loginUser">
          <div class="container m-auto">
            <h5 v-if="message">You should login for access news...</h5>
            <h2>Welcome back,</h2>
            <label>
              <span>Email</span>
              <input type="email" v-model="userData.email" />
            </label>
            <label>
              <span>Password</span>
              <input type="password" v-model="userData.password" />
            </label>
            <p class="forgot-pass">Forgot password?</p>
            <button type="submit" class="submit">Sign In</button>
          </div>
        </form>
      </div>
      <hide-at :breakpoints="{ small: 910 }" breakpoint="small">
        <div id="rightCol" class="col-sm-4 mt-5 border">
          <img
            class="loginImage"
            src="../../store/images/loginbox_background.jpg"
            alt=""
          />
        </div>
      </hide-at>
    </div>
  </div>
</template>

<script>
import { showAt, hideAt } from "vue-breakpoints";
export default {
  components: {
    hideAt,
    showAt,
  },

  data() {
    return {
      windowWidth: window.innerWidth,
      userData: {
        email: "",
        password: "",
      },
      route: "",
      message: null,
    };
  },

  mounted() {
    this.$nextTick(() => {
      window.addEventListener("resize", this.onResize);
    });
    this.message = this.$route?.query.m;
  },

  beforeDestroy() {
    window.removeEventListener("resize", this.onResize);
  },

  methods: {
    onResize() {
      this.windowWidth = window.innerWidth;
    },

    loginUser() {
      try {
        this.$auth
        .loginWith("local", {
          data: {
            email: this.userData.email,
            password: this.userData.password,
          },
        }).then(() => {
          this.$router.push('/home?m=loggedIn');
        })
        } catch(err) {
          console.log(err);
        }
    },
  },
};
</script>

<style scoped>
*,
*:before,
*:after {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}

#cols {
  max-width: 665px;
}

#colsSmall {
  max-width: 665px;
  width: 85%;
  margin: auto;
}

#leftCol {
  border-radius: 5px 0px 0px 50px;
  box-shadow: rgba(50, 50, 93, 0.25) 0px 50px 100px -20px;
}

#leftColSmall {
  border-radius: 5px 5px 50px 50px;
  box-shadow: rgba(50, 50, 93, 0.25) 0px 50px 100px -20px;
  width: 100%;
  margin: auto;
}

#rightCol {
  background-color: #001232;
  border-radius: 0px 4px 50px 0px;
  box-shadow: rgba(50, 50, 93, 0.25) 0px 50px 100px -20px;
}

input,
button {
  border: none;
  outline: none;
  background: none;
}

.loginImage {
  width: 100%;
  height: auto;
  border-radius: 0px 4px 50px 0px;
}

.submit {
  display: block;
  margin: 0 auto;
  width: 260px;
  height: 36px;
  border-radius: 30px;
  color: #fff;
  font-size: 15px;
  cursor: pointer;
}

h2 {
  width: 100%;
  font-size: 26px;
  text-align: center;
}

h5 {
  width: 100%;
  text-align: center;
  color: red;
}

label {
  display: block;
  width: 260px;
  margin: 25px auto 0;
  text-align: center;
}

label span {
  font-size: 12px;
  color: #2f2f2f;
  text-transform: uppercase;
}

input {
  display: block;
  width: 100%;
  margin-top: 5px;
  padding-bottom: 5px;
  font-size: 16px;
  border-bottom: 1px solid rgba(0, 0, 0, 0.4);
  text-align: center;
}

.forgot-pass {
  margin-top: 15px;
  text-align: center;
  font-size: 12px;
  color: #989898;
}

.submit {
  margin-top: 40px;
  margin-bottom: 20px;
  background: #008371;
  text-transform: uppercase;
}

.submitSmall {
  margin-top: 40px;
  margin-bottom: 20px;
  background: #008371;
  text-transform: uppercase;
  width: 50%;
}
</style>
