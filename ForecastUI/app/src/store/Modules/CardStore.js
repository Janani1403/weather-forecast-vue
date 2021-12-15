const CardModule = {
  namespaced: true,
  state: {
    dateIndex: 0,
    timeIndex: 0,
    days: ["SUN", "MON", "TUE", "WED", "THU", "FRI", "SAT"],
    weather: [],
    average: [],
    current: {},
  },
  mutations: {
    setWeather(state, data) {
      state.weather = [];
      data.map((x) => {
        state.weather.push({
          date: x[0].currentDate,
          details: x.map((y) => {
            return {
              dateTime: y.currentDate,
              weatherMain: y.weatherMain,
              weatherDescription: y.weatherDescription,
              temperature: y.temperature,
              humidity: y.humidity,
              windSpeed: y.windSpeed,
            };
          }),
        });
      });
      state.current = state.weather[0].details[0];
      state.dateIndex = 0;
      state.timeIndex = 0;
    },
    setAverage(state, data) {
      state.average = [];
      var date = new Date();
      for (let iC = 0; iC < 5; iC++) {
        state.average.push({
          day: state.days[date.getDay()],
          averageHumidity: data.averageHumidity[iC],
          averageTemperature: data.averageTemperature[iC],
        });
        date.setDate(date.getDate() + 1);
      }
      state.average[0].day += " (Today)";
    },
    setCurrent(state, index) {
      state.current = state.weather[index].details[0];
      state.dateIndex = index;
    },
    setCurrentIndex(state) {
      state.timeIndex += 1;
      state.current = state.weather[0].details[state.timeIndex];
    },
  },
  actions: {
    setWeather(context, data) {
      context.commit("setWeather", data);
    },
    setAverage(context, data) {
      context.commit("setAverage", data);
    },
    setCurrent(context, index) {
      context.commit("setCurrent", index);
    },
    setCurrentIndex(context) {
      context.commit("setCurrentIndex");
    },
  },
  getters: {
    getCount: (state) => {
      return state.weather.length;
    },

    getWeather: (state) => {
      return state.weather[state.dateIndex].details;
    },
    getTimeIntervals: (state) => {
      var temp = state.weather[state.dateIndex].details.map((x) => {
        return new Date(x.dateTime).toLocaleTimeString();
      });
      return temp;
    },
    getCurrent: (state) => {
      return state.current;
    },

    getAverage: (state) => {
      return state.average;
    },
    getDateIndex: (state) => {
      return state.dateIndex;
    },
  },
};
export default CardModule;
