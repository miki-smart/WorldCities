using WorldCities.Server.Data.Models;

namespace WorldCities.Server.Repositories.Interface
{
    public interface ICountryRepository
    {
        public Task<List<Country>> GetCountriesAsync();
        public Task<Country> GetCountryByIdAsync(int id);
        public Task<Country> AddCountryAsync(Country country);
        public Task<Country> UpdateCountryAsync(Country country);
        public Task<bool> DeleteCountryAsync(int id);
    }
}
