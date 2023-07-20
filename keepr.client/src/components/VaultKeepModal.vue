<template>
   <div class="bg-dark">
      <div class="modal-content" >
      <div class="modal-body container-fluid p-0 bg-dark">
         <section class="row">
            <div class="col-md-6 col-12">
               <img class="img-fluid object-fit-cover h-100 w-100 rounded-start"
                     :src="activeKeep?.img"
                     alt="">
            </div>
            <div class="col-md-6 col-12 p-2">
               <div class="row h-100 justify-content-around">
                  <div class="d-flex justify-content-center col-12 text-center gap-5 pt-3">
                     <i class="mdi mdi-eye-outline fs-4"> <span class="f-roboto text-white">{{ activeKeep?.views }} </span></i>
                     <i class="mdi mdi-bank fs-4"> <span class="f-roboto text-white">{{ activeKeep?.kept }}</span></i>
                  </div>
                  <div class="col-12">
                     <h1 class="text-center f-roboto">{{ activeKeep?.name }}</h1>
                     <p class="f-inter text-white ps-2">{{ activeKeep?.description }}</p>
                  </div>
                  <div class="col-12">
                     <div class="row">
                        <div class="d-flex col-6 align-items-end">
                              <div class="d-flex mb-3 ps-3">
                                 <button data-bs-toggle="modal" data-bs-target="#vaultKeepDetailsModal" class="btn btn-danger">
                                    <i class="mdi mdi-delete" @click="removeVaultKeep(activeKeep.vaultKeepId)">Remove</i>
                                 </button>
                              </div>
                        </div>
                        <div class="col-6 d-flex p-3 align-items-end">
                           <h5 class="f-roboto text-white">{{ activeKeep?.creator?.name }}</h5>
                           <RouterLink :to="{ name: 'Profile', params: {id: activeKeep?.creatorId}}">
                              <img class="img-fluid object-fit-cover rounded-circle profile-picture-small p-2" :src="activeKeep?.creator?.picture" alt="" data-bs-toggle="modal" data-bs-target="#vaultKeepDetailsModal" @click="setActiveProfile(activeKeep.creatorId)">
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
import { computed } from 'vue';
import { vaultKeepService } from '../services/VaultKeepService.js';
import { profileService } from '../services/ProfileService.js';
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
            async setActiveProfile(profileId){
               try{
                  await profileService.getProfileById(profileId);
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
.modal-content{
   border: 3px;
   border-radius: 3px;
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
.profile-picture-small{
   height: 4rem;
   aspect-ratio: 1/1;
}
   * {
      border: 0px solid green
   }
</style>