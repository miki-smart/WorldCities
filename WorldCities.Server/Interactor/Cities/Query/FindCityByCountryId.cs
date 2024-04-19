using MediatR;
using Microsoft.EntityFrameworkCore;
using WorldCities.Server.Data;
using WorldCities.Server.Data.Models;
using WorldCities.Server.Repositories.Implementation;
using WorldCities.Server.Repositories.Interface;

namespace WorldCities.Server.Interactor.Cities.Query
{
    public class FindCityByCountryId : IRequest<List<City>>
    {
        public int CountryId { get; set; }
    }
    public class FindCityByCountryIdHandler : IRequestHandler<FindCityByCountryId, List<City>>
    {
        
        private readonly ICityRepository _cityRepository;
        public FindCityByCountryIdHandler(CityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<List<City>> Handle(FindCityByCountryId request, CancellationToken cancellationToken)
        {
            return await _cityRepository.GetCitiesByCountryIdAsync(request.CountryId);
        }
    }
}
