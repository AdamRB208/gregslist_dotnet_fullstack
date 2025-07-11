namespace gregslist_dotnet_fullstack.Services;

public class CarsService
{
  public CarsService(CarsRepository carsRepository)
  {
    _carsRepository = carsRepository;
  }
  private readonly CarsRepository _carsRepository;

  
}