<template>
   <div class="bg-dark">
      <div class="modal-content" >
      <div class="modal-body p-0">
         <section class="row">
            <div class="col-md-6 col-12">
               <img class="img-fluid object-fit-cover h-100 w-100 rounded-start"
                     :src="activeKeep?.img" :title="activeKeep?.name"
                     alt="">
            </div>
            <div class="col-md-6 col-12 p-2">
               <div class="row h-100 justify-content-between">
                  <i class="mdi mdi-trash-can-outline btn-danger text-end pe-4 fs-3" v-if="activeKeep?.creatorId == account.id" @click="deleteKeep(activeKeep.id)" data-bs-dismiss="modal"></i>
                  <div class="d-flex justify-content-center text-center gap-5">
                     <i class="mdi mdi-eye-outline fs-4"> <span class="f-roboto text-white">{{ activeKeep?.views }} </span></i>
                     <i class="mdi mdi-bank fs-4"> <span class="f-roboto text-white">{{ activeKeep?.kept }}</span></i>
                  </div>
                  <div class="col-12">
                     <h1 class="text-center f-roboto">{{ activeKeep?.name }}</h1>
                     <p class="f-inter">{{ activeKeep?.description }}</p>
                     <!-- <p>{{ activeKeep.creator }}</p> -->
                  </div>
                  <div class="col-12">
                     <div class="row">
                        <div class="d-flex col-6 align-items-end">
                              <div class="d-flex mb-3">
                                 <select class="form-select" aria-label="Type Selection" placeholder="" v-model="selectedVault.vaultId">
                                          <option selected>Select Vault</option>
                                          <option v-for="v in myVaults" :key="v.id" :value="v.id">{{ v.name }}</option>
                                 </select>
                                 <button @click="createVaultKeep(activeKeep.id)" type="button" class="btn btn-success" data-bs-dismiss="modal">Save</button>
                              </div>
                        </div>
                        <div class="col-6 d-flex p-3 align-items-end" v-if="activeKeep?.creator">
                           <h4 class="f-roboto text-white">{{ activeKeep.creator?.name }}</h4>
                           <RouterLink :to="{ name: 'Profile', params: {id: activeKeep?.creatorId}}">
                              <img class="img-fluid object-fit-cover rounded-circle profile-picture-small p-2" :src="activeKeep.creator?.picture" alt="" data-bs-toggle="modal" data-bs-target="#keepDetailsModal" @click="setActiveProfile(activeKeep.creatorId)">
                           </RouterLink>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </section>
      </div>
      </div>
   </div>
</template>

<script>
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import { computed, onMounted, ref } from 'vue';
import { profileService } from '../services/ProfileService.js';
import { accountService } from '../services/AccountService.js';
import { keepsService } from '../services/KeepsService.js';
import { vaultKeepService } from '../services/VaultKeepService.js';
   export default {
      setup(){
         const selectedVault = ref({});
         async function getAccountVaults(){
            try{
               await accountService.getAccountVaults();
            } catch (e){
               logger.log(e)
            }
         }
         onMounted(() => {
            getAccountVaults();
         })
         return {
            async setActiveProfile(profileId){
               try{
                  await profileService.getProfileById(profileId);
               } catch (e){
                  logger.log(e)
                  Pop.error(e)
               }
            },
            async deleteKeep(keepId){
               try{
                  const yes = await Pop.confirm('Delete Keep ?')
                  if (!yes){ 
                  return }
                  await keepsService.deleteKeep(keepId);
                  // logger.log("deleting keep", keepId)
               } catch (e){
                  logger.log(e)
                  Pop.error(e)
               }
            },
            async createVaultKeep(keepId){
               // logger.log(selectedVault.value.vaultId, keepId)
               try{
                  await vaultKeepService.createVaultKeep(selectedVault.value.vaultId, keepId)
               } catch (e){
                  logger.log(e)
                  Pop.error(e)
               }
            },
            selectedVault,
            fakeVaults: computed(() => AppState.fakeVaults),
            myVaults: computed(() => AppState.myVaults),
            activeKeep: computed(() => AppState.activeKeep),
            account: computed(() => AppState.account)
         }
      }
   }
</script>


<style scoped lang="scss">
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
.profile-picture-small{
   height:4rem;
   aspect-ratio: 1/1;
}
   * {
      border: 0px solid green
   }
</style>