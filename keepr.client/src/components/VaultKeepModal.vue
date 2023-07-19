<template>
   <div class="bg-dark">
      <div class="modal-content" >
      <div class="modal-body container-fluid p-0">
         <section class="row">
            <div class="col-md-6 col-12">
               <img class="img-fluid object-fit-cover h-100 w-100 rounded-3 rounded-start"
                     :src="activeKeep?.img"
                     alt="">
            </div>
            <div class="col-md-6 col-12 p-2">
               <div class="row h-100 justify-content-between">
                  <div class="d-flex justify-content-center col-12 text-center gap-5">
                     <i class="mdi mdi-eye-outline fs-4"> {{ activeKeep?.views }} </i>
                     <i class="mdi mdi-bank fs-4"> {{ activeKeep?.kept }} </i>
                  </div>
                  <div class="col-12">
                     <h1 class="text-center f-inter">{{ activeKeep?.name }}</h1>
                     <h4>{{ activeKeep?.description }}</h4>
                  </div>
                  <div class="col-12 text-end">
                     <div class="row">
                        <div class="col-6">
                              <div class="d-flex mb-3">
                                 <button data-bs-toggle="modal" data-bs-target="#vaultKeepDetailsModal">
                                    <i class="mdi mdi-delete" @click="removeVaultKeep(activeKeep.vaultKeepId)">Remove</i>
                                 </button>
                              </div>
                        </div>
                        <div class="col-6 d-flex">
                           <img class="img-fluid object-fit-cover w-25 rounded-circle" :src="activeKeep?.creator?.picture" alt="">
                           <p class="align-self-center">{{ activeKeep?.creator?.name }}</p>
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
import { computed } from 'vue';
import { vaultKeepService } from '../services/VaultKeepService.js';
   export default {
      setup(){
         return {
            async removeVaultKeep(id){
               try{
                  const yes = await Pop.confirm('Delete Vault Keep?')
                  if (!yes){ 
                  return }
                  await vaultKeepService.deleteVaultKeep(id);
               } catch (e){
                  logger.log(e)
                  Pop.error(e)
               }
            },
            activeKeep: computed(() => AppState.activeKeep),
            activeVaultKeeps: computed(() => AppState.activeVaultKeeps),
            account: computed(() => AppState.account)
         }
      }
   }
</script>


<style scoped lang="scss">
   * {
      border: 0px solid green
   }
</style>