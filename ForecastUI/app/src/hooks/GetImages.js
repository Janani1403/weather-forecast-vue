export default function UseGetImages(current, description) {
  //get image based on weather
  var main = [
    "Clear",
    "Clouds",
    "Rain",
    "Drizzle",
    "Thunderstorm",
    "Snow",
    "Mist",
    "Smoke",
    "Haze",
    "Dust",
    "Fog",
    "Sand",
    "Ash",
    "Squall",
    "Tornado",
  ];
  var cloudDescription = [
    "few clouds",
    "scattered clouds",
    "broken clouds",
    "overcast clouds",
  ];
  var cloudsImages = [
    "https://c4.wallpaperflare.com/wallpaper/118/387/817/architecture-building-castle-clouds-wallpaper-preview.jpg",
    "https://c4.wallpaperflare.com/wallpaper/485/357/289/lake-germany-forest-summer-wallpaper-preview.jpg",
    "https://c4.wallpaperflare.com/wallpaper/888/136/924/cloud-red-leaves-autumn-red-trees-wallpaper-preview.jpg",
    "https://c4.wallpaperflare.com/wallpaper/903/720/59/architecture-old-building-ancient-montenegro-wallpaper-preview.jpg",
  ];

  var images = [
    "https://c4.wallpaperflare.com/wallpaper/308/513/173/germany-street-street-light-house-wallpaper-preview.jpg",
    "https://c4.wallpaperflare.com/wallpaper/485/357/289/lake-germany-forest-summer-wallpaper-preview.jpg",
    "https://c4.wallpaperflare.com/wallpaper/656/94/521/photography-village-villages-rain-wallpaper-preview.jpg",
    "https://c4.wallpaperflare.com/wallpaper/855/879/641/village-town-houses-roofs-wallpaper-preview.jpg",
    "https://c4.wallpaperflare.com/wallpaper/907/164/930/phenomenon-thunderstorm-lightning-strike-islet-wallpaper-preview.jpg",
    "https://c4.wallpaperflare.com/wallpaper/840/468/36/winter-landmark-tourist-attraction-castle-wallpaper-preview.jpg",
    "https://c4.wallpaperflare.com/wallpaper/952/786/491/nature-landscape-forest-river-wallpaper-preview.jpg",
    "https://c4.wallpaperflare.com/wallpaper/706/809/291/schwarzwald-germany-mountains-smoke-wallpaper-preview.jpg",
    "https://c4.wallpaperflare.com/wallpaper/507/450/443/eltz-castle-germany-medieval-castle-misty-wallpaper-preview.jpg",
    "https://www.wallpaperflare.com/tree-germany-autumn-wood-fog-dust-mmorning-sun-sunray-wallpaper-akxnx",
    "https://c4.wallpaperflare.com/wallpaper/130/100/840/hohenzollern-castle-europe-4k-fog-wallpaper-preview.jpg",
    "https://www.wallpaperflare.com/tree-germany-autumn-wood-fog-dust-mmorning-sun-sunray-wallpaper-akxnx",
    "https://c0.wallpaperflare.com/preview/622/673/301/germany-blaze-glow-fervency.jpg",
    "https://c1.wallpaperflare.com/preview/519/303/705/forward-nature-sky-rain.jpg",
    "https://c1.wallpaperflare.com/preview/761/899/668/aschaffenburg-castle-lower-franconia-bavaria.jpg",
  ];
  var index = main.indexOf(current);
  var image = images[index];
  if (index == 1) {
    image = cloudsImages[cloudDescription.indexOf(description)];
  }
  return image;
}
