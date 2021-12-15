<template>
  <div id="chart" style="padding-left: 30px">
    <apexchart
      type="line"
      height="270"
      width="80%"
      :options="chartOptions"
      :series="series"
    ></apexchart>
  </div>
</template>
<script>
export default {
  data() {
    return {
      series: [
        {
          name: "Temperature",
          data: this.$store.getters["CardModule/getWeather"].map((x) => {
            return x.temperature;
          }),
        },
        {
          name: "Humidity",
          data: this.$store.getters["CardModule/getWeather"].map((x) => {
            return x.humidity / 10;
          }),
        },
      ],
      chartOptions: {
        chart: {
          height: 300,
          type: "line",
          foreColor: "white",
        },
        stroke: {
          width: 3,
          curve: "smooth",
        },
        title: {
          text: "Hour Graph",
          align: "left",
          style: {
            fontSize: "16px",
            color: "white",
          },
        },
        xaxis: {
          type: "time",
          categories: this.$store.getters["CardModule/getTimeIntervals"],
          tickAmount: 10,
          labels: {
            formatter: function (value) {
              return value;
            },
            style: {
              color: "white",
            },
          },
        },
        yaxis: {
          min: -2,
          max: 10,
          tickAmount: 4,
        },
      },
    };
  },
};
</script>
