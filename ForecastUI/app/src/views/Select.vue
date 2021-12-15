<template>
  <div class="background-image">
    <div class="container background-panel p-2">
      <div style="position: relative; z-index: 2">
        <google-map></google-map>
        <div>
          <p class="copyright">
            &copy; AppsFactory Widget - All Rights Reserved | Designed by Janani
          </p>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import GoogleMap from "../components/Select/GoogleMap.vue";
export default {
  components: { GoogleMap },
};
</script>
