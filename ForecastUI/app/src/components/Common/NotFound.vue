<template>
  <div class="background-image">
    <div class="container background-panel">
      <div class="main-container">
        <div style="position: relative; z-index: 2">
          <div class="centered-div">
            <h1 class="h1-style">404</h1>
            <h2 class="h2-style">Oops! This Page Could Not Be Found</h2>
            <p class="p-style">
              Sorry but the page you are looking for does not exist, have been
              removed, name changed or is temporarily unavailable.
            </p>

            <a class="a-redirect" href="http://localhost:8080/">Home</a>
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
  padding: 14%;
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
.a-redirect {
  font-family: "Titillium Web", sans-serif;
  display: inline-block;
  text-transform: uppercase;
  color: #fff;
  text-decoration: none;
  border: none;
  background: linear-gradient(grey, black);
  padding: 10px 40px;
  font-size: 14px;
  font-weight: 700;
  border-radius: 1px;
  margin: 15px;
  transition: 0.2s all;
}
.a-redirect:hover {
  opacity: 0.8;
}
</style>
