using MediatR;
using Microsoft.EntityFrameworkCore;
using WorldCities.Server.Data;
using WorldCities.Server.Data.Models;
using WorldCities.Server.Repositories.Implementation;
using WorldCities.Server.Repositories.Interface;

namespace WorldCities.Server.Interactor.Cities.Query
{
    public class FindCities : IRequest<List<City>>
    {

    }
    public class FindCitiesHandler : IRequestHandler<FindCities, List<City>>
    {
        
        private readonly ICityRepository _cityRepository;
        public FindCitiesHandler(CityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<List<City>> Handle(FindCities request, CancellationToken cancellationToken)
        {
            return await _cityRepository.GetCitiesAsync();
        }
    }
}
