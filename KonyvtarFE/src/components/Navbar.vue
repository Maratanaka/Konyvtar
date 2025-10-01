<template>
  <nav class="bg-yellow-600 text-white shadow-md ">
    <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
      <div class="flex justify-between h-16 items-center">
        <!-- Logo -->
        <div class="flex-shrink-0">
          <a href="#" class="font-bold text-xl">Könyvtár</a>
        </div>

        <!-- Menü -->
        <div class="hidden md:flex space-x-4">
          <a href="#" class="px-3 py-2 rounded hover:bg-yellow-700 transition">Kezdőlap</a>
          <a href="#" class="px-3 py-2 rounded hover:bg-yellow-700 transition">Könyvek</a>
          <a href="#" class="px-3 py-2 rounded hover:bg-yellow-700 transition">Hozzáadás</a>
        </div>

        <!-- Mobil menü ikon (opcionális) -->
        <div class="md:hidden">
          <button @click="toggleMenu" class="focus:outline-none">
            <svg class="h-6 w-6" fill="none" stroke="currentColor" stroke-width="2"
                 viewBox="0 0 24 24" stroke-linecap="round" stroke-linejoin="round">
              <path v-if="!menuOpen" d="M4 6h16M4 12h16M4 18h16"/>
              <path v-else d="M6 18L18 6M6 6l12 12"/>
            </svg>
          </button>
        </div>
      </div>
    </div>

    <!-- Mobil menü -->
    <div v-if="menuOpen" class="md:hidden bg-yellow-600">
      <a href="#" class="block px-4 py-2 hover:bg-yellow-700 transition">Kezdőlap</a>
      <a href="#" class="block px-4 py-2 hover:bg-yellow-700 transition">Könyvek</a>
      <a href="#" class="block px-4 py-2 hover:bg-yellow-700 transition">Hozzáadás</a>
    </div>
  </nav>
</template>

<script>
import { ref } from "vue";

export default {
  setup() {
    const menuOpen = ref(false);
    const toggleMenu = () => {
      menuOpen.value = !menuOpen.value;
    };

    return { menuOpen, toggleMenu };
  },
};
</script>

<style scoped>
/* opcionális finomhangolások */
</style>
