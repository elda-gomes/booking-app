﻿using BookingApp.Core.CQRS;
using BookingApp.Flight.API.Dtos;
using BookingApp.Flight.Infra.Context;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Flight.API.Application.GetAvailableSeats
{
    public class GetAvailableSeatsQueryHandler : IQueryHandler<GetAvailableSeatsQuery, IEnumerable<SeatResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly FlightDbContext _flightDbContext;

        public GetAvailableSeatsQueryHandler(IMapper mapper, FlightDbContext flightDbContext)
        {
            _mapper = mapper;
            _flightDbContext = flightDbContext;
        }

        public async Task<IEnumerable<SeatResponseDto>> Handle(GetAvailableSeatsQuery query, CancellationToken cancellationToken)
        {
            var seats = await _flightDbContext.Seats.Where(x => x.FlightId == query.FlightId && !x.IsDeleted).ToListAsync(cancellationToken);

            if (!seats.Any())
                throw new NotImplementedException();

            return _mapper.Map<List<SeatResponseDto>>(seats);
        }
    }
}
