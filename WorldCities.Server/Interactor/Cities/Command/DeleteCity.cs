using MediatR;
using WorldCities.Server.Data;
using WorldCities.Server.Repositories.Implementation;
using WorldCities.Server.Repositories.Interface;

namespace WorldCities.Server.Interactor.Cities.Command
{
    public class DeleteCity : IRequest<bool>
    {
        public int Id { get; set; }
    }
    public class DeleteCityHandler : IRequestHandler<DeleteCity, bool>
    {
        private readonly ICityRepository _cityRepository;
        public DeleteCityHandler(CityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<bool> Handle(DeleteCity request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.DeleteCityAsync(request.Id);
            return city;
        }
    }
}
