using Microsoft.EntityFrameworkCore;
using WorldCities.Server.Data;
using WorldCities.Server.Data.Models;
using WorldCities.Server.Repositories.Interface;

namespace WorldCities.Server.Repositories.Implementation
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _context;
        public CityRepository(ApplicationDbContext context) 
        {
            _context= context;
        }
        public async Task<City> AddCityAsync(City city)
        {
            var result = await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteCityAsync(int id)
        {
            var result = _context.Cities.FirstOrDefault(c => c.Id == id);
            if (result != null)
            {
                var respo = _context.Cities.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new Exception("City not found");
            }
        }

        public async Task<List<City>> GetCitiesAsync()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<List<City>> GetCitiesByCountryIdAsync(int countryId)
        {
            return await _context.Cities.Where(c => c.CountryId == countryId).ToListAsync();
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            return await _context.Cities.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<City> UpdateCityAsync(City city)
        {
            var result = _context.Cities.FirstOrDefault(c => c.Id == city.Id);
            if (result != null)
            {
                result.Name = city.Name;
                result.Lat = city.Lat;
                result.Lon = city.Lon;
                result.CountryId = city.CountryId;
                await _context.SaveChangesAsync();
                return result;
            }
            else
            {
                throw new Exception("City not found");
            }
        }
    }
}
