/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./MyMoney/**/*.{razor,html,cshtml}",
    "./MyMoney.Client/**/*.{razor,html,cshtml}",
    "./MyMoney/wwwroot/**/*.js"
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}