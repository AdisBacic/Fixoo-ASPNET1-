using Frontend_App.Services.Api;
using Inl_uppgift_ASPNET_1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Frontend_App.Controllers
{
    public class ProductsController : Controller
    {


        public readonly ProductApi _productApi;

        public ProductsController(ProductApi productApi)
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

        public async Task<IActionResult> Detail(string id)
        {
            var result = await _productApi.GetProductById(id);

            return View(result);
        }


    }
}
