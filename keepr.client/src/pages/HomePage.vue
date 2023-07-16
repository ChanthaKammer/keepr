<template>
  <!-- <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="home-card p-5 bg-white rounded elevation-3">
      <img src="https://bcw.blob.core.windows.net/public/img/8600856373152463" alt="CodeWorks Logo"
        class="rounded-circle">
      <h1 class="my-5 bg-dark text-white p-3 rounded text-center">
import VaultForm from '../components/VaultForm.vue.js';
        Vue 3 Starter Keep
      </h1>
import AccountForm from '../components/AccountForm.vue.js';
    </div>
  </div> -->
  <h1 class="f-inter">Inter</h1>
  <h1 class="f-roboto">Roboto</h1>
  <section class="container-fluid d-flex justify-content-center mt-2">
    <button type="button" class="btn btn-primary elevation-5" data-bs-toggle="modal" data-bs-target="#createKeepModal" aria-controls="createKeepModal">
      Create Keep
    </button>
    <Modal id="createKeepModal">
      <KeepForm/>
    </Modal>
  </section>
  <section class="container-fluid d-flex justify-content-center mt-2">
    <button type="button" class="btn btn-primary elevation-5" data-bs-toggle="modal" data-bs-target="#createVaultModal" aria-controls="createVaultModal">
      Create Vault
    </button>
    <Modal id="createVaultModal">
      <VaultForm/>
    </Modal>
  </section>
  <section class="container-fluid d-flex justify-content-center mt-2">
    <button type="button" class="btn btn-primary elevation-5" data-bs-toggle="modal" data-bs-target="#keepDetailsModal" aria-controls="keepDetailsModal">
      Keep Details
    </button>
    <Modal id="keepDetailsModal">
      <KeepDetailsCard/>
    </Modal>
  </section>
  <section class="container-fluid d-flex justify-content-center mt-2">
    <button type="button" class="btn btn-primary elevation-5" data-bs-toggle="modal" data-bs-target="#accountModal" aria-controls="accountModal">
      Edit Account
    </button>
    <Modal id="accountModal">
      <AccountForm/>
    </Modal>
  </section>
  <section class="container-fluid">
    <div class="row">
      <div class="col-md-12" v-for="k in keeps" :key="k.id">
        <KeepCard :keep="k"/>
      </div>
    </div>
  </section>
  <section class="container-fluid">
    <VaultCard/>
  </section>

</template>

<script>
import { AppState } from '../AppState.js';
import AccountForm from '../components/AccountForm.vue';
import KeepForm from '../components/KeepForm.vue';
import KeepCard from '../components/KeepCard.vue';
import KeepDetailsCard from '../components/KeepDetailsCard.vue';
import VaultForm from '../components/VaultForm.vue';
import VaultCard from '../components/VaultCard.vue'
import { computed } from 'vue';
export default {
    setup() {
        return {
          keeps: computed(() => AppState.keeps)
        };
    },
    components: { KeepForm, KeepCard, VaultForm, VaultCard, AccountForm }
}
</script>

<style lang="scss">
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

.f-flow{
  font-family: 'Flow Circular', cursive;
}
.f-inter{
  font-family: 'Inter', sans-serif;
  color: rgb(76, 160, 202);
}

.f-roboto{
  font-family: 'Roboto Slab', serif;
  color: rgb(47, 171, 216);
}
</style>
