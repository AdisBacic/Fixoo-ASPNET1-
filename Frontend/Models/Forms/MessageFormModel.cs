using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Frontend.Models.Forms
{
    public class MessageFormModel
    {
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "E-postadressen måste ha formatet a@a.aa")]
        [DisplayName("E-postadress")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Empty message is not allowed!")]
        [MinLength(2, ErrorMessage = "Meddelandet måste minst innehålla 2 tecken")]
        [DisplayName("Message")]
        public string Message { get; set; } = null!;
    }
}
