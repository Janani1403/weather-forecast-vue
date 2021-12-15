export default function UseGetQuote() {
  //To get quote
  const quotes = [
    "Wherever you go, no matter what the weather, always bring your own sunshine.",
    "Sunshine is delicious, rain is refreshing, wind braces us up, snow is exhilarating; there is really no such thing as bad weather, only different kinds of good weather.",
    "The autumn wind is a pirate. Blustering in from sea with a rollicking song he sweeps along swaggering boisterously. His face is weather beaten, he wears a hooded sash with a silver hat about his head... The autumn wind is a Raider, pillaging just for fun.",
    "Nature is so powerful, so strong. Capturing its essence is not easy - your work becomes a dance with light and the weather. It takes you to a place within yourself.",
    "I inherited that calm from my father, who was a farmer. You sow, you wait for good or bad weather, you harvest, but working is something you always need to do.",
    "Climate change is sometimes misunderstood as being about changes in the weather. In reality it is about changes in our very way of life.",
    "For the man sound of body and serene of mind there is no such thing as bad weather; every day has its beauty, and storms which whip the blood do but make it pulse more vigorously.",
    "You are the sky. Everything else – it’s just the weather.",
    "When all is said and done, the weather and love are the two elements about which one can never be sure.",
    "Solitude is the soil in which genius is planted, creativity grows, and legends bloom; faith in oneself is the rain that cultivates a background-panel to endure the storm, and bare the genesis of a new world, a new forest.",
  ];
  const authors = [
    "Anthony J D'Angelo",
    "John Ruskin",
    "Steve Sabol",
    "Annie Leibovitz",
    "Miguel Indurain",
    "Paul Polman",
    "George Gissing",
    "Pema Chödrön",
    "Alice Hoffman",
    "Mike Norton",
  ];

  const randomNumber = Math.ceil(Math.random() * 10);
  const tip = quotes[randomNumber - 1];
  const author = authors[randomNumber - 1];
  return { tip, author };
}
