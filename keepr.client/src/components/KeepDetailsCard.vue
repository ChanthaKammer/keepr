<template>
   <div class="container-fluid bg-dark rounded-5">
      <div class="modal-content" >
      <div class="modal-body container-fluid">
         <section class="row">
            <div class="col-md-6 col-12">
               <img class="img-fluid object-fit-cover"
                     src="../assets/img/macaroni.png"
                     alt="">
            </div>
            <div class="col-md-6 col-12 p-3">
               <div class="row h-100 justify-content-between">
                  <div class="col-12">
                     <i class="mdi mdi-eye-outline fs-1"></i>
                     <i class="mdi mdi-bank fs-1"></i>
                  </div>
                  <div class="col-12">
                     <h1 class="text-center f-inter">Keep Name</h1>
                     <h2>Keep Description</h2>
                  </div>
                  <div class="col-12">
                     <button type="button" class="btn btn-success" data-bs-dismiss="modal">Save</button>
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
   export default {
      setup(){
         return {

         }
      }
   }
</script>


<style scoped lang="scss">
   * {
      border: 1px solid green
   }
</style>