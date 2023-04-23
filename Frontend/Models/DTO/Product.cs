

using Backend.Helpers.Enums;

namespace Frontend_App.Models.DTO;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = null!;
    public ProductGenre? Genre { get; set; }
    public int StarRating { get; set; }
    public ProductTagEnum? Tag { get; set; }


}