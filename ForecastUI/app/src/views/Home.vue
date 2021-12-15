<template>
  <div class="background-image">
    <navigation-bar :city="city"></navigation-bar>
    <div class="container background-panel p-5">
      <div style="position: relative; z-index: 2">
        <div v-if="!isWindowResized">
          <div class="row no-margins">
            <div class="col col-sm-6">
              <card></card>
            </div>
            <div class="col col-sm-6">
              <chart></chart>
              <quote></quote>
            </div>
          </div>
          <div class="row">
            <history></history>
          </div>
        </div>
        <div v-else>
          <div class="row no-margins">
            <div class="col col-sm-12">
              <card></card>
            </div>
          </div>
          <div class="row" style="padding-top: 30px">
            <div class="col col-sm-12">
              <chart></chart>
              <quote></quote>
            </div>
          </div>
          <div class="row">
            <div class="col col-sm-12">
              <history></history>
            </div>
          </div>
        </div>
        <div>
          <p class="copyright">
            &copy; AppsFactory Widget - All Rights Reserved | Designed by Janani
          </p>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import NavigationBar from "../components/Common/NavigationBar.vue";
import Card from "../components/Home/Card.vue";
import Chart from "../components/Home/Chart.vue";
import Quote from "../components/Home/Quote.vue";
import History from "../components/Home/History.vue";
import { mapGetters } from "vuex";
export default {
  components: {
    Card,
    NavigationBar,
    Chart,
    Quote,
    History,
  },
  computed: {
    ...mapGetters({
      isWindowResized: "getIsWindowResized",
      city: "getCity",
    }),
  },
};
</script>
<style scoped>
.textshadow {
  color: white;
  text-shadow: 1px 1px black;
}
</style>
