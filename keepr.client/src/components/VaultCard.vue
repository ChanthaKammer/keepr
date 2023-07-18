<template>
   <div class="p-4">
      <div class="d-flex flex-column recipe-card justify-content-center position-relative" @click="getKeepById(keep.Id)">
         <img
         src="../assets/img/macaroni2.png" class="img-fluid object-fit-cover elevation-5 rounded-3"/>
         <div class="position-absolute top-0 start-0 w-100 h-100 d-flex flex-column justify-content-end">
            <div class="d-flex ps-2 text-white f-roboto fs-1 bottom-shadow justify-content-between">
               <h1 class="p-0">Vault</h1>
               <i class="mdi mdi-lock-outline pb-2"></i>
            </div>
         </div>
      </div>
   </div>
</template>

<script>
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import { Keep } from '../models/Keep.js';
   export default {
      props: {
         keep: {type: Keep, required: true}
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