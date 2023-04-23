using Backend.Helpers.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Dtos
{
    public class ProductResponse
    {

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
        public ProductGenre Genre { get; set; }
        public int StarRating { get; set; }
        public ProductTagEnum Tag { get; set; }


    }
}
