namespace gregslist_dotnet_fullstack.Repositories;

public class CarsRepository
{
  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  
}