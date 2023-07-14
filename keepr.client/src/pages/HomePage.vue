<template>

import KeepForm from '../components/KeepForm.vue.js';
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="home-card p-5 bg-white rounded elevation-3">
      <img src="https://bcw.blob.core.windows.net/public/img/8600856373152463" alt="CodeWorks Logo"
        class="rounded-circle">
      <h1 class="my-5 bg-dark text-white p-3 rounded text-center">
        Vue 3 Starter Keep

      </h1>
    </div>
  </div>
  <section class="container-fluid d-flex justify-content-center">
    <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#createKeepModal" aria-controls="createKeepModal">
      Create Keep
    </button>
    <Modal id="createKeepModal">
      <KeepForm/>
    </Modal>
  </section>
</template>

<script>
import KeepForm from '../components/KeepForm.vue';
export default {
    setup() {
        return {};
    },
    components: { KeepForm }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
