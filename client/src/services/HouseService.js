import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { House } from "@/models/House.js"
import { AppState } from "@/AppState.js"

class HouseService {
  async getHouses() {
    const response = await api.get('api/houses')
    logger.log('Got Houses!', response.data)
    const house = response.data.map(pojo => new House(pojo))
    AppState.houses = house
  }

  async createHouse(houseData) {
    const response = await api.post('api/houses', houseData)
    logger.log('Created House!', response.data)
    const house = new House(response.data)
    AppState.houses.push(house)
  }

  async deleteHouse(houseId) {
    const response = await api.delete(`api/houses/${houseId}`)
    logger.log('Deleted House!', response.data)
    const house = AppState.houses
    const houseIndex = house.findIndex(house => house.id == houseId)
    house.splice(houseIndex, 1)
  }

}

export const houseService = new HouseService()