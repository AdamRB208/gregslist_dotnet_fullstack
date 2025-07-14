


using Microsoft.AspNetCore.Http.HttpResults;
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

  internal void DeleteHouse(int houseId)
  {
    string sql = @"DELETE FROM houses WHERE id = @houseId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { houseId });
    if (rowsAffected == 0) throw new Exception("Delete was unsuccessful!");
    if (rowsAffected > 1) throw new Exception("Delete was too successful!");
  }

  internal void UpdateHouse(House house)
  {
    string sql = @"
    UPDATE houses SET
    sqft = @Sqft,
    bedrooms = @Bedrooms,
    bathrooms = @Bathrooms,
    imgUrl = @ImgUrl,
    description = @Description,
    price = @Price,
    year = @Year,
    levels = @Levels
    WHERE id = @Id LIMIT 1;";

    int rowsAffected = _db.Execute(sql, house);

    if (rowsAffected == 0)
    {
      throw new Exception("NO ROWS WERE UPDATED!");
    }

    if (rowsAffected > 1)
    {
      throw new Exception(rowsAffected + "ROWS WERE UPDATED!");
    }
  }
}