import { useStore } from "vuex";

export default function UseGetForecast() {
  //get forecast
  const store = useStore();
  //create guid for user - if not already initialized
  function CreateGuid() {
    function _p8(s) {
      var p = (Math.random().toString(16) + "000000000").substr(2, 8);
      return s ? "-" + p.substr(0, 4) + "-" + p.substr(4, 4) : p;
    }
    return _p8() + _p8(true) + _p8(true) + _p8();
  }

  async function GetForecastByCityOrZipCode(city, zipcode) {
    let userKey = store.getters["getUser"];
    if (!userKey) {
      userKey = CreateGuid();
      store.dispatch("setUser", userKey);
    }
    let url = "";
    if (city) {
      url =
        "http://localhost:8080/api/GetForecast/GetForecastByCity?city=" +
        city +
        "&userKey=" +
        userKey;
    } else {
      url =
        "http://localhost:8080/api/GetForecast/GetForecastByZipCode?zipCode=" +
        zipcode +
        ",DE" +
        "&userKey=" +
        userKey;
    }

    await fetch(url)
      .then((response) => {
        console.log(response.status);
        if (response.status == 200) {
          return response.json();
        } else {
          console.log(
            "Connection lost, ensure the backend project is running!"
          );
        }
      })
      .then((data) => {
        store.dispatch("setIsDataAvailable", true);
        store.dispatch("CardModule/setWeather", data.weatherData);
        store.dispatch("CardModule/setAverage", data);
        store.dispatch(
          "ParametersModule/setParameters",
          data.weatherParameters
        );
        store.dispatch(
          "AirQualityModule/setAirQualityData",
          data.airQualityData
        );
        store.dispatch("setCity", data.city);
        store.dispatch("setSunrise", data.sunrise);
        store.dispatch("setSunset", data.sunset);
      })
      .catch((err) => {
        console.log(err);
      });
  }

  return [GetForecastByCityOrZipCode];
}
