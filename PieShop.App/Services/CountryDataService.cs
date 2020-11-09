using PieShop.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace PieShop.App.Services
{
    public class CountryDataService : ICountryDataService
    {
        private readonly HttpClient _httpClient;

        public CountryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<Country>> GetAllCountries()
        {
            return _httpClient.GetFromJsonAsync<IEnumerable<Country>>("api/country", new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public Task<Country> GetCountryById(int countryId)
        {
            return _httpClient.GetFromJsonAsync<Country>($"api/country{countryId}", new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
