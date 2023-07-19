<template>
   <form @submit.prevent="createKeep">
      <div class="modal-body ">
         <div class="container-fluid">
            <div class="form-floating mb-3">
               <input type="text" class="form-control" id="keepName" aria-describedby="keepName" v-model="editable.name" required>
               <label for="keepName" class="form-label">Keep Name</label>
            </div>
            <div class="form-floating mb-3">
               <input type="text" class="form-control" id="keepImg" aria-describedby="keepimg" v-model="editable.img" required>
               <label for="keepImage" class="form-label">Image Url</label>
            </div>
            <div class="form-floating mb-3">
               <textarea type="textarea" rows="4" class="form-control" id="keepDescription" v-model="editable.description"></textarea>
               <label for="keepDescription" class="form-label">Keep Description</label>
            </div>
            <div class="d-flex justify-content-end gap-2">
               <button type="submit" class="btn btn-primary" data-bs-dismiss="modal">Submit</button>
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
import { keepsService} from '../services/KeepsService.js'
import {ref} from 'vue';
   export default {
      setup(){
         const editable = ref({});
         return {
            editable,
            async createKeep(){
               try {
                  logger.log("Creating Keep")
                  await keepsService.createKeep(editable.value);
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