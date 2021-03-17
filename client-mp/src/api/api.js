import axios from "axios";
import { useAppContext } from "../providers/ApplicationProvider";

export default axios.create({
  baseURL: "https://localhost:44360/api",
});
axios.interceptors.request.use(function (config) {
  const [{ accessToken }] = useAppContext();
  const token = accessToken;
  config.headers.Authorization = token;

  return config;
});
