<template>
  <div class="max-w-md mx-auto p-4 mb-8 bg-white rounded shadow">
    <h2 class="text-xl text-gray-800 font-bold mb-4">Új könyv hozzáadása</h2>
    <form @submit.prevent="addBook" class="space-y-3">
      <input v-model="title" placeholder="Cím" required class="w-full border rounded px-3 py-2" />
      <input v-model="author" placeholder="Szerző" required class="w-full border rounded px-3 py-2" />
      <input v-model="isbn" placeholder="ISBN (13 karakter)" required class="w-full border rounded px-3 py-2" />
      <input v-model.number="year" type="number" placeholder="Kiadás éve" required class="w-full border rounded px-3 py-2" />
      <input v-model.number="price" type="number" step="0.01" placeholder="Ár" required class="w-full border rounded px-3 py-2" />
      <button type="submit" class="w-full bg-yellow-600 text-white py-2 rounded hover:bg-yellow-800 transition">
        Hozzáadás
      </button>
    </form>
  </div>
</template>

<script>
import { ref } from "vue";
import axios from "axios";

export default {
  emits: ["added"],
  setup(_, { emit }) {
    const title = ref("");
    const author = ref("");
    const isbn = ref("");
    const year = ref(new Date().getFullYear());
    const price = ref(0);

    const API_URL = "https://localhost:7216/api/books";

    const addBook = async () => {
      try {
        await axios.post(API_URL, {
          title: title.value,
          author: author.value,
          isbn: isbn.value,
          publishedYear: year.value,
          price: price.value
        });
        title.value = "";
        author.value = "";
        isbn.value = "";
        year.value = new Date().getFullYear();
        price.value = 0;
        emit("added");
      } catch (err) {
        console.error(err);
        alert("Hiba: " + err.response?.data?.title || err.message);
      }
    };

    return { title, author, isbn, year, price, addBook };
  }
};
</script>
