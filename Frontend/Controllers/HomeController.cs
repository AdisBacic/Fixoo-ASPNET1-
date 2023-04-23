using Frontend_App.Services.Api;
using Inl_uppgift_ASPNET_1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Frontend_App.Controllers;

public class HomeController : Controller
{

    public readonly ProductApi _productApi;


    public HomeController(ProductApi productApi)
    {
        _productApi = productApi;

    }
    public async Task<IActionResult> Index()
    {
        var res = await _productApi.GetAllProductsAsync();

        HomeViewModel model = new HomeViewModel();

        model.Featured = res.Where(x => x.Tag.ToString() == "Featured").ToList();
        model.New = res.Where(x => x.Tag.ToString() == "New").ToList();
        model.Popular = res.Where(x => x.Tag.ToString() == "Popular").ToList();

        return View(model);
    }
}
