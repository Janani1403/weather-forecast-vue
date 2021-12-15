<template>
  <div id="card">
    <div class="row no-margins">
      <div class="col col-sm-5">
        <div id="chart">
          <apexchart
            type="radialBar"
            style="height: 70px"
            :options="data.chartOptions"
            :series="data.series"
          ></apexchart>
        </div>
      </div>
      <div class="col col-sm-7">
        <span class="border border-dark">
          <h5>AQI : {{ airQualityIndex }}</h5>
          <p>{{ airQualityDetails }}</p>
        </span>
      </div>
    </div>
  </div>
</template>
<script>
import { reactive, ref } from "vue";
import { useStore } from "vuex";
export default {
  setup() {
    const store = useStore();
    const aqi = store.getters["AirQualityModule/getAirQualityData"].aqi;
    const data = reactive({
      series: [aqi * 20],
      chartOptions: {
        chart: {
          height: 50,
          type: "radialBar",
          toolbar: {
            show: true,
          },
        },
        plotOptions: {
          radialBar: {
            startAngle: 0,
            endAngle: 360,
            hollow: {
              margin: 0,
              size: "40%",
              background: "#fff",
              image: undefined,
              imageOffsetX: 0,
              imageOffsetY: 0,
              position: "front",
              dropShadow: {
                enabled: true,
                top: 3,
                left: 0,
                blur: 4,
                opacity: 0.24,
              },
            },
            track: {
              background: "#fff",
              strokeWidth: "80%",
              margin: 0, // margin is in pixels
              dropShadow: {
                enabled: true,
                top: -3,
                left: 0,
                blur: 4,
                opacity: 0.35,
              },
            },

            dataLabels: {
              show: true,
              name: {
                offsetY: -10,
                show: true,
                color: "black",
                fontSize: "14px",
              },
              value: {
                formatter: function (val) {
                  return val / 20;
                },
                offsetY: 0,
                color: "black",
                fontSize: "30px",
                show: true,
              },
            },
          },
        },
        fill: {
          type: "gradient",
          gradient: {
            shade: "dark",
            type: "horizontal",
            shadeIntensity: 0.5,
            gradientToColors: ["#ccffff", "#000099"],
            inverseColors: true,
            opacityFrom: 1,
            opacityTo: 1,
            stops: [0, 100],
          },
        },
        stroke: {
          lineCap: "round",
        },
        labels: ["AQI"],
      },
    });
    const airQualityIndex = ref("");
    const airQualityDetails = ref("");
    if (aqi == 1) {
      airQualityIndex.value = "Good";
      airQualityDetails.value +=
        "Air quality is satisfactory, and air pollution poses little or no risk.";
    } else if (aqi == 2) {
      airQualityIndex.value = "Fair";
      airQualityDetails.value +=
        "Members of sensitive groups may experience health effects. The general public is less likely to be affected.";
    } else if (aqi == 3) {
      airQualityIndex.value = "Moderate";
      airQualityDetails.value +=
        "Some members of the general public may experience health effects; members of sensitive groups may experience more serious health effects.";
    } else if (aqi == 4) {
      airQualityIndex.value = "Poor";
      airQualityDetails.value +=
        "Health alert: The risk of health effects is increased for everyone.";
    } else {
      airQualityIndex.value = "Very Poor";
      airQualityDetails.value +=
        "Air quality is acceptable. However, there may be a risk for some people, particularly those who are unusually sensitive to air pollution.";
    }
    return { data, airQualityIndex, airQualityDetails };
  },
};
</script>
