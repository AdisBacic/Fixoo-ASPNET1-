using Backend.Helpers.Enums;
using Backend.Models.Entities;

namespace Backend.Models.Dtos
{
    public class ProductRequest
    {

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
        public ProductGenre Genre { get; set; }
        public int StarRating { get; set; }
        public ProductTagEnum Tag { get; set; }



        public static implicit operator ProductEntity(ProductRequest req)
        {

            return new ProductEntity
            {
                Name = req.Name,
                Description = req.Description,
                Price = req.Price,
                ImageUrl = req.ImageUrl,
                Genre = req.Genre,
                StarRating = req.StarRating,
                Tag = req.Tag

            };



        }






    }
}
