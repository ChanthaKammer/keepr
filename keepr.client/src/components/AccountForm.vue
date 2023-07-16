<template>
   <form @submit.prevent="editAccount">
      <div class="modal-body ">
         <div class="container-fluid">
            <div class="mb-3">
               <label for="accountName" class="form-label">Name</label>
               <input type="text" class="form-control" id="accountName" aria-describedby="accountName" v-model="editable.name">
            </div>
            <div class="mb-3">
               <label for="accountPicture" class="form-label">Picture</label>
               <input type="text" class="form-control" id="accountPicture" aria-describedby="accountPicture" v-model="editable.picture">
            </div>
            <div class="mb-3">
               <label for="accountCoverImage" class="form-label">Cover Image</label>
               <input type="text" class="form-control" id="accountCoverImage" aria-describedby="accountCoverImage" v-model="editable.coverImg">
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
import { accountService } from '../services/AccountService.js';
import {ref} from 'vue';
   export default {
      setup(){
         const editable = ref({});
         return {
            editable,
            async editAccount(){
               try {
                  logger.log("Editing Account", editable.value)
                  // await accountService.editAccount(editable.value);
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