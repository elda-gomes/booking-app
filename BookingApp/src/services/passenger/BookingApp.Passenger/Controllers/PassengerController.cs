using BookingApp.Passenger.Application.CompleteRegister;
using BookingApp.Passenger.Application.GetPassengerById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Passenger.Controllers
{
    [Route("api/passengers")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PassengerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetById([FromRoute] GetPassengerByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CompleteRegisterPassenger([FromRoute] CompleteRegisterCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}
