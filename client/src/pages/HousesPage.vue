<script setup>
import { AppState } from '@/AppState.js';
import { computed } from 'vue';



const house = computed(() => AppState.houses)
const account = computed(() => AppState.account)

</script>


<template>
  <section class="container-fluid">
    <div class="row">
      <div class="d-flex justify-content-between mt-2">
        <h1>Houses</h1>
        <span class="d-flex justify-content-center">
          <button class="btn btn-outline-vue" type="button">Create a House Listing</button>
        </span>
      </div>
      <div class="col-12 mt-4">
        <div>{{ house }}</div>
      </div>
    </div>
  </section>
</template>


<style lang="scss" scoped>

</style>