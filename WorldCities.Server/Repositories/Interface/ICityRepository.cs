using WorldCities.Server.Data.Models;

namespace WorldCities.Server.Repositories.Interface
{
    public interface  ICityRepository
    {
        public Task<List<City>> GetCitiesAsync();
        public Task<List<City>> GetCitiesByCountryIdAsync(int countryId);
        public Task<City> GetCityByIdAsync(int id);
        public Task<City> AddCityAsync(City city);
        public Task<City> UpdateCityAsync(City city);
        public Task<bool> DeleteCityAsync(int id);

    }
}
