<script setup>
import { AppState } from '@/AppState.js';
import CarsCard from '@/components/CarsCard.vue';
import { carService } from '@/services/CarService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';


const car = computed(() => AppState.cars)

onMounted(() => {
  getCars()
})

async function getCars() {
  try {
    await carService.getCars()
  }
  catch (error) {
    Pop.error(error, 'COULD NOT GET CARS!');
    logger.error('Could not get Cars!', error)
  }
}
</script>


<template>
  <section class="container-fluid">
    <div class="row">
      <div v-for="car in car" :key="car.id" class="col-12 mt-4">
        <CarsCard :carProp="car" />
      </div>
    </div>
  </section>
</template>


<style lang="scss" scoped>

</style>