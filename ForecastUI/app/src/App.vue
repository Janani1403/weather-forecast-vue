<template>
  <router-view></router-view>
</template>
<script>
// import { useCookies } from "vue3-cookies";
import { onMounted, onUnmounted, ref } from "vue";
import { useStore } from "vuex";
//hook
import UseGetForecast from "./hooks/GetForecast";
//bootstrap
import "bootstrap/dist/css/bootstrap.min.css";

export default {
  components: {},
  name: "App",

  setup() {
    //Module constants
    //const { cookies } = useCookies();
    const store = useStore();
    const width = ref(document.documentElement.clientWidth);
    const height = ref(document.documentElement.clientHeight);

    //Mounted event
    onMounted(() => {
      // if (!cookies) {
      //   cookies.set("city", store.getters["getCity"]);
      //   cookies.set("user", store.getters["getUser"]);
      // }
      window.addEventListener("resize", getDimensions);

      //First time loads Berlin data by default
      if (store.getters["CardModule/getCount"] == 0) {
        const [GetForecastByCityOrZipCode] = UseGetForecast();
        // if (!cookies) {
        GetForecastByCityOrZipCode("Berlin");
        // } else {
        //   GetForecastByCityOrZipCode(cookies.get("city"));
        // }
      } else {
        store.dispatch("setIsDataAvailable", true);
      }
    });

    //Unmounted
    onUnmounted(() => {
      window.removeEventListener("resize", getDimensions);
      //Persisted store used - resetting to true
      store.dispatch("setIsDataAvailable", true);
    });

    //Flag set when window resized - to update the view
    const getDimensions = () => {
      width.value = document.documentElement.clientWidth;
      height.value = document.documentElement.clientHeight;
      if (width.value < 750) {
        store.dispatch("setIsWindowResized", true);
      } else {
        store.dispatch("setIsWindowResized", false);
      }
    };
  },
};
</script>
<style>
.no-margins {
  /* position: relative; */
  margin-bottom: -5px;
  padding: 0px;
}
.background-image {
  height: 100%;
  background-image: url("./assets/background.jpg");
  background-repeat: no-repeat;
  background-size: cover;
}
.div-border {
  box-shadow: 6px 6px 6px white, 6px 6px 6px white;
}
.background-panel {
  position: relative;
}
.copyright {
  color: whitesmoke;
  text-align: center;
  bottom: 0;
}

.background-panel::before {
  content: "";
  background: black;
  position: absolute;
  top: 0px;
  right: 0px;
  bottom: 0px;
  left: 0px;
  opacity: 0.6;
  z-index: 1;
}
</style>
