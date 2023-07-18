<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <link
    rel="stylesheet"
    href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css"
  />
  <footer class="bg-dark text-light">
    Made by Chantha 🫡
  </footer>
</template>

<script>
import masonry from 'masonry-layout';
import { computed, onMounted } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import { keepsService } from './services/KeepsService.js'
import Pop from './utils/Pop.js'

export default {
  setup() {
    async function getAllKeeps() {
      try {
        keepsService.getAllKeeps()
      } catch (e){
        Pop.error(e);
      }
    }

    onMounted(() => {
      getAllKeeps();
    })

    return {
      appState: computed(() => AppState),
      account: computed(() => AppState.account)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

main{
  background-color: rgb(21, 21, 21);
}
:root{
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
