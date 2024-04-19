using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldCities.Server.Data.Models;
using WorldCities.Server.Interactor.Cities.Command;

namespace WorldCities.Server.Controllers.Cities
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesCommandController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CitiesCommandController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult> AddCities([FromBody]City city)
        {
            var result= await _mediator.Send(new AddCity { City=city});
            return Ok(result);
        }
        [HttpPut("{id}/updateCity")]

        public async Task<ActionResult> Update([FromBody] City city,int id)
        {
            var result= await _mediator.Send(new UpdateCity { City=city,Id=id});
            return Ok();
        }
        [HttpDelete("{id}/deleteCity")]
        public async Task<ActionResult> Delete(int id)
        {
            var result= await _mediator.Send(new DeleteCity { Id=id});
            return Ok();
        }
    }
}
