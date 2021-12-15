<template>
  <div class="align-right">
    <div>
      <p>
        <button
          class="btn btn-outline-light btn-sm"
          type="submit"
          @click="ToggleHistoryTable()"
        >
          View Search History
        </button>
      </p>
      <div v-show="isHistoryVisible">
        <table class="table text-white table-sm">
          <thead>
            <tr>
              <th scope="col">City</th>
              <th scope="col">Temperature</th>
              <th scope="col">Humidity</th>
              <th scope="col">Last Accessed</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="data in historyData" :key="data.id">
              <!-- <tr v-if="historyData != null"> -->
              <td>{{ data.city }}</td>
              <td>{{ data.temperature }}</td>
              <td>{{ data.humidity }}</td>
              <td>{{ data.accessedDateTime }}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>
<script>
import UseGetHistory from "../../hooks/GetHistory";
export default {
  async beforeCreate() {
    const [history, GetHistory] = UseGetHistory();
    await GetHistory();
    this.historyData = history;
  },
  data() {
    return {
      isHistoryVisible: false,
      historyData: [],
    };
  },

  methods: {
    ToggleHistoryTable() {
      this.isHistoryVisible = !this.isHistoryVisible;
    },
  },
};
</script>
