const ParametersModule = {
  namespaced: true,
  state: {
    weatherParameters: [],
    currentParameters: {
      dateTime: "",
      minTemperature: 0,
      maxTemperature: 0,
      pressure: 0,
      windDegree: 0,
      windGust: 0,
      visibility: 0,
    },
  },
  mutations: {
    setParameters(state, data) {
      state.weatherParameters = [];
      data.map((x) => {
        state.weatherParameters.push({
          date: x[0].currentDate,
          details: x.map((y) => {
            return {
              dateTime: y.currentDate,
              minTemperature: y.minTemperature,
              maxTemperature: y.maxTemperature,
              pressure: y.pressure,
              windDegree: y.windDegree,
              windGust: y.windGust,
              visibility: y.visibility,
            };
          }),
        });
      });
      state.currentParameters = state.weatherParameters[0].details[0];
      console.log(state.currentParameters);
    },
  },
  actions: {
    setParameters(context, data) {
      context.commit("setParameters", data);
    },
  },
  getters: {
    getCurrentParameters: (state) => {
      return state.currentParameters;
    },
  },
};
export default ParametersModule;
