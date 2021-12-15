import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import VueApexCharts from "vue3-apexcharts";
import VueLoading from "vue-loading-overlay";
import "vue-loading-overlay/dist/vue-loading.css";

//Navigation Guard added - Redirects to connection lost if backend server is down

router.beforeEach((to, from, next) => {
  if (to.matched.some((record) => record.meta.requiresData)) {
    if (from.name != undefined) {
      if (!store.getters["getIsDataAvailable"]) {
        next({
          name: "ConnectionLost",
        });
      } else {
        next();
      }
    } else {
      next();
    }
  } else {
    next();
  }
});

createApp(App)
  .use(store)
  .use(router)
  .use(VueLoading)
  .use(VueApexCharts)
  .mount("#app");
