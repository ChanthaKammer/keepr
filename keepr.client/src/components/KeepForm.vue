<template>
   <form @submit.prevent="createKeep">
      <div class="modal-body ">
         <div class="container-fluid">
            <div class="mb-3">
               <label for="keepName" class="form-label">Keep Name</label>
               <input type="text" class="form-control" id="keepTitle" aria-describedby="keepTitle" v-model="editable.title">
            </div>
            <div class="mb-3">
               <label for="keepImage" class="form-label">Image Url</label>
               <input type="text" class="form-control" id="keepImg" aria-describedby="keepimg" v-model="editable.img">
            </div>
            <div class="mb-3">
               <label for="keepDescription" class="form-label">Keep Description</label>
               <textarea type="textarea" rows="4" class="form-control" id="keepDescription" v-model="editable.description"></textarea>
            </div>
            <div class="d-flex justify-content-end gap-2">
               <button type="submit" class="btn btn-primary">Submit</button>
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