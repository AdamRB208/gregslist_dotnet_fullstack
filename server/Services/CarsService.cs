namespace gregslist_dotnet_fullstack.Services;

public class CarsService
{
  public CarsService(CarsRepository carsRepository)
  {
    _carsRepository = carsRepository;
  }
  private readonly CarsRepository _carsRepository;

  internal List<Car> GetCars()
  {
    List<Car> cars = _carsRepository.GetCars();
    return cars;
  }

  internal Car GetCarById(int carId)
  {
    Car car = _carsRepository.GetCarById(carId);
    if (car == null)
    {
      throw new Exception($"No car found with the id of {carId}!");
    }
    return car;
  }

  internal Car CreateCar(Car carData)
  {
    Car car = _carsRepository.CreateCar(carData);
    return car;
  }

  internal string DeleteCar(int carId, Account userInfo)
  {
    Car car = GetCarById(carId);

    if (car.CreatorId != userInfo.Id)
    {
      throw new Exception($"YOU ARE NOT ALLOWED TO DELETE SOMEONE ELSES CAR, {userInfo.Name.ToUpper()}!");
    }

    _carsRepository.DeleteCar(carId);

    return $"Your {car.Make} {car.Model} has been deleted!";
  }

  internal Car UpdateCar(int carId, Car carUpdateData, Account userInfo)
  {
    Car car = GetCarById(carId);

    if (car.CreatorId != userInfo.Id)
    {
      throw new Exception($"YOU ARE NOT ALLOWED TO UPDATE SOMEONE ELSES CAR, {userInfo.Name.ToUpper()}!");
    }

    car.Make = carUpdateData.Make ?? car.Make;
    car.Model = carUpdateData.Model ?? car.Model;
    car.Year = carUpdateData.Year ?? car.Year;
    car.Color = carUpdateData.Color ?? car.Color;
    car.Price = carUpdateData.Price ?? car.Price;
    car.Mileage = carUpdateData.Mileage ?? car.Mileage;
    car.EngineType = carUpdateData.EngineType ?? car.EngineType;
    car.ImgUrl = carUpdateData.ImgUrl ?? car.ImgUrl;
    car.HasCleanTitle = carUpdateData.HasCleanTitle ?? car.HasCleanTitle;

    _carsRepository.UpdateCar(car);

    return car;
  }
}