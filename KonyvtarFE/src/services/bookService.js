import axios from "axios";

const API_URL = "https://localhost:7216/api/books";

export async function getBooks() {
  return axios.get(API_URL);
}

export async function createBook(book) {
  return axios.post(API_URL, book);
}

export async function updatePrice(id, price) {
  return axios.patch(`${API_URL}/${id}/price`, { price });
}

export async function deleteBook(id) {
  return axios.delete(`${API_URL}/${id}`);
}
