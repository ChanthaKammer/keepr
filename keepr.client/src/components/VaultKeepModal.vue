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
                  <i class="mdi mdi-trash-can-outline btn-danger text-end pe-4 fs-3" v-if="activeKeep?.creatorId == account.id" @click="deleteKeep(activeKeep.id)" data-bs-dismiss="modal"></i>
                  <div class="d-flex justify-content-center col-12 text-center gap-5">
                     <i class="mdi mdi-eye-outline fs-4"> {{ activeKeep?.views }} </i>
                     <i class="mdi mdi-bank fs-4"> {{ activeKeep?.kept }} </i>
                  </div>
                  <div class="col-12">
                     <h1 class="text-center f-inter">{{ activeKeep?.name }}</h1>
                     <h4>{{ activeKeep?.description }}</h4>
                     <!-- <p>{{ activeKeep.creator }}</p> -->
                  </div>
                  <div class="col-12 text-end">
                     <div class="row">
                        <div class="col-6">
                              <div class="d-flex mb-3">
                                 <i class="mdi mdi-delete">Remove</i>
                              </div>
                        </div>
                        <div class="col-6 d-flex">
                           <h1>Hello</h1>
                           <img class="img-fluid object-fit-cover w-25" src="../assets/img/macaroni.png" alt="">
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
   export default {
      setup(){
         return {
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