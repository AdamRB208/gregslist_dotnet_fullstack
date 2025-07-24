<script setup>
import { AppState } from '@/AppState.js';
import { Car } from '@/models/Car.js';
import { carService } from '@/services/CarService.js';
import { Pop } from '@/utils/Pop.js';
import { computed } from 'vue';
import EditCarModal from './EditCarModal.vue';
import { useRoute } from 'vue-router';

const route = useRoute()
const account = computed(() => AppState.account)

defineProps({
  carProp: {type:Car, required: true}
})


async function deleteCar(carId) {
  try {
    const confirmed = await Pop.confirm('Are you sure you want to delete this car?', 'It will be gone forever!', 'Yes I am sure', 'No I have changed my mind')

    if (!confirmed) {
      return
    }
    await carService.deleteCar(carId)
  }
  catch (error) {
    Pop.error(error);
  }
}

async function setActiveCar(car, carId) {
  try {
    AppState.activeCar = car
    await carService.setActiveCar(car)
    carId = route.params.carId || carId
    AppState.activeCar.id = carId
  }
  catch (error) {
    Pop.error(error);
  }
}


</script>


<template>
  <div class="row shadow-lg mb-4 ms-2 me-2 car-border">
    <div class="col-md-5 px-0">
      <img :src="carProp.imgUrl" :alt="`A picture of a ${carProp.year} ${carProp.make} ${carProp.model}`" class="w-100">
    </div>
    <div class="col-md-7">
      <div class="p-3 h-100 d-flex flex-column justify-content-between">
        <div>
          <div class="d-flex justify-content-between">
            <p class="fs-3">{{ carProp.year }} {{ carProp.make }} {{ carProp.model }}</p>
            <small>{{ carProp.createdAt.toLocaleDateString() }}</small>
          </div>
          <p class="fs-3">{{ '$' + carProp.price.toLocaleString() }}</p>
          <p v-if="carProp.mileage">Mileage: {{ carProp.mileage }}</p>
          <p>Engine: {{ carProp.engineType }}</p>
        </div>
        <div class="d-flex justify-content-between align-items-center">
          <div>
            <button v-if="account && carProp.creatorId == account?.id" @click="deleteCar(carProp.id)"
              class="btn btn-outline-danger mt-3" type="button">
              Delete Car
            </button>
            <button v-if="account && carProp.creatorId === account.id" @click="setActiveCar(carProp, carProp.id)"
              class="btn btn-outline-primary ms-1 mt-3" type="button" data-bs-toggle="modal"
              data-bs-target="#EditCarModal">Edit
              Listing
            </button>
          </div>
          <div class="d-flex flex-row-reverse align-items-center gap-3 mt-3">
            <p class="mb-0">{{ carProp.creator.name }}</p>
            <img :src="carProp.creator.picture" alt="picture of the listings creator" class="creator-img">
          </div>
        </div>
      </div>
    </div>
  </div>
  <EditCarModal />
</template>


<style lang="scss" scoped>
.creator-img {
  height: 3.7em;
  aspect-ratio: 1/1;
  border-radius: 50%;
}

img {
  height: 45dvh;
  object-fit: cover;
}

.car-border {
  border-style: solid;
  border-width: thick;
  border-color: v-bind('carProp.color');
}
</style>