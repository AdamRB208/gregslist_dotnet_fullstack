<script setup>
import { AppState } from '@/AppState.js';
import CarsCard from '@/components/CarsCard.vue';
import CreateCarModal from '@/components/CreateCarModal.vue';
import { carService } from '@/services/CarService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';


const car = computed(() => AppState.cars)
const account = computed(() => AppState.account)

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
      <div class="d-flex justify-content-between mt-2">
        <h1>Cars</h1>
        <span v-if="account" class="d-flex justify-content-center">
          <button class="btn btn-outline-vue" type="button" data-bs-toggle="modal"
            data-bs-target="#CreateCarModal">Create a Car Listing</button>
        </span>
      </div>
      <div v-for="car in car" :key="car.id" class="col-12 mt-4">
        <CarsCard :carProp="car" />
      </div>
    </div>
  </section>
  <CreateCarModal />
</template>


<style lang="scss" scoped>

</style>