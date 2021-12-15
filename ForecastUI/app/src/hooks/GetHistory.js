import axios from "axios";
import { ref } from "vue";
import { useStore } from "vuex";

export default function UseGetHistory() {
  const store = useStore();
  const history = ref(null);
  axios.defaults.headers.common["Access-Control-Allow-Origin"] = "*";
  async function GetHistory() {
    //get user history
    let userKey = store.getters["getUser"];
    let url = "http://localhost:8080/api/GetHistory?userKey=" + userKey;
    await fetch(url)
      .then((response) => {
        if (response.status == 200) return response.json();
      })
      .then((data) => {
        history.value = data;
      })
      .catch((err) => {
        console.log(err);
      });
  }

  return [history, GetHistory];
}
