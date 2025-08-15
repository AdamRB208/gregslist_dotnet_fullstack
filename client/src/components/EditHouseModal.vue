<script setup>
import { AppState } from '@/AppState.js';
import { houseService } from '@/services/HouseService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, ref, watch } from 'vue';

const account = computed(() => AppState.account)
const house = computed(() => AppState.activeHouse)

const editableHouseData = ref(AppState.activeHouse ?? {
  bedrooms: '',
  bathrooms: '',
  levels: '',
  year: '',
  imgUrl: '',
  price: '',
  description: '',
  sqft: ''
})

watch(() => AppState.activeHouse, () => {
  editableHouseData.value = { ...AppState.activeHouse }
}, { immediate: true })

async function editHouse(houseId) {
  try {
    const updatedHouseData = editableHouseData.value
    editableHouseData.value = {
      bedrooms: '',
  bathrooms: '',
  levels: '',
  year: '',
  imgUrl: '',
  price: '',
  description: '',
  sqft: ''
    }
    await houseService.editHouse(houseId, updatedHouseData)
  }
  catch (error){
    Pop.error(error, 'COULD NOT EDIT HOUSE!');
    logger.log('Could not edit house!')
  }
}
</script>


<template>
  <div class="modal" tabindex="-1" id="EditHouseModal">
    <div class="modal-dialog">
      <div v-if="house" class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Create a House Listing</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div v-if="account && house.creatorId === account.id" class="modal-body">
          <form @submit.prevent="editHouse(house.id)">
            <div class="mb-3">
              <label for="bedrooms"> Bedrooms</label>
              <input v-model="editableHouseData.bedrooms" id="houseBedrooms" name="bedrooms" type="number" required
                min="1" max="10" placeholder="0">
            </div>
            <div class="mb-3">
              <label for="bathrooms">Bathrooms</label>
              <input v-model="editableHouseData.bathrooms" id="houseBathrooms" name="bathrooms" type="number" required
                min="1" max="10" placeholder="0">
            </div>
            <div class="mb-3">
              <label for="sqft">Squrare Footage</label>
              <input v-model="editableHouseData.sqft" id="houseSqft" name="sqft" type="number" required min="1"
                max="100000" placeholder="...">
            </div>
            <div class="mb-3">
              <label for="levels">Levels</label>
              <input v-model="editableHouseData.levels" id="houseLevels" name="levels" type="number" required min="1"
                max="10" placeholder="0">
            </div>
            <div class="mb-3">
              <label for="year">Year</label>
              <input v-model="editableHouseData.year" id="houseYear" name="year" type="number" required min="1776"
                max="2025" placeholder="2025">
            </div>
            <div class="mb-3">
              <label for="houseImgUrl">Image</label>
              <input v-model="editableHouseData.imgUrl" id="houseImgUrl" name="imgUrl" type="url" required
                maxlength="500" placeholder="Image URL...">
            </div>
            <div class="mb-3">
              <label for="price">Price</label>
              <input v-model="editableHouseData.price" id="housePrice" name="price" type="number" required min="0"
                max="100000000" placeholder="$$$">
            </div>
            <div class="mb-3">
              <label for="description">House Description</label>
              <textarea v-model="editableHouseData.description" id="houseDescription" name="description" type="text"
                class="w-100" placeholder="Description of the house..." maxlength="500"></textarea>
            </div>
            <button type="submit" class="btn btn-primary">Edit House Listing</button>
          </form>
        </div>
        <div class="modal-footer">
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>

</style>