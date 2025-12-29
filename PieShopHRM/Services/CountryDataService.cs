using BethanysPieShopHRM.Shared.Domain;
using System.Net.Http.Json;
using System.Text.Json;

namespace PieShopHRM.Services;


public class CountryDataService : ICountryDataService
{
    private readonly HttpClient _httpClient = default;

    public CountryDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<Country>> GetAllCountries(){
        return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>(
            await _httpClient.GetStreamAsync($"api/country"), 
            new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true});
    }

    public async Task<Country> GetCountry(int countryId){
        return await JsonSerializer.DeserializeAsync<Country>(
            await _httpClient.GetStreamAsync($"api/country/{countryId}"), 
            new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true});
    }
}