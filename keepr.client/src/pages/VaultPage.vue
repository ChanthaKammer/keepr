<template>
  <div class="">
      <div class="d-flex flex-row justify-content-center position-relative ">
         <img
         :src="activeVault?.img" class="img-fluid object-fit-cover elevation-5 rounded-3 w-50"/>
         <div class="position-absolute top-0 start-0 w-100 h-100 d-flex flex-column justify-content-end bottom-shadow">
            <div class="d-flex ps-2 text-white f-roboto fs-1 justify-content-center">
               <h1 class="p-0 f-inter">{{activeVault?.name}}</h1>
               <i class="mdi mdi-lock-outline pb-2" v-if="activeVault?.isPrivate"></i>
            </div>
            <h2 class="d-flex justify-content-center text-white">by {{ activeVault?.creator?.name }}</h2>
         </div>
      </div>
      <div class="row justify-content-end align-items-center">
         <div class="col-4">
            <h1 class="text-center f-roboto pt-3">{{ activeVaultKeeps.length }} Keeps</h1>
         </div>
         <div class="col-4 text-white fs-3">
            <!-- <i class="mdi mdi-trash-can-outline fs-2" v-if="activeVault?.creator?.id == account?.id" @click="deleteVault(activeVault?.id)"></i> -->
            <i class="mdi mdi-dots-horizontal dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
         </i>
         <ul class="dropdown-menu">
            <li><a class="dropdown-item" @click="deleteVault(activeVault?.id)">Delete Vault</a></li>
            <li><a class="dropdown-item" v-if="activeVault.isPrivate" @click="togglePrivate(activeVault?.id)">Make Public</a></li>
            <li><a class="dropdown-item" v-if="!activeVault.isPrivate" @click="togglePrivate(activeVault?.id)">Make Private</a></li>
         </ul>
         </div>
      </div>
   </div>
   <!-- <section class="container-fluid">
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
   </section> -->
   <!-- <section class="container-fluid p-0">
      <h1 class="f-inter">Vaults</h1>
      <div class="row">
         <VaultCard/>
         <VaultCard/>
         <VaultCard/>
         <VaultCard/>
      </div>
   </section> -->
   <!-- <h1 class="f-roboto">Roboto</h1>
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
      <KeepDetailsModal id="vaultKeepDetailsModal" class="">
         <VaultKeepModal class=""/>
      </KeepDetailsModal>
   </section>
   <section class="container-fluid d-flex justify-content-center mt-2">
      <!-- <button type="button" class="btn btn-primary elevation-5" data-bs-toggle="modal" data-bs-target="#accountModal" aria-controls="accountModal">
         Edit Account
      </button> -->
      <Modal id="accountModal">
         <AccountForm/>
      </Modal>
   </section>
   <section class="container-fluid">
      <div class="masonry-with-columns" data-masonry='{"percentPosition": true }'>
         <div class="masonry-item animate__animated animate__slideInUp animate__fast" v-for="k in activeVaultKeeps" :key="k.id">
            <VaultKeepCard :keep="k" :vaultKeepId="k.vaultKeepId" data-bs-toggle="modal" data-bs-target="#vaultKeepDetailsModal" class="" @click="setActiveKeep(k)"/>
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
import AccountForm from '../components/AccountForm.vue';
import KeepForm from '../components/KeepForm.vue';
import KeepCard from '../components/KeepCard.vue';
import KeepDetailsCard from '../components/KeepDetailsCard.vue';
import KeepDetailsModal from '../components/KeepDetailsModal.vue'
import { keepsService } from '../services/KeepsService.js';
import VaultForm from '../components/VaultForm.vue';
import VaultCard from '../components/VaultCard.vue'
import VaultKeepModal from '../components/VaultKeepModal.vue';
import VaultKeepCard from '../components/VaultKeepCard.vue';
import { vaultsService } from '../services/VaultsService.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { vaultKeepService } from '../services/VaultKeepService.js';
import { router } from '../router.js';
   export default {
      setup() {
         const route = useRoute();
         async function getVaultById(){
            try{
               await vaultsService.getVaultById(route.params.id);
            } catch (e){
               router.push({path: '/#/Home'})
               logger.log(e)
               Pop.error(e)
            }
         }
         async function getVaultKeeps(){
            try{
               await vaultsService.getVaultKeeps(route.params.id);
            } catch(e){
               logger.log(e)
               Pop.error(e)
            }
         }
         onMounted(() => {
            getVaultById()
            getVaultKeeps()
         })
         return {
         async setActiveKeep(k){
            AppState.activeKeep = k;
            // logger.log("Setting active keep", keepId)
            // try{
            //    await keepsService.getKeepById(k.Id);
            // } catch (e){
            //    logger.log(e);
            //    Pop.error(e);
            // }
         },
         async togglePrivate(vaultId){
            try {
               await vaultsService.togglePrivate(vaultId)
               AppState.activeVault.isPrivate = !AppState.activeVault.isPrivate;
            } catch(e){
               logger.log(e)
               Pop.error(e)
            }
         },
         async deleteVault(vaultId){
            try {
               const yes = await Pop.confirm('Delete Vault ?')
                  if (!yes){ 
                  return }
               await vaultsService.deleteVault(vaultId);
               router.push({path: '/#/Home'})
            } catch (e){
               router.push({path: '/#/Home'})
               logger.log(e);
               Pop.error(e);
            }
         },
            activeVault: computed(() => AppState.activeVault),
            activeKeep: computed(() => AppState.activeKeep),
            activeVaultKeeps: computed(() => AppState.activeVaultKeeps),
            account: computed(() => AppState.account)
         };
      },
      components: { KeepForm, KeepCard, KeepDetailsModal,  VaultForm, VaultCard, VaultKeepModal, VaultKeepCard, AccountForm }
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
   .bottom-shadow{
   background: linear-gradient(0deg, rgba(0,0,0,0.6) 20%, rgba(0, 0, 0, 0)100%);
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
    