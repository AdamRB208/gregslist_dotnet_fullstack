
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


}