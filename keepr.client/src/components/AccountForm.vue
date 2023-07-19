<template>
   <form @submit.prevent="editAccount">
      <div class="modal-body ">
         <div class="container-fluid">
            <div class="form-floating mb-3">
               <input type="text" class="form-control" id="accountName" aria-describedby="accountName" v-model="editable.name">
               <label for="accountName" class="form-label">Name</label>
            </div>
            <div class="mb-3 form-floating">
               <input type="text" class="form-control" id="accountPicture" aria-describedby="accountPicture" v-model="editable.picture">
               <label for="accountPicture" class="form-label">Picture</label>
            </div>
            <div class="mb-3 form-floating">
               <input type="text" class="form-control" id="accountCoverImage" aria-describedby="accountCoverImage" v-model="editable.coverImg">
               <label for="accountCoverImage" class="form-label">Cover Image</label>
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
import {ref, computed} from 'vue';
   export default {
      setup(){
         const editable = ref({});
         return {
            editable,
            async editAccount(){
               try {
                  // logger.log("Editing Account", editable.value)
                  await accountService.editAccount(editable.value);
               } catch (error) {
                  Pop.error(error)
                  logger.log(error)
               }
            },
            account: computed(() => AppState.account)
         }
      }
   }
</script>


<style scoped lang="scss">
*{
   border: 0px solid green;
}

</style>