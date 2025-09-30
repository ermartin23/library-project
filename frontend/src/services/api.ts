// frontend/src/services/api.ts
import axios from "axios";

// Base URL of your deployed API (Fly.io or local)
const API_BASE = "https://library-api-erica.fly.dev/api";

export const getBooks = async () => {
    const response = await axios.get(`${API_BASE}/book`);
    return response.data;
};

export const getAuthors = async () => {
    const response = await axios.get(`${API_BASE}/author`);
    return response.data;
};

export const getGenres = async () => {
    const response = await axios.get(`${API_BASE}/genre`);
    return response.data;
};
