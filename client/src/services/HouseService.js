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

}

export const houseService = new HouseService()