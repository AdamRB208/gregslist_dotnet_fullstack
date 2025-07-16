<script setup>
import { AppState } from '@/AppState.js';
import HousesCard from '@/components/HousesCard.vue';
import { houseService } from '@/services/HouseService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';



const house = computed(() => AppState.houses)
const account = computed(() => AppState.account)

onMounted(() => {
  getHouses()
})

async function getHouses() {
  try {
    await houseService.getHouses()
  }
  catch (error) {
    Pop.error(error, 'COULD NOT GET HOUSES!');
    logger.error('Could not get Houses!', error)
  }
}

</script>


<template>
  <section class="container-fluid">
    <div class="row">
      <div class="d-flex justify-content-between mt-2">
        <h1>Houses</h1>
        <span v-if="account" class="d-flex justify-content-center">
          <button class="btn btn-outline-vue" type="button">Create a House Listing</button>
        </span>
      </div>
      <div v-for="house in house" :key="house.id" class="col-12 mt-4">
        <HousesCard :houseProp="house" />
      </div>
    </div>
  </section>
</template>


<style lang="scss" scoped>

</style>