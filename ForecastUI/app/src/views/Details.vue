<template>
  <div class="background-image">
    <div class="container background-panel p-4">
      <div style="position: relative; z-index: 2">
        <div v-if="!isWindowResized">
          <page-header></page-header>
          <div class="row" style="padding-top: 33px">
            <div class="col col-sm-6">
              <parameters></parameters>
            </div>
            <div class="col col-sm-6">
              <air-quality></air-quality>
            </div>
          </div>
        </div>
        <div v-else>
          <page-header></page-header>
          <div class="row" style="padding-top: 33px">
            <div class="col col-sm-12">
              <parameters></parameters>
            </div>
          </div>
          <div class="row" style="padding-top: 33px">
            <div class="col col-sm-12">
              <air-quality></air-quality>
            </div>
          </div>
        </div>
        <div>
          <p class="copyright" style="padding-top: 20px">
            &copy; AppsFactory Widget - All Rights Reserved | Designed by Janani
          </p>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import PageHeader from "../components/Details/PageHeader.vue";
import Parameters from "../components/Details/Parameters.vue";
import AirQuality from "../components/Details/AirQuality.vue";

import { mapGetters } from "vuex";

export default {
  components: {
    PageHeader,
    Parameters,
    AirQuality,
  },

  setup() {},
  computed: {
    ...mapGetters({
      isWindowResized: "getIsWindowResized",
    }),
  },
};
</script>
<style>
.div-shadow {
  box-shadow: 0 0 1px 1px grey;
}
</style>
