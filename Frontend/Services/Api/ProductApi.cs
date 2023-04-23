using Frontend_App.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Frontend_App.Services.Api;

public class ProductApi : ApiService<Product>
{

    #region Constructor
    private readonly HttpClient _client;

    public ProductApi(HttpClient client) : base(client, "https://localhost:7245/api/Products")
    {
        _client = client;
    }

    #endregion

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var response = await _client.GetAsync($"{Url}?key=MySecretKey");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var products = JsonConvert.DeserializeObject<List<Product>>(content);
        return products!;
    }


    public async Task<Product> GetProductById(string id)
    {
        var response = await _client.GetAsync($"{Url}/{id}?key=MySecretKey");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var product = JsonConvert.DeserializeObject<Product>(content);

        return product;
    }

}