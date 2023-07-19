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
   <div class="position-relative d-flex flex-row justify-content-center">
      <div class="col-md-7 rounded mt-3">
         <img :src="activeProfile.coverImg" alt="" class="img-fluid object-fit-cover profile-coverImg rounded-3">
         <img :src="activeProfile.picture" alt="" class="img-fluid object-fit-cover profile-picture rounded-circle position-absolute">
      </div>
      <!-- <div class="text-center">
      </div> -->
   </div>
   <div class="row text-center p-3 f-roboto text-white">
      <h1>{{ activeProfile.name }}</h1>
      <h2>{{ activeProfileVaults.length }} Vaults | {{activeProfileKeeps.length}} Keeps</h2>
   </div>
</section>
<section class="container-fluid p-3">
   <h1 class="f-roboto p-4">Vaults</h1>
   <div class="row">
         <div class="col-md-4" v-for="v in activeProfileVaults" :key="v.id">
            <RouterLink :to="{name: 'Vault', params: {id: v.id}}">
               <VaultCard :vault="v"/>
            </RouterLink>
         </div>
   </div>
</section>
<!-- <section class="container-fluid d-flex justify-content-center mt-2">
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
</section> -->
<section class="container-fluid d-flex justify-content-center mt-2">
   <!-- <button type="button" class="btn btn-primary elevation-5" data-bs-toggle="modal" data-bs-target="#keepDetailsModal" aria-controls="keepDetailsModal">
      Keep Details
   </button> -->
   <KeepDetailsModal id="keepDetailsModal">
      <KeepDetailsCard/>
   </KeepDetailsModal>
</section>
<section class="container-fluid d-flex justify-content-center mt-2">
   <!-- <button type="button" class="btn btn-primary elevation-5" data-bs-toggle="modal" data-bs-target="#vaultKeepDetailsModal" aria-controls="vaultKeepDetailsModal">
      Vault Keep Details
   </button> -->
   <KeepDetailsModal id="vaultKeepDetailsModal">
      <VaultKeepModal/>
   </KeepDetailsModal>
</section>
<!-- <section class="container-fluid d-flex justify-content-center mt-2">
   <button type="button" class="btn btn-primary elevation-5" data-bs-toggle="modal" data-bs-target="#accountModal" aria-controls="accountModal">
      Edit Account
   </button>
   <Modal id="accountModal">
      <AccountForm/>
   </Modal>
</section> -->
<section class="container-fluid">
   <h1 class="f-roboto p-4">Keeps</h1>
   <div class="masonry-with-columns">
      <div class="masonry-item" v-for="k in activeProfileKeeps" :key="k.id">
         <KeepCard :keep="k" data-bs-toggle="modal" data-bs-target="#keepDetailsModal" @click="setActiveKeep(k.id)"/>
      </div>
   </div>
</section>
<Modal id="createKeepModal">
   <KeepForm/>
</Modal>
<Modal id="createVaultModal">
   <VaultForm/>
</Modal>
</template>

<script>
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { keepsService } from '../services/KeepsService.js';
import AccountForm from '../components/AccountForm.vue';
import KeepForm from '../components/KeepForm.vue';
import KeepCard from '../components/KeepCard.vue';
import KeepDetailsCard from '../components/KeepDetailsCard.vue';
import KeepDetailsModal from '../components/KeepDetailsModal.vue'
import { vaultsService } from '../services/VaultsService.js';
import VaultForm from '../components/VaultForm.vue';
import VaultCard from '../components/VaultCard.vue'
import VaultKeepModal from '../components/VaultKeepModal.vue';
import { computed, onMounted } from 'vue';
import { profileService } from '../services/ProfileService.js';
import { useRoute } from 'vue-router';
export default {
   setup() {
      const route = useRoute();
      async function getProfile(){
         try{
            await profileService.getProfileById(route.params.id)
         } catch (e){
            logger.log(e)
         }
      }
      async function getProfileKeeps(){
         try{
            await profileService.getProfileKeeps(route.params.id)
         } catch (e) {
            logger.log(e)
         }
      }
      async function getProfileVaults(){
         try{
            await profileService.getProfileVaults(route.params.id)
         } catch (e) {
            logger.log(e)
         }
      }
      onMounted(() => {
         getProfile()
         getProfileKeeps()
         getProfileVaults()
      })
      return {
         async setActiveKeep(keepId){
            AppState.activeKeep = {};
            logger.log("Setting active keep", keepId)
            try{
               await keepsService.getKeepById(keepId);
            } catch (e){
               logger.log(e);
               Pop.error(e);
            }
         },
         keeps: computed(() => AppState.keeps),
         activeProfile: computed(() => AppState.activeProfile),
         activeProfileKeeps: computed(() => AppState.activeProfileKeeps),
         activeProfileVaults: computed(() => AppState.activeProfileVaults)
      };
   },
   components: { KeepForm, KeepCard, KeepDetailsModal,  VaultForm, VaultCard, VaultKeepModal, AccountForm }
}
</script>

<style scoped lang="scss">
.masonry-with-columns {
   columns: 4 300px;
   column-gap: 1rem;
}
@media (max-width: 575.98px) { 
   .masonry-with-columns {
   columns: 2 ;
   column-gap: 1rem;
   }
   }
.masonry-item {
   width: 150px;
   // background: #EC985A;
   color: white;
   margin: 0 1rem 1rem 0;
   display: inline-block;
   width: 100%;
   text-align: center;
   font-family: system-ui;
   font-weight: 900;
   font-size: 2rem;
} 
*{
   border: 0px solid green;
}
.profile-coverImg{
   width: 100%;
   height: 40%;
}
.profile-picture{
   width: 100px;
   position: absolute;
   left: 45%;
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
color: rgb(255, 255, 255);
}

.f-roboto{
font-family: 'Roboto Slab', serif;
color: rgb(47, 171, 216);
}
</style>
 