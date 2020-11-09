using System.Collections.Generic;
using PieShop.Shared;

namespace PieShop.Api.Models
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();
        Country GetCountryById(int countryId);
    }
}
