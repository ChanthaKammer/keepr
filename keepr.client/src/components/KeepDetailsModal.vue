<template>
   <div class="modal fade" id="modalTemplate" tabindex="-1" aria-labelledby="modalTemplate" aria-hidden="true">
      <div class="modal-dialog modal-xl">
         <div class="modal-content">
            <!-- <div class="modal-header">
            <h1 class="modal-title fs-5" id="createKeep">Placeholder</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div> -->
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
import { computed, onMounted } from 'vue';
   export default {
      setup(){
         return {
         }
      }
   }
</script>


<style>

</style>
