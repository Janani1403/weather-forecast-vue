<template>
  <div id="app">
    <transition name="bounce" mode="out-in">
      <div v-if="show">
        <div
          class="card bg-gradient text-primary cardborder"
          style="height: 16vh; width: 100%"
        >
          <div class="card-body">
            <p class="p-aqparamkey fw-bold">{{ data.key }}</p>
            <button
              class="btn btn-sm btn-toggle"
              @click="show = !show"
            ></button>
          </div>
        </div>
      </div>
      <div v-else>
        <div
          class="card bg-gradient text-primary cardborder"
          style="height: 16vh; width: 100%"
        >
          <div class="card-body">
            <p class="p-aqparamvalue fw-bold">{{ data.value }}</p>
            <button
              class="btn btn-sm btn-toggle"
              @click="show = !show"
            ></button>
          </div>
        </div>
      </div>
    </transition>
  </div>
</template>
<script>
export default {
  props: {
    data: {
      required: true,
    },
  },

  data() {
    return {
      show: true,
    };
  },
};
</script>
<style scoped>
.bounce-enter-active {
  animation: bounce-in 0.5s;
}
.bounce-leave-active {
  animation: bounce-in 0.5s reverse;
}
@keyframes bounce-in {
  0% {
    transform: scale(0);
  }
  50% {
    transform: scale(1.25);
  }
  100% {
    transform: scale(1);
  }
}

.bottom {
  position: absolute;
  padding-bottom: 0;
}
.cardborder {
  border: 1px solid grey;
}
.p-aqparamkey {
  color: white;
  font-size: 24px;
  text-align: center;
  text-shadow: 1px 1px black;
  margin-top: 0;
  margin-bottom: 0;
}
.p-aqparamvalue {
  color: grey;
  font-size: 24px;
  text-align: center;
  text-shadow: 1px 1px black;
  margin-top: 0;
  margin-bottom: 0;
}
.bg-gradient {
  background: linear-gradient(grey, black);
}
.btn-toggle {
  position: absolute;
  height: 20px;
  width: 20px;
  right: 0;
  bottom: 0;
  border: 0;
  background: #f0f0f0 url("../../assets/turnjpg.jpg");
  background-size: contain;
  background-repeat: no-repeat;
}
</style>
