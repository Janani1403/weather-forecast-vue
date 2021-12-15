import { createStore } from "vuex";
import createPersistedState from "vuex-persistedstate";
import AirQualityModule from "./Modules/AirQualityStore";
import CardModule from "./Modules/CardStore";
import ParametersModule from "./Modules/ParametersStore";
export default createStore({
  state: {
    city: "",
    sunrise: "",
    sunset: "",
    user: "",
    isWindowResized: false,
    isDataAvailable: false,
  },
  mutations: {
    setCity(state, value) {
      state.city = value;
    },
    setSunrise(state, value) {
      state.sunrise = value;
    },
    setSunset(state, value) {
      state.sunset = value;
    },
    setUser(state, value) {
      state.user = value;
    },
    setIsWindowResized(state, value) {
      state.isWindowResized = value;
    },
    setIsDataAvailable(state, value) {
      state.isDataAvailable = value;
    },
  },
  actions: {
    setCity(context, value) {
      context.commit("setCity", value);
    },
    setSunrise(context, value) {
      context.commit("setSunrise", value);
    },
    setSunset(context, value) {
      context.commit("setSunset", value);
    },
    setUser(context, value) {
      context.commit("setUser", value);
    },
    setIsWindowResized(context, value) {
      context.commit("setIsWindowResized", value);
    },
    setIsDataAvailable(context, value) {
      context.commit("setIsDataAvailable", value);
    },
  },
  getters: {
    getCity: (state) => {
      return state.city;
    },
    getSunrise: (state) => {
      return state.sunrise;
    },
    getSunset: (state) => {
      return state.sunset;
    },
    getUser: (state) => {
      return state.user;
    },
    getIsWindowResized: (state) => {
      return state.isWindowResized;
    },
    getIsDataAvailable: (state) => {
      return state.isDataAvailable;
    },
  },
  modules: { CardModule, ParametersModule, AirQualityModule },
  plugins: [createPersistedState()],
});
