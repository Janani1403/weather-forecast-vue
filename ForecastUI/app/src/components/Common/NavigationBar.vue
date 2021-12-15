<template>
  <nav
    class="
      navbar navbar-expand-lg navbar-dark
      bg-dark
      justify-content:
      space-between
    "
  >
    <div class="collapse navbar-collapse justify-content-center" id="navbarNav">
      <p class="remove-bottom-padding">
        You are viewing the weather report for {{ city }}
      </p>
      <div class="add-left-padding">
        <button
          class="btn btn-sm btn-outline-light"
          @click="SelectLocationClick"
        >
          Change Location
        </button>
      </div>
    </div>
  </nav>
</template>
<script>
import router from "../../router/index";
export default {
  props: ["city"],
  setup() {
    const SelectLocationClick = () => {
      router.push("/select");
    };
    return { SelectLocationClick };
  },
};
</script>
<style scoped>
.add-left-padding {
  padding-left: 2%;
}
.remove-bottom-padding {
  margin-top: 0;
  margin-bottom: 0;
  font-size: 15px;
  color: white;
  text-shadow: 1px 1px black;
}
</style>
