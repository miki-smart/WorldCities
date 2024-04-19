using Microsoft.EntityFrameworkCore;
using WorldCities.Server.Data;
using WorldCities.Server.Data.Models;
using WorldCities.Server.Repositories.Interface;

namespace WorldCities.Server.Repositories.Implementation
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;
        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Country> AddCountryAsync(Country country)
        {
            var result = await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteCountryAsync(int id)
        {
            var result = _context.Countries.FirstOrDefault(c => c.Id == id);
            if (result != null)
            {
               var respo= _context.Countries.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<Country>> GetCountriesAsync()
        {
            return  await _context.Countries.ToListAsync();
            
        }

        public async Task<Country> GetCountryByIdAsync(int id)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async  Task<Country> UpdateCountryAsync(Country country)
        {
            var result =  _context.Countries.FirstOrDefault(c => c.Id == country.Id);
            if (result != null)
            {
                result.Name = country.Name;
                result.ISO2 = country.ISO2;
                result.ISO3 = country.ISO3;
                await _context.SaveChangesAsync();
                return result;
            }
            else
            {
                throw new Exception("Country not found");
            }

        }
    }
}
