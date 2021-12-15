module.exports = {
  devServer: {
    proxy: "https://localhost:7166/",
    disableHostCheck: true,
    port: 8080,
    public: "0.0.0.0:8080",
  },
  publicPath: "/",
};
