<template>
  <form @submit.prevent="ValidateAndLoadData()">
    <div class="add-top-padding">
      <div style="padding-left: 5%; padding-right: 5%">
        <div ref="mapDiv" style="width: 100%; height: 81vh"></div>
      </div>
    </div>
    <div class="add-top-padding">
      <div class="row add-top-padding justify-content-center">
        <div class="col col-sm-3">
          <input
            type="text"
            class="form-control"
            placeholder="City"
            aria-label="City"
            id="googleAutoComplete"
            @blur="updateText($event)"
          />
        </div>

        <div class="col col-sm-3">
          <input
            type="text"
            class="form-control"
            placeholder="Zip Code"
            aria-label="Zip Code"
            v-model="zipcode"
          />
        </div>
        <div class="col col-sm-1">
          <button class="btn btn-outline-light">Select</button>
        </div>
      </div>
      <div class="row justify-content-center">
        <div class="col col-sm-4">
          <p style="color: red" v-show="!isValid">
            Please provide an address within Germany
          </p>
        </div>
      </div>
      <div id="loader-wrapper" v-show="isLoading">
        <div id="loader"></div>
        <div class="loader-section section-left"></div>
        <div class="loader-section section-right"></div>
      </div>
    </div>
  </form>
</template>

<script>
/* eslint-disable no-undef */
import router from "../../router/index";
import UseGetWeatherForecast from "../../hooks/GetForecast";
import UseValidation from "../../hooks/ValidateForm";

import { onMounted, ref, watch } from "vue";
import { Loader } from "@googlemaps/js-api-loader";

export default {
  setup() {
    //constants
    const [GetWeatherForecastByCityOrZipCode] = UseGetWeatherForecast();
    const GERMANY_BOUNDS = {
      north: 55.0815,
      south: 47.2701115,
      west: 5.8663425,
      east: 15.0418962,
    };
    const coordinates = ref({ latitude: 52.52, longitude: 13.405 }); //berlin
    const loader = new Loader({
      apiKey: "AIzaSyBp9d2lf5YgZzGzgz_euqF48x6H9JUA3GI",
      libraries: ["places"],
    });
    const isValid = ref(true);

    //fields
    const city = ref("");
    const zipcode = ref("");
    const mapDiv = ref(null);

    //loading style
    const isLoading = ref(false);

    //mounted event - loadmap and autocomplete
    onMounted(() => {
      loader
        .load()
        .then((google) => {
          new google.maps.Map(mapDiv.value, {
            center: {
              lat: coordinates.value.latitude,
              lng: coordinates.value.longitude,
            },
            zoom: 6,
            restriction: {
              latLngBounds: GERMANY_BOUNDS,
              strictBounds: false,
            },
          });
          new google.maps.places.Autocomplete(
            document.getElementById("googleAutoComplete"),
            {
              restriction: {
                latLngBounds: GERMANY_BOUNDS,
                strictBounds: false,
              },
            }
          );
        })
        .catch((e) => {
          console.log(e);
        });
    });

    const ValidateAndLoadData = async () => {
      const validity = await UseValidation(city.value, zipcode.value);
      isValid.value = validity;
      if (isValid.value) {
        isLoading.value = true;
        setTimeout(() => (isLoading.value = false), 3000);
        await GetWeatherForecastByCityOrZipCode(city.value, zipcode.value);
        router.push("/");
      }
    };

    //to update if auto-complete is selected
    const updateText = (event) => {
      event.target.focus();
      city.value = event.target.value;
    };

    //watchers
    watch(isValid, function () {
      console.log(isValid.value);
    });
    watch(isLoading, function () {
      console.log(isLoading.value);
    });

    return {
      city,
      zipcode,
      coordinates,
      mapDiv,
      GetWeatherForecastByCityOrZipCode,
      isValid,
      ValidateAndLoadData,
      updateText,
      isLoading,
    };
  },
};
</script>
<style scoped>
input[type="text"] {
  border: 2px solid black;
  border-radius: 4px;
}

.add-left-padding {
  padding-left: 1%;
}
#loader-wrapper {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  z-index: 1000;
}

#loader {
  position: relative;
  left: 50%;
  top: 50%;
  width: 100px;
  height: 100px;
  margin: -75px 0 0 -75px;
  border-radius: 50%;
  border: 3px solid transparent;
  border-top-color: #3498db;

  -webkit-animation: spin 2s linear infinite; /* Chrome, Opera 15+, Safari 5+ */
  animation: spin 2s linear infinite; /* Chrome, Firefox 16+, IE 10+, Opera */

  z-index: 1001;
}

#loader:before {
  content: "";
  position: absolute;
  top: 5px;
  left: 5px;
  right: 5px;
  bottom: 5px;
  border-radius: 50%;
  border: 3px solid transparent;
  border-top-color: #e74c3c;

  -webkit-animation: spin 3s linear infinite; /* Chrome, Opera 15+, Safari 5+ */
  animation: spin 3s linear infinite; /* Chrome, Firefox 16+, IE 10+, Opera */
}

#loader:after {
  content: "";
  position: absolute;
  top: 15px;
  left: 15px;
  right: 15px;
  bottom: 15px;
  border-radius: 50%;
  border: 3px solid transparent;
  border-top-color: #f9c922;

  -webkit-animation: spin 1.5s linear infinite; /* Chrome, Opera 15+, Safari 5+ */
  animation: spin 1.5s linear infinite; /* Chrome, Firefox 16+, IE 10+, Opera */
}

@-webkit-keyframes spin {
  0% {
    -webkit-transform: rotate(0deg); /* Chrome, Opera 15+, Safari 3.1+ */
    -ms-transform: rotate(0deg); /* IE 9 */
    transform: rotate(0deg); /* Firefox 16+, IE 10+, Opera */
  }
  100% {
    -webkit-transform: rotate(360deg); /* Chrome, Opera 15+, Safari 3.1+ */
    -ms-transform: rotate(360deg); /* IE 9 */
    transform: rotate(360deg); /* Firefox 16+, IE 10+, Opera */
  }
}
@keyframes spin {
  0% {
    -webkit-transform: rotate(0deg); /* Chrome, Opera 15+, Safari 3.1+ */
    -ms-transform: rotate(0deg); /* IE 9 */
    transform: rotate(0deg); /* Firefox 16+, IE 10+, Opera */
  }
  100% {
    -webkit-transform: rotate(360deg); /* Chrome, Opera 15+, Safari 3.1+ */
    -ms-transform: rotate(360deg); /* IE 9 */
    transform: rotate(360deg); /* Firefox 16+, IE 10+, Opera */
  }
}

#loader-wrapper .loader-section {
  position: fixed;
  top: 0;
  width: 51%;
  height: 100%;
  z-index: 1000;
  -webkit-transform: translateX(0); /* Chrome, Opera 15+, Safari 3.1+ */
  -ms-transform: translateX(0); /* IE 9 */
  transform: translateX(0); /* Firefox 16+, IE 10+, Opera */
}

#loader-wrapper .loader-section.section-left {
  left: 0;
}

#loader-wrapper .loader-section.section-right {
  right: 0;
}

/* Loaded */
.loaded #loader-wrapper .loader-section.section-left {
  -webkit-transform: translateX(-100%); /* Chrome, Opera 15+, Safari 3.1+ */
  -ms-transform: translateX(-100%); /* IE 9 */
  transform: translateX(-100%); /* Firefox 16+, IE 10+, Opera */

  -webkit-transition: all 0.7s 0.3s cubic-bezier(0.645, 0.045, 0.355, 1);
  transition: all 0.7s 0.3s cubic-bezier(0.645, 0.045, 0.355, 1);
}

.loaded #loader-wrapper .loader-section.section-right {
  -webkit-transform: translateX(100%); /* Chrome, Opera 15+, Safari 3.1+ */
  -ms-transform: translateX(100%); /* IE 9 */
  transform: translateX(100%); /* Firefox 16+, IE 10+, Opera */

  -webkit-transition: all 0.7s 0.3s cubic-bezier(0.645, 0.045, 0.355, 1);
  transition: all 0.7s 0.3s cubic-bezier(0.645, 0.045, 0.355, 1);
}

.loaded #loader {
  opacity: 0;
  -webkit-transition: all 0.3s ease-out;
  transition: all 0.3s ease-out;
}
.loaded #loader-wrapper {
  visibility: hidden;

  -webkit-transform: translateY(-100%); /* Chrome, Opera 15+, Safari 3.1+ */
  -ms-transform: translateY(-100%); /* IE 9 */
  transform: translateY(-100%); /* Firefox 16+, IE 10+, Opera */

  -webkit-transition: all 0.3s 1s ease-out;
  transition: all 0.3s 1s ease-out;
}
.add-top-padding {
  padding-top: 1%;
}
</style>
