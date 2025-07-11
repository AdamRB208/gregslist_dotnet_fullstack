namespace gregslist_dotnet_fullstack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
  public CarsController(CarsService carsService, Auth0Provider auth0Provider)
  {
    _carsService = carsService;
    _auth0Provider = auth0Provider;
  }
  private readonly CarsService _carsService;
  private readonly Auth0Provider _auth0Provider;

  
}
