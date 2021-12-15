<template>
  <div class="row justify-content-md-center div-quote" style="">
    <div class="col col-sm-12" style="padding-top: 15px">
      <h4 class="h-title">QUOTE OF THE DAY:</h4>
      <p class="p-quote">
        {{ tip }}
      </p>
      <p class="p-author">
        {{ author }}
      </p>
    </div>
  </div>
</template>
<script>
import UseGetQuote from "../../hooks/GetQuote";
export default {
  setup() {
    const { tip, author } = UseGetQuote();
    return { tip, author };
  },
};
</script>
<style scoped>
.p-quote {
  font-family: Arial, Helvetica, sans-serif;
  font-size: 14px;
  color: white;
  text-shadow: 1px 1px black;
  padding-bottom: 0%;
}
.p-author {
  /* font-family: cursive; */
  font-family: Arial, Helvetica, sans-serif;
  font-style: italic;
  font-size: 15px;
  color: white;
  text-shadow: 1px 1px black;
  padding-bottom: 0%;
}
.h-title {
  /* font-family: cursive; */
  font-family: Arial, Helvetica, sans-serif;
  font-style: bold;
  font-size: 15px;
  color: white;
  text-shadow: 1px 1px grey;
  padding-bottom: 0%;
}
.div-quote {
  padding-left: 50px;
}
</style>
