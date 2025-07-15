using System.ComponentModel.DataAnnotations;

namespace gregslist_dotnet_fullstack.Models;

public class Car
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  [MinLength(3), MaxLength(30)] public string Make { get; set; }
  [MinLength(1), MaxLength(30)] public string Model { get; set; }
  [Range(1896, 2026)] public int? Year { get; set; }
  public string Color { get; set; }
  [Range(0, 5000000)] public int? Price { get; set; }
  [Range(0, 400000)] public int? Mileage { get; set; }
  public string EngineType { get; set; }
  [Url, MaxLength(1000)] public string ImgUrl { get; set; }
  public bool? HasCleanTitle { get; set; }
  public string CreatorId { get; set; }
  public Account Creator { get; set; }
}