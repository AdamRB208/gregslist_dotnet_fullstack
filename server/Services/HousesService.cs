

namespace gregslist_dotnet_fullstack.Services;

public class HousesService
{

  public HousesService(HousesRepository housesRepository)
  {
    _housesRepository = housesRepository;
  }

  private readonly HousesRepository _housesRepository;

  internal List<House> GetHouses()
  {
    List<House> houses = _housesRepository.GetHouses();
    return houses;
  }

  internal House GetHouseById(int houseId)
  {
    House house = _housesRepository.GetHouseById(houseId);

    if (house == null) throw new Exception($"Invalid House Id: {houseId}!");

    return house;
  }
}