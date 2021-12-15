<template>
  <div class="p-2">
    <div
      class="card bg-transparent div-shadow text-white"
      style="width: 100%; height: 27vh"
    >
      <div class="card-img-overlay">
        <div class="row">
          <div class="col col-sm-4">
            <div class="top">
              <h3 class="card-title">{{ city }}</h3>
            </div>
            <div class="top">
              <h4 class="card-title">{{ weather.weatherMain }}</h4>
            </div>
            <div class="top">
              <h5 class="card-title">{{ weather.weatherDescription }}</h5>
            </div>
          </div>
          <div class="col col-sm-4">
            <!-- <img src="../../snowy.png" /> -->
          </div>
          <div class="col col-sm-4">
            <ul class="list-group" style="overflow: hidden">
              <li
                class="list-group-item bg-transparent text-white"
                style="text-align: right; padding-bottom: 30px"
              >
                <h3 class="textshadow" style="text-align: right">
                  {{ weather.temperature }} &#8451;
                </h3>
              </li>
              <li
                class="list-group-item bg-transparent text-white"
                style="text-align: right"
              >
                <p class="remove-vertical-padding">{{ weather.humidity }} %</p>
              </li>
              <li
                class="list-group-item bg-transparent text-white"
                style="text-align: right"
              >
                <p class="remove-vertical-padding">
                  {{ weather.windSpeed }} m/s
                </p>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { useStore } from "vuex";
export default {
  setup() {
    const store = useStore();
    const weather = store.getters["CardModule/getCurrent"];
    const city = store.getters["getCity"];
    return { weather, city };
  },
};
</script>

<style scoped>
.nospace-top {
  position: relative;
  top: 0%;
}
.remove-vertical-padding {
  margin-top: 0;
  margin-bottom: 0;
  font-weight: bold;
  font-size: 100%;
}
li {
  height: 5vh;
}
</style>
