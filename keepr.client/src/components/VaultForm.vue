<template>
   <form @submit.prevent="createVault">
      <div class="modal-body ">
         <div class="container-fluid">
            <div class="form-floating mb-3">
               <input type="text" class="form-control" id="keepName" aria-describedby="keepName" v-model="editable.name">
               <label for="vaultName" class="form-label">Add Your Vault</label>
            </div>
            <div class="form-floating mb-3">
               <input type="text" class="form-control" id="keepImg" aria-describedby="keepimg" v-model="editable.img">
               <label for="keepImage" class="form-label">Image Url</label>
            </div>
            <div class="d-flex justify-content-end gap-2">
               <button type="submit" class="btn btn-primary">Create Vault</button>
               <p>Private vaults can only be seen by you.</p>
               <input class="form-check-input" type="checkbox" value="" id="privateCheckbox">
               <label class="form-check-label" for="privateCheckbox">
                  Make Vault Private?
               </label>
               <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            </div>
         </div>
      </div>
   </form>
</template>

<script>
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
// import { keepsService } from '../services/KeepsService.js'
import {ref} from 'vue';
   export default {
      setup(){
         const editable = ref({});
         return {
            editable,
            async createVault(){
               try {
                  logger.log("Creating Vault", editable.value)
                  // await keepsService.createKeep(editable.value);
               } catch (error) {
                  Pop.error(error)
                  logger.log(error)
               }
            }
         }
      }
   }
</script>


<style scoped lang="scss">
*{
   border: 0px solid green;
}

</style>