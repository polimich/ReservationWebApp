import axios from "axios";

export default axios.create({
  baseURL: "https://localhost:44360/api",
});
(function () {
  let authToken = sessionStorage.getItem("JWT");
  if (authToken === null) {
  } else {
    axios.defaults.headers.common.Authorization = `${authToken}`;
    axios.defaults.headers.common.ContentType = "application/json";
  }
})();
