﻿using BookingApp.Flight.API.Application.GetAvailableFlights;
using BookingApp.Flight.API.Application.GetFlightById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Flight.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlightController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAvailableFlights([FromRoute] GetAvailableFlightsQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetById([FromRoute] GetFlightByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }
    }
}
