using Frontend_App.Models.DTO;

namespace Inl_uppgift_ASPNET_1.ViewModels;

public class HomeViewModel
{
    public List<Product> Featured { get; set; } = null!;
    public List<Product> New { get; set; } = null!;
    public List<Product> Popular { get; set; } = null!;
}



