<template>
  <div class="max-w-4xl mx-auto mt-6">
    <ul class="space-y-3">
      <li v-for="book in books" :key="book.id" class="p-4 bg-white rounded shadow flex justify-between items-center">
        <div>
          <p class="font-semibold">{{ book.title }}</p>
          <p class="text-gray-600">{{ book.author }}</p>
          <p class="text-gray-800">{{ book.price }} Ft</p>
        </div>
        <button @click="deleteBook(book.id)" class="bg-gray-800 text-white px-3 py-1 rounded hover:bg-red-600">
          Törlés
        </button>
      </li>
    </ul>
  </div>
</template>

<script>
import axios from "axios";

export default {
  props: ["books"],
  emits: ["deleted"],
  setup(props, { emit }) {
    const API_URL = "https://localhost:7216/api/books";

    const deleteBook = async (id) => {
      try {
        await axios.delete(`${API_URL}/${id}`);
        emit("deleted");
      } catch (err) {
        console.error(err);
      }
    };

    return { deleteBook };
  }
};
</script>
