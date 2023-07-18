<template>
   <div class="container-fluid bg-dark">
      <div class="modal-content" >
      <div class="modal-body container-fluid p-0">
         <section class="row">
            <div class="col-md-6 col-12">
               <img class="img-fluid object-fit-cover"
                     :src="activeKeep?.img"
                     alt="">
            </div>
            <div class="col-md-6 col-12 p-2">
               <div class="row h-100 justify-content-between">
                  <div class="col-12">
                     <i class="mdi mdi-eye-outline fs-1">{{ activeKeep?.views }}</i>
                     <i class="mdi mdi-bank fs-1">{{ activeKeep?.kept }}</i>
                  </div>
                  <div class="col-12">
                     <h1 class="text-center f-inter">{{ activeKeep?.name }}</h1>
                     <h2>{{ activeKeep?.description }}</h2>
                     <!-- <p>{{ activeKeep.creator }}</p> -->
                  </div>
                  <div class="col-12">
                     <div class="row">
                        <div class="col-6">
                              <div class="d-flex mb-3">
                                 <select class="form-select" aria-label="Type Selection" placeholder="">
                                          <option selected>Select Vault</option>
                                          <option v-for="v in fakeVaults" :key="v">{{ v }}</option>
                                 </select>
                                 <button type="button" class="btn btn-success" data-bs-dismiss="modal">Save</button>
                              </div>
                        </div>
                        <div class="col-6 d-flex" v-if="activeKeep?.creator">
                           <h4>{{ activeKeep.creator?.name }}</h4>
                           <RouterLink :to="{ name: 'Profile', params: {id: activeKeep?.creatorId}}">
                              <img class="img-fluid object-fit-cover w-25" :src="activeKeep.creator?.picture" alt="" data-bs-toggle="modal" data-bs-target="#keepDetailsModal" @click="setActiveProfile(activeKeep.creatorId)">
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
import { profileService } from '../services/ProfileService.js';
   export default {
      setup(){
         return {
            async setActiveProfile(profileId){
               try{
                  await profileService.getProfileById(profileId);
               } catch (e){
                  logger.log(e)
                  Pop.error(e)
               }
            },
            fakeVaults: computed(() => AppState.fakeVaults),
            activeKeep: computed(() => AppState.activeKeep),
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