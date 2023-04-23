using Backend.Filters;
using Frontend.Models.Forms;
using Frontend_App.Services.Api;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace Frontend.Services.Api
{
    public class MessageApi :ApiService<MessageFormModel>
    {
        #region Constructor
        private readonly HttpClient _client;
        private readonly string _apiKey = "MySecretKey";


        public MessageApi(HttpClient client) : base(client, "https://localhost:7245/api/Message")
        {
            _client = client;
        }

        #endregion

        public async Task <IActionResult> PostAsync(MessageFormModel message)
        {
            try
            {
                _client.DefaultRequestHeaders.Clear();
                _client.DefaultRequestHeaders.Add("ApiKey", _apiKey);

                var response = await _client.PostAsJsonAsync($"{Url}/?key=MySecretKey", message);

                return new OkResult();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new BadRequestResult();
            }

        }

    }
}
