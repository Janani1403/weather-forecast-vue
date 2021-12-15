<template>
  <div class="top-space">
    <div
      class="card text-white bg-transparent div-shadow mb-3"
      style="padding-bottom: 24px"
    >
      <div class="card-header" style="text-align: center">
        <h3>Air Quality</h3>
      </div>
      <div class="row">
        <div class="col">
          <air-quality-chart></air-quality-chart>
        </div>
      </div>
      <div class="row" style="padding: 10px">
        <div v-for="data of airQualityParameters" :key="data.key" class="col">
          <air-quality-parameter :data="data"></air-quality-parameter>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import AirQualityChart from "./AirQualityChart.vue";
import AirQualityParameter from "./AirQualityParameter.vue";
import { useStore } from "vuex";
import { reactive } from "vue";
export default {
  components: { AirQualityChart, AirQualityParameter },
  setup() {
    const store = useStore();
    const data = store.getters["AirQualityModule/getAirQualityData"];
    const airQualityParameters = reactive([
      { key: "O3", value: data.o3 },
      { key: "CO", value: data.co },
      { key: "NO2", value: data.nO2 },
      { key: "PM10", value: data.pM10 },
    ]);
    return { airQualityParameters };
  },
};
</script>
<style>
li {
  height: 5vh;
}
.top-space {
  padding-top: 1.5%;
  padding-right: 1.5%;
  padding-left: 1.5%;
  overflow: hidden;
  position: relative;
}
</style>
