<template>
   <div class="modal fade" id="createKeepModal" tabindex="-1" aria-labelledby="createKeepModal" aria-hidden="true">
      <div class="modal-dialog">
         <div class="modal-content">
            <div class="modal-header">
            <h1 class="modal-title fs-5" id="createKeep">Create Keep</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <!-- <div class="modal-body">
            ...
            </div> -->
            <slot></slot>
            <!-- <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary">Save changes</button>
            </div> -->
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


<style>

</style>
