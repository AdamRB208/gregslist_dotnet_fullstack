


using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace gregslist_dotnet_fullstack.Repositories;

public class HousesRepository
{
  public HousesRepository(IDbConnection db)
  {
    _db = db;
  }

  private readonly IDbConnection _db;

  internal List<House> GetHouses()
  {
    string sql = @"SELECT houses.*, accounts.*
      FROM houses
      JOIN accounts ON houses.creator_id = accounts.id;";

    List<House> houses = _db.Query(sql, (House house, Account account) =>
    {
      house.Creator = account;
      return house;
    }).ToList();
    return houses;
  }

  internal House GetHouseById(int houseId)
  {
    string sql = @"SELECT houses.*, accounts.* FROM houses JOIN accounts ON houses.creator_id = accounts.id WHERE houses.id = @HouseId;";

    House house = _db.Query(sql, (House house, Account account) =>
    {
      house.Creator = account;
      return house;
    }, new { houseId }).SingleOrDefault();
    return house;
  }

  internal House CreateHouse(House houseData)
  {
    string sql = @"
    INSERT INTO houses(sqft, bedrooms, bathrooms, imgUrl, description, price, year, levels, creator_id)
    VALUES (@Sqft, @Bedrooms, @Bathrooms, @ImgUrl, @Description, @Price, @Year, @Levels, @CreatorId);
    
    SELECT houses.*, accounts.*
    FROM houses INNER JOIN accounts ON accounts.id = houses.creator_id WHERE houses.id = LAST_INSERT_ID();";

    House house = _db.Query(sql, (House house, Account account) =>
    {
      house.Creator = account;
      return house;
    }, houseData).SingleOrDefault();
    return house;
  }
}