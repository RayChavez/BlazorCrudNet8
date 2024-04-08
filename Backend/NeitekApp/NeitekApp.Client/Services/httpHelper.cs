using NeitekDTO;
using System.Net.Http.Json;
using System.Text.Json;

namespace NeitekApp.Client.Services
{
    public class httpHelper
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public httpHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        //public async Task<TareaDTO>
    }
}
