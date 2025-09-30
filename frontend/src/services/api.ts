// frontend/src/services/api.ts
import axios from "axios";

const API_BASE =
    import.meta.env.VITE_API_URL ??
    (location.hostname === "localhost"
        ? "http://localhost:5084/api"
        : "https://library-api-erica.fly.dev/api");

const api = axios.create({ baseURL: API_BASE });

export const getBooks = async () => {
    const { data } = await api.get("/Book");
    return data;
};

export const getAuthors = async () => {
    const { data } = await api.get("/Author");
    return data;
};
