import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Car } from "@/models/Car.js"
import { AppState } from "@/AppState.js"

class CarService {

  async getCars() {
    const response = await api.get('api/cars')
    logger.log('Got Cars!', response.data)
    const cars = response.data.map(pojo => new Car(pojo))
    AppState.cars = cars
  }

}

export const carService = new CarService()