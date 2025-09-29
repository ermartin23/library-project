import axios from "axios";

const api = axios.create({
    baseURL: "http://localhost:5123/api", 
});

export default api;
