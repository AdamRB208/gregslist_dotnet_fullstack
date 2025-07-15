<script setup>
import { AppState } from '@/AppState.js';
import { carService } from '@/services/CarService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';


const account = computed(() => AppState.account)
const cars = computed(() => AppState)

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
      <div class="col-md-6">
        {{ cars }}
      </div>
    </div>
  </section>
</template>


<style lang="scss" scoped>

</style>