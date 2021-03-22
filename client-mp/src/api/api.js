import axios from "axios";

//* Komponeta pro nastavení základní konfigurace pro axios a vytvření instance
export default axios.create({
  baseURL: "https://localhost:44360/api",
});
(function () {
  let authToken = sessionStorage.getItem("JWT");
  if (authToken === null) {
  } else {
    axios.defaults.headers.common.Authorization = `Bearer ${authToken}`;
    axios.defaults.headers.common.ContentType = "application/json";
  }
})();
