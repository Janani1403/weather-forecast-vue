const AirQualityModule = {
  namespaced: true,
  state: {
    airQualityParameters: {
      AQI: 0,
      O3: 0,
      CO: 0,
      NO2: 0,
      PM10: 0,
    },
    airQualityInfo: {
      AQIData: "",
      O3Data: "",
      COData: "",
      NO2Data: "",
      PM10: "",
    },
  },
  mutations: {
    setAirQualityData(state, data) {
      state.airQualityParameters = data;
    },
  },
  actions: {
    setAirQualityData(context, data) {
      context.commit("setAirQualityData", data);
    },
  },
  getters: {
    getAirQualityData: (state) => {
      return state.airQualityParameters;
    },
  },
};
export default AirQualityModule;
