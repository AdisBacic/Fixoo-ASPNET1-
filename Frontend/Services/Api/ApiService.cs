using Newtonsoft.Json;

namespace Frontend_App.Services.Api;

public abstract class ApiService<T> where T : class
{
    #region Constructor
    private readonly HttpClient _client;
    public readonly string Url;
    
    protected ApiService(HttpClient client, string url)
    {
        _client = client;
        Url = url;
    }
    #endregion
    public async Task<T?> GetAsync()
    {
        var response = await _client.GetAsync(Url);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(content);
    }

}