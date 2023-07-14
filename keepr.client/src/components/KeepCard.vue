<template>
   <div class="container-fluid">
      <h1>{{ keep.name }} {{ keep.id }}</h1>
      <p>{{ keep.description }}</p>
      <img :src="keep.img">
   </div>
</template>

<script>
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import { Keep } from '../models/Keep.js';
   export default {
      props: {
         keep: { type: Keep, required: true } 
      },
      setup(props){
         return {

         }
      }
   }
</script>


<style lang="scss" scoped>

</style>