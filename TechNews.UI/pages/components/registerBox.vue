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
        <form @submit.prevent="register">
          <div class="container">
            <h3>Sign up for new(s) Technology!</h3>
            <label>
              <span>Name</span>
              <input v-model="userData.name" type="text" />
            </label>
            <label>
              <span>Surname</span>
              <input v-model="userData.surname" type="text" />
            </label>
            <label>
              <span>User Name</span>
              <input v-model="userData.userName" type="text" />
            </label>
            <label>
              <span>Birth Date</span>
              <input v-model="userData.birthDate" type="date" />
            </label>
            <label>
              <span>Email</span>
              <input v-model="userData.email" type="email" />
            </label>
            <label>
              <span>Password</span>
              <input v-model="userData.password" type="password" />
            </label>
            <label>
              <span>Confirm Password</span>
              <input v-model="userData.passwordConfirm" type="password" />
            </label>
            <p class="need-help">Need help?</p>
            <button type="submit" class="submit">Sign Up</button>
          </div>
        </form>
      </div>
      <hide-at :breakpoints="{ small: 910 }" breakpoint="small">
        <div id="rightCol" class="col-sm-4 mt-5 border">
          <img
            class="registerImage"
            src="../../store/images/registerbox_background.jpg"
            alt=""
          />
        </div>
      </hide-at>
    </div>
    <br />
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
        name: "",
        surname: "",
        userName: "",
        email: "",
        password: "",
        passwordConfirm: "",
        birthDate: "",
      },
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

    async register() {

      try {
        if (this.userData.password === this.userData.passwordConfirm) {
        await this.$axios
          .post("/account/register", {
            name: this.userData.name,
            surname: this.userData.surname,
            userName: this.userData.userName,
            email: this.userData.email,
            password: this.userData.password,
            passwordConfirm: this.userData.passwordConfirm,
            birthDate: this.userData.birthDate
          })
          .then(() => {
            this.$router.push("/login");
          });}
      } catch (err) {
          console.log(err);
      }
    },
  },
};
</script>

<style scoped>
#cols {
  max-width: 700px;
}

#colsSmall {
  max-width: 765px;
  width: 85%;
  margin: auto;
}

#leftCol {
  border-radius: 5px 0px 0px 50px;
  box-shadow: rgba(50, 50, 93, 0.25) 0px 50px 100px -20px;
  margin: auto;
}

#leftColSmall {
  border-radius: 5px 5px 50px 50px;
  box-shadow: rgba(50, 50, 93, 0.25) 0px 50px 100px -20px;
  width: 100%;
  margin: auto;
}

#rightCol {
  background-color: #366b35;
  border-radius: 0px 4px 50px 0px;
  box-shadow: rgba(50, 50, 93, 0.25) 0px 50px 100px -20px;
}

input,
button {
  border: none;
  outline: none;
  background: none;
}

.registerImage {
  width: 100%;
  height: auto;
  border-radius: 0px 4px 50px 0px;
}

button {
  display: block;
  margin: 0 auto;
  width: 260px;
  height: 36px;
  border-radius: 30px;
  color: #fff;
  font-size: 15px;
  cursor: pointer;
}

h3 {
  width: 100%;
  font-size: 26px;
  text-align: center;
}

label {
  display: block;
  width: 260px;
  margin: 15px auto 0;
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

.need-help {
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