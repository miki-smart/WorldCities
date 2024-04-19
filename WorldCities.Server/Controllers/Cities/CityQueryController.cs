using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldCities.Server.Interactor.Cities.Query;

namespace WorldCities.Server.Controllers.Cities
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityQueryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CityQueryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("get-All-Cities")]
        public async Task<ActionResult> GetCities()
        {
            var result= await _mediator.Send(new FindCities());
            return Ok(result);
        }
        [HttpGet("get-city-byCountry")]
        public async Task<ActionResult> GetCityById(int countryId)
        {
            var result= await _mediator.Send(new FindCityByCountryId { CountryId=countryId});
            return Ok(result);
        }
    }
}
