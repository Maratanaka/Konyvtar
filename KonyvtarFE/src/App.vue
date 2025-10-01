<template>
  <div class="min-h-screen bg-sky-200">
    <!-- Navbar -->
    <Navbar />

    <main class="max-w-6xl mx-auto p-4 mt-6">
      <h1 class="text-3xl font-bold text-center mb-6 text-gray-800">Könyvtár</h1>

      <!-- Flex konténer: mobilon egymás alatt, md felett egymás mellett -->
      <div class="flex flex-col md:flex-row gap-6 md:items-start">

        <!-- Bal oldali oszlop: kereső + form -->
        <div class="md:w-1/3 flex flex-col gap-4">
          <!-- Kereső -->
<div class="bg-white p-4 rounded shadow-md">
  <h2 class="text-lg font-semibold mb-2 text-gray-800">Keresés szerző alapján</h2>
  <div class="flex flex-col md:flex-row gap-2">
    <input
      v-model="searchAuthor"
      type="text"
      placeholder="Szerző neve"
      class="flex-1 border border-gray-300 rounded px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-400"
    />
    <button
      @click="searchBooks"
      class="bg-yellow-600 text-white px-4 py-2 rounded hover:bg-yellow-700 transition"
    >
      Keresés
    </button>
  </div>
</div>


          <!-- BookForm -->
          <div class="bg-white p-4 rounded shadow-md">
            <BookForm @added="loadBooks" />
          </div>
        </div>

        <!-- Jobb oldali oszlop: lista -->
        <div class="md:w-2/3 min-w-0">
          <BookList :books="books" @deleted="loadBooks" />
        </div>
      </div>
    </main>
  </div>
</template>


<script>
import { ref, onMounted } from "vue";
import axios from "axios";
import BookList from "./components/BookList.vue";
import BookForm from "./components/BookForm.vue";
import Navbar from "./components/Navbar.vue";

export default {
  components: { BookList, BookForm, Navbar },
  setup() {
    const books = ref([]);
    const searchAuthor = ref("");
    const API_URL = "https://localhost:7216/api/books";

    const loadBooks = async () => {
      try {
        const res = await axios.get(API_URL);
        books.value = res.data;
      } catch (err) {
        console.error(err);
      }
    };

    const searchBooks = async () => {
      if (!searchAuthor.value) {
        // Ha nincs keresőszó, töltsük vissza az összes könyvet
        loadBooks();
        return;
      }

      try {
        const res = await axios.get(`${API_URL}/search/${encodeURIComponent(searchAuthor.value)}`);
        books.value = res.data;
      } catch (err) {
        console.error(err);
      }
    };

    onMounted(loadBooks);

    return { books, loadBooks, searchAuthor, searchBooks };
  },
};
</script>
