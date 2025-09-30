import axios from "axios";

// Use your Fly.io API endpoint
const API_URL = "https://library-api-erica.fly.dev/api";

export const addBook = async () => {
    return axios.post(`${API_URL}/book`, {
        id: crypto.randomUUID(),
        title: "New Book",
        pages: 100,
        genreId: null
    });
};

export const deleteBook = async (id: string) => {
    return axios.delete(`${API_URL}/book/${id}`);
};

export const getAuthors = async () => {
    return axios.get(`${API_URL}/author`);
};
