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

  internal House CreateHouse(House houseData)
  {
    House house = _housesRepository.CreateHouse(houseData);
    return house;
  }

  internal string DeleteHouse(int houseId, string userId)
  {
    House house = GetHouseById(houseId);
    if (house.CreatorId != userId) throw new Exception("This is not your house!");
    _housesRepository.DeleteHouse(houseId);
    return $"Deleted the {house.Description} {house.Year} listing!";
  }

  internal House UpdateHouse(int houseId, House houseUpdateData, Account userInfo)
  {
    House house = GetHouseById(houseId);

    if (house.CreatorId != userInfo.Id)
    {
      throw new Exception($"YOU ARE NOT ALLOWED TO UPDATE SOMEONE ELSES HOUSE, {userInfo.Name.ToUpper()}!");
    }

    house.Sqft = houseUpdateData.Sqft ?? house.Sqft;
    house.Bedrooms = houseUpdateData.Bedrooms ?? house.Bedrooms;
    house.Bathrooms = houseUpdateData.Bathrooms ?? house.Bathrooms;
    house.ImgUrl = houseUpdateData.ImgUrl ?? house.ImgUrl;
    house.Description = houseUpdateData.Description ?? house.Description;
    house.Price = houseUpdateData.Price ?? house.Price;
    house.Year = houseUpdateData.Year ?? house.Year;
    house.Levels = houseUpdateData.Levels ?? house.Levels;

    _housesRepository.UpdateHouse(house);

    return house;
  }
}