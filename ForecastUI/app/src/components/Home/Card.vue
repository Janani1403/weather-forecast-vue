<template>
  <div>
    <div
      id="card-main"
      class="card bg-dark"
      @click="getDetails()"
      style="width: 100%; height: 50vh"
      title="View more details for today's weather"
    >
      <img
        :src="image"
        class="card-img"
        style="height: 100%; filter: grayscale(80%)"
      />
      <div class="card-img-overlay">
        <div class="padding-top">
          <div class="row">
            <div class="col col-sm-6">
              <h3 class="card-title textshadow">
                {{ weather.weatherMain }}
              </h3>
            </div>
            <div class="col col-sm-6" style="text-align: right">
              <h3 class="card-title textshadow">{{ city }}</h3>
            </div>
          </div>
          <h5 class="card-title textshadow">
            {{ weather.weatherDescription }}
          </h5>
        </div>

        <div class="row">
          <div class="col col-sm div-align-bottom">
            <div class="card-text">
              <h1 class="textshadow" style="text-align: right">
                {{ weather.temperature }} &#8451;
              </h1>
              <div class="row">
                <div class="col col-sm-6">
                  <p class="textshadow p-weathermain">{{ date }}</p>
                </div>
                <div class="col col-sm-6">
                  <p class="textshadow p-weathermain" style="text-align: right">
                    {{ weather.humidity }} %
                  </p>
                </div>
              </div>
              <p class="textshadow p-weathermain" style="text-align: right">
                {{ weather.windSpeed }} m/s
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="card-group" style="width: 100%">
        <div
          class="col"
          v-for="(data, index) of average"
          :key="data.day"
          @click="updateCurrent(index)"
        >
          <div
            id="card-average"
            class="card card-margins text-white bg-transparent"
            :class="{ active: isActive[index] }"
          >
            <div class="card-body">
              <!-- card-img-overlay -->
              <p class="remove-vertical-padding fw-bold">
                {{ data.day }}
              </p>
              <p class="remove-vertical-padding fw-bold fst-italic">
                {{ data.averageTemperature }}
                &#8451;
              </p>
              <p class="remove-vertical-padding fw-bold fst-italic">
                {{ data.averageHumidity }}
                &#8459;
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { mapGetters } from "vuex";
import router from "../../router/index";
import UseGetImages from "../../hooks/GetImages";
export default {
  created() {
    this.timer = setInterval(this.updateCurrentIndex, 10800000);
  },
  mounted() {
    this.date = new Date().toLocaleString();
    this.updateImage();
  },
  data() {
    return {
      image: "",
      date: "",
      isActive: [true, false, false, false, false],
    };
  },
  methods: {
    updateCurrent(i) {
      this.$store.dispatch("CardModule/setCurrent", i);
      this.isActive[i] = true;
      const value = new Date();
      value.setDate(value.getDate() + i);
      this.date = value.toLocaleString();
      this.updateImage();
    },
    getDetails() {
      router.push("/details");
    },
    updateCurrentIndex() {
      this.$store.dispatch("CardModule/setCurrentIndex");
    },
    updateImage() {
      this.image = UseGetImages(
        this.weather.weatherMain,
        this.weather.weatherDescription
      );
    },
  },
  computed: {
    ...mapGetters({
      weather: "CardModule/getCurrent",
      average: "CardModule/getAverage",
      city: "getCity",
    }),
  },
};
</script>
<style scoped>
.div-align-bottom {
  position: absolute;
  bottom: 0;
  padding-bottom: 10px;
  padding-right: 20px;
}
.img-cover {
  object-fit: cover;
}
.remove-vertical-padding {
  margin-top: 0;
  margin-bottom: 0;
  font-size: 70%;
}
.textshadow {
  color: white;
  text-shadow: 1px 1px black;
}
.background-card {
  position: relative;
}

.background-card::before {
  content: "";
  background: black;
  /* background-size: cover; */
  position: absolute;
  top: 0px;
  right: 0px;
  bottom: 0px;
  left: 0px;
  opacity: 0;
  z-index: 1;
}
.p-weathermain {
  margin-top: 0;
  margin-bottom: 0;
  font-weight: bold;
  font-size: 15px;
}
.card-margins {
  margin: 2px;
  border: 1px solid white;
}
#card-main:hover {
  transform: scale(1.01);
  cursor: pointer;
}
#card-average:hover {
  opacity: 0.5;
  cursor: pointer;
}
</style>
