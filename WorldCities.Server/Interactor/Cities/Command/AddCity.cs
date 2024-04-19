using MediatR;
using NuGet.Protocol.Plugins;
using WorldCities.Server.Data;
using WorldCities.Server.Data.Models;
using WorldCities.Server.Repositories.Implementation;
using WorldCities.Server.Repositories.Interface;

namespace WorldCities.Server.Interactor.Cities.Command
{
    public class AddCity : IRequest<City>
    {
        public City City { get; set; }
    }
    public class AddCityHandler : IRequestHandler<AddCity, City>
    {
        private readonly ICityRepository _cityRepository;
        public AddCityHandler(CityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<City> Handle(AddCity request, CancellationToken cancellationToken)
        {
            var result = await _cityRepository.AddCityAsync(request.City);
            return result;
        }
    }
}
