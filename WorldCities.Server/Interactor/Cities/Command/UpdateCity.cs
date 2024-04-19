using MediatR;
using WorldCities.Server.Data;
using WorldCities.Server.Data.Models;
using WorldCities.Server.Repositories.Implementation;
using WorldCities.Server.Repositories.Interface;

namespace WorldCities.Server.Interactor.Cities.Command
{
    public class UpdateCity : IRequest<City>
    {
        public City City { get; set; }
        public int Id { get; set; }
    }
    public class UpdateCityHandler : IRequestHandler<UpdateCity, City>
    {
        private readonly ICityRepository _cityRepository;
        public UpdateCityHandler(CityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<City> Handle(UpdateCity request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.UpdateCityAsync(request.City);
            return city;
        }
    }
}
