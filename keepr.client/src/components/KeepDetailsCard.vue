<template>
   <div class="container-fluid bg-dark">
      <div class="modal-content" >
      <div class="modal-body container-fluid p-0">
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
                  <div class="col-12 text-end">
                     <div class="row">
                        <div class="col-6">
                              <div class="d-flex mb-3">
                                 <select class="form-select" aria-label="Type Selection" placeholder="">
                                          <option selected>Select Vault</option>
                                          <option value="sandwich">Sandwich</option>
                                          <option value="soup">Soup</option>
                                          <option value="miata">Miata</option>
                                          <option value="Miscalanias">Miscalanias</option>
                                 </select>
                                 <button type="button" class="btn btn-success" data-bs-dismiss="modal">Save</button>
                              </div>
                        </div>
                        <div class="col-6">

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
   export default {
      setup(){
         return {

         }
      }
   }
</script>


<style scoped lang="scss">
   * {
      border: 0px solid green
   }
</style>