using BethanysPieShopHRM.Shared.Domain;

namespace PieShopHRM.Services;
public interface ICountryDataService
{
   Task<IEnumerable<Country>> GetAllCountries();

   Task<Country> GetCountry(int countryId); 
}