<script setup>
import { carService } from '@/services/CarService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { ref } from 'vue';


const editableCarData = ref({
  make: '',
  model: '',
  price: '',
  year: '',
  imgUrl: '',
  engineType: '',
  color: '#000000',
  description: '',
  mileage: '',
  hasCleanTitle: ''
})

async function createCar() {
  try {
    const carData = editableCarData.value
    await carService.createCar(carData)
    editableCarData.value = {
      make: '',
      model: '',
      price: '',
      year: '',
      imgUrl: '',
      engineType: '',
      color: '#000000',
      description: '',
      mileage: '',
      hasCleanTitle: ''
    }
  }
  catch (error) {
    Pop.error(error, 'COULD NOT CREATE CAR!');
    logger.error('Could not create car!', error)
  }
}

</script>


<template>
  <div class="modal" tabindex="-1" id="CreateCarModal">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Modal title</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <!-- Form Section Here!!! -->
          <form @submit.prevent="createCar()">
            <div class="mb-3">
              <label for="carMake">Car Make</label>
              <input v-model="editableCarData.make" id="carMake" name="make" type="text" required maxlength="500"
                placeholder="Car Make...">
            </div>
            <div class="mb-3">
              <label for="carModel">Car Model</label>
              <input v-model="editableCarData.model" id="carModel" name="model" type="text" required maxlength="500"
                placeholder="Car Model...">
            </div>
            <div class="mb-3">
              <label for="carPrice">Car Price</label>
              <input v-model="editableCarData.price" id="carPrice" name="price" type="number" required min="0"
                max="1000000" placeholder="0">
            </div>
            <div class="mb-3">
              <label for="carYear">Car Year</label>
              <input v-model="editableCarData.year" id="carYear" name="year" type="number" required min="1886"
                max="2025" placeholder="2025">
            </div>
            <div class="mb-3">
              <label for="carMileage">Car Mileage</label>
              <input v-model="editableCarData.mileage" id="carMileage" name="mileage" type="number" required min="0"
                max="400000" placeholder="...">
            </div>
            <div class="mb-3">
              <label>Does the vehicle have a clean title?</label>
              <input v-model="editableCarData.hasCleanTitle" class="checkbox" name="hasCleanTitle" id="carHasCleanTitle"
                type="checkbox" :value="true">
              <label for="carHasCleanTitle">Yes</label>
            </div>
            <div class="mb-3">
              <label for="carImgUrl">Car Image URL</label>
              <input v-model="editableCarData.imgUrl" id="carImgUrl" name="imgUrl" type="url" required maxlength="500"
                placeholder="Image URL...">
            </div>
            <div class="d-flex justify-content-between">
              <div class="mb-3">
                <label for="carEngineType">Car Engine Type</label>
                <select v-model="editableCarData.engineType" name="engineType" id="carEngineType">
                  <option value="4 cylinder">4 cylinder</option>
                  <option value="v6">v6</option>
                  <option value="v8">v8</option>
                  <option value="v10">v10</option>
                  <option value="v12">v12</option>
                  <option value="Diesel">Diesel</option>
                </select>
              </div>
              <div class="mb-3">
                <label for="carColor">Car Color</label>
                <input v-model="editableCarData.color" id="carColor" name="color" type="color" value="#FF0000"
                  class="check-input">
              </div>
            </div>
            <div>
              <button type="submit" class="btn btn-outline-vue">Post Car Listing</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
label {
  display: block;
}

input {
  width: 100%;
}
.checkbox {
  width: 1.5em;
  outline: #ffffff;
}
</style>