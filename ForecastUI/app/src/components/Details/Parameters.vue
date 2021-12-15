<template>
  <div class="top-space" style="padding-botton: 30px">
    <div class="card text-white bg-transparent div-shadow mb-3">
      <div class="card-header" style="text-align: center">
        <h3>Current Weather</h3>
      </div>
      <table class="table text-white table-sm">
        <tbody>
          <tr>
            <td>Min Temperature</td>
            <td>{{ weatherNow.minTemperature }}</td>
            <td class="font-italic fw-bold">&#8451;</td>
          </tr>
          <tr>
            <td>Max Temperature</td>
            <td>{{ weatherNow.maxTemperature }}</td>
            <td class="font-italic fw-bold">&#8451;</td>
          </tr>
          <tr>
            <td>Pressure</td>
            <td>{{ weatherNow.pressure }}</td>
            <td class="font-italic fw-bold">hPa</td>
          </tr>
          <tr>
            <td>Wind Degree</td>
            <td>{{ weatherNow.windDegree }}</td>
            <td class="font-italic fw-bold">m/s</td>
          </tr>
          <tr>
            <td>Wind Gust</td>
            <td>{{ weatherNow.windGust }}</td>
            <td class="font-italic fw-bold">m/s</td>
          </tr>
          <tr>
            <td>Visibility</td>
            <td>{{ weatherNow.visibility }}</td>
            <td class="font-italic fw-bold">m</td>
          </tr>
          <tr>
            <td>Sunrise</td>
            <td>{{ sunrise }}</td>
            <td class="font-italic fw-bold">m</td>
          </tr>
          <tr>
            <td>Sunset</td>
            <td>{{ sunset }}</td>
            <td class="font-italic fw-bold">m</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>
<script>
import { useStore } from "vuex";
export default {
  setup() {
    const store = useStore();
    const weatherNow = store.getters["ParametersModule/getCurrentParameters"];
    const sunrise = store.getters["getSunrise"];
    const sunset = store.getters["getSunset"];
    return { weatherNow, sunset, sunrise };
  },
};
</script>
<style scoped>
tr {
  height: 2px;
}
.top-space {
  padding-top: 1.5%;
  padding-left: 1.5%;
  overflow: hidden;
  position: relative;
}
.img {
  box-shadow: 0 0 1px 1px grey;
}
</style>
