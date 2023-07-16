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
<section class="container-fluid">
   <div class="d-flex flex-row justify-content-center">
      <div class="col-md-7 rounded pt-3">
         <img src="../assets/img/macaroni.png" alt="" class="img-fluid object-fit-cover profile-coverImg rounded-3">
      </div>
      <div class="text-center">
         <img src="../assets/img/macaroni.png" alt="" class="img-fluid object-fit-cover profile-picture rounded-circle start-50 translate-middle-x">
      </div>
   </div>
   <div class="row text-center">
      <h1>Chantha Kammer</h1>
      <h2>5 Vaults | 5 Keeps</h2>
   </div>
</section>
<section class="container-fluid p-0">
   <h1 class="f-inter">Vaults</h1>
   <div class="row">
      <VaultCard/>
      <VaultCard/>
      <VaultCard/>
      <VaultCard/>
   </div>
</section>
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
   <div class="row" v-for="k in keeps" :key="k.id">
      <KeepCard :keep="k"/>
   </div>
</section>

</template>

<script>
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
*{
   border: 1px solid green;
}
.profile-coverImg{
   width: 100%;
   height: 40%;
}
.profile-picture{
   width: 100px;
   position: absolute;
   bottom: 55%;
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
 