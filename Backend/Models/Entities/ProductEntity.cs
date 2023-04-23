using Backend.Helpers.Enums;
using Backend.Models.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
        public ProductGenre Genre { get; set; }
        public int StarRating { get; set; }
        public ProductTagEnum Tag { get; set; }





        public static implicit operator ProductResponse(ProductEntity entity)
        {

            return new ProductResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                ImageUrl = entity.ImageUrl,
                Genre = entity.Genre,
                StarRating = entity.StarRating,
                Tag = entity.Tag

            };


            
        }
    
    
    
    
    
    
    
    
    
    
    
    
    }

}
