import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Car } from "@/models/Car.js"
import { AppState } from "@/AppState.js"

class CarService {
  async setActiveCar(activeCar) {
    AppState.activeCar = activeCar
    logger.log('active car', activeCar)
  }

  async editCar(carId, updatedCarData) {
    const response = await api.put(`api/cars/${carId}`, updatedCarData)
    logger.log('Updated Car!', response.data)
    const car = AppState.cars
    const index = car.findIndex(car => car.id == carId)
    car.splice(index, 1, updatedCarData)
  }

  async getCars() {
    const response = await api.get('api/cars')
    logger.log('Got Cars!', response.data)
    const cars = response.data.map(pojo => new Car(pojo))
    AppState.cars = cars
  }

  async createCar(carData) {
    const response = await api.post('api/cars', carData)
    logger.log('Created Car!', response.data)
    const car = new Car(response.data)
    AppState.cars.push(car)
  }

  async deleteCar(carId) {
    const response = await api.delete(`api/cars/${carId}`)
    logger.log('Deleted Car!', response.data)
    const car = AppState.cars
    const carIndex = car.findIndex(car => car.id == carId)
    car.splice(carIndex, 1)
  }

}

export const carService = new CarService()