<template>
  <div class="background-image">
    <div class="container background-panel">
      <div class="main-container">
        <div style="position: relative; z-index: 2">
          <div class="centered-div">
            <h1 class="h1-style">500</h1>
            <h2 class="h2-style">Connection Lost</h2>
            <p class="p-style">
              The site is experiencing Technical Difficulties. We are working
              hard to try and resolve the issue.
            </p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<style scoped>
.centered-div {
  max-width: 767px;
  width: 100%;
  line-height: 1;
  padding: 0px 15px;
  text-align: center;
  background-image: url("../../assets/clouds.png");
  background-position: cover;
}
.main-container {
  height: 100%;
  padding: 16%;
}
.h2-style {
  font-family: "Titillium Web", sans-serif;
  font-size: 26px;
  font-weight: 700;
  margin: 10px;
  color: grey;
  text-shadow: 1px 1px black;
}

.p-style {
  font-family: "Montserrat", sans-serif;
  font-size: 14px;
  font-weight: 500;
  margin: 20px;
  text-transform: uppercase;
  color: white;
  text-shadow: 1px 1px black;
}

.h1-style {
  font-family: "Titillium Web", sans-serif;
  font-size: 120px;
  font-weight: 900;
  color: grey;
  text-shadow: -4px 0 0 #fff;
  margin: 0;
  text-transform: uppercase;
  z-index: 2;
}
</style>
