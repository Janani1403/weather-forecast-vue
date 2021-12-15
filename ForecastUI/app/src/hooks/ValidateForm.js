import axios from "axios";

export default async function UseValidation(city, zipcode) {
  //Validate form input
  let validity = true;
  axios.defaults.headers.common["Access-Control-Allow-Origin"] = "*";

  if (city || zipcode) {
    let url =
      "https://maps.googleapis.com/maps/api/geocode/json?key=AIzaSyBp9d2lf5YgZzGzgz_euqF48x6H9JUA3GI&address=";
    if (city) {
      url += city;
      //confirm coordinates with url
      await fetch(url)
        .then((response) => response.json())
        .then((data) => {
          console.log(data.results[0].formatted_address.includes("Germany"));
          if (!data.results[0].formatted_address.includes("Germany"))
            validity = false;
        })
        .catch((err) => {
          console.log(err);
          validity = false;
        });
    }
  } else {
    validity = false;
  }

  return validity;
}
