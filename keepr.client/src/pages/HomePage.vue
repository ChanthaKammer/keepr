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
  <router-link class="navbar-brand d-flex justify-content-center" :to="{ name: 'Profile' }">
    <button class="btn btn-secondary" type="button" >
      Profile Page
    </button>
  </router-link>
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
    <KeepDetailsModal id="keepDetailsModal">
      <KeepDetailsCard/>
    </KeepDetailsModal>
  </section>
  <section class="container-fluid d-flex justify-content-center mt-2">
    <button type="button" class="btn btn-primary elevation-5" data-bs-toggle="modal" data-bs-target="#vaultKeepDetailsModal" aria-controls="vaultKeepDetailsModal">
      Vault Keep Details
    </button>
    <KeepDetailsModal id="vaultKeepDetailsModal">
      <VaultKeepModal/>
    </KeepDetailsModal>
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
    <div class="row grid" data-masonry='{ "itemSelector": ".grid-item", "columnWidth": 200 }'>
      <div class="col-md-4 grid-item" v-for="k in keeps" :key="k.id">
        <KeepCard :keep="k"/>
      </div>
    </div>
  </section>
  <section class="container-fluid">
    <VaultCard/>
  </section>
</template>

<script>
import masonry from 'masonry-layout';
import { AppState } from '../AppState.js';
import AccountForm from '../components/AccountForm.vue';
import KeepForm from '../components/KeepForm.vue';
import KeepCard from '../components/KeepCard.vue';
import KeepDetailsCard from '../components/KeepDetailsCard.vue';
import KeepDetailsModal from '../components/KeepDetailsModal.vue'
import VaultForm from '../components/VaultForm.vue';
import VaultCard from '../components/VaultCard.vue'
import VaultKeepModal from '../components/VaultKeepModal.vue';
import { computed } from 'vue';
export default {
    setup() {
        return {
          keeps: computed(() => AppState.keeps)
        };
    },
    components: { KeepForm, KeepCard, KeepDetailsModal,  VaultForm, VaultCard, VaultKeepModal, AccountForm }
}
</script>


<style scoped lang="scss">
body {
  margin: 0;
  padding: 1rem;
}

.masonry-with-flex {
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  max-height: 1000px;
  div {
    width: 150px;
    background: #EC985A;
    color: white;
    margin: 0 1rem 1rem 0;
    text-align: center;
    font-family: system-ui;
    font-weight: 900;
    font-size: 2rem;
  } 
  @for $i from 1 through 36 { 
    div:nth-child(#{$i}) {
      $h: (random(400) + 100) + px;
      height: $h;
      line-height: $h;
    }
  }
}

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
