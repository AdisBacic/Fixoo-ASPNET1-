using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Entities
{
    public class MessageEntity
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Message { get; set; } = null!;




    }
}
