<template>
   <div class="p-4">
      <div class="d-flex flex-column recipe-card justify-content-center position-relative">
         <img
         :src="vault?.img" alt="" :title="vault.name" class="img-fluid object-fit-cover elevation-5 rounded-3"/>
         <div class="position-absolute top-0 start-0 w-100 h-100 d-flex flex-column justify-content-end">
            <div class="d-flex ps-2 text-white f-roboto fs-1 bottom-shadow justify-content-between">
               <h1 class="p-0">{{vault.name}}</h1>
               <!-- <p>{{ vault }}</p> -->
               <i class="mdi mdi-lock-outline pb-2" v-if="vault.isPrivate"></i>
            </div>
         </div>
      </div>
   </div>
</template>

<script>
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import { Vault } from '../models/Vault.js';
   export default {
      props: {
         vault: {type: Vault}
      }, 
      setup(){
         return {
            async getKeepById(keepId){
               logger.log("Getting keep by id", keepId)
            }
         }
      }
   }
</script>


<style scoped lang="scss">
.bottom-shadow{
   background: linear-gradient(0deg, rgba(0,0,0,0.6) 20%, rgba(0, 0, 0, 0)100%);
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