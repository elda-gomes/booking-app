using BookingApp.Core.CQRS;
using BookingApp.Flight.API.Dtos;
using BookingApp.Flight.Infra.Context;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Flight.API.Application.GetAvailableFlights
{
    public class GetAvailableFlightsQueryHandler : IQueryHandler<GetAvailableFlightsQuery, IEnumerable<FlightResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly FlightDbContext _flightDbContext;

        public GetAvailableFlightsQueryHandler(IMapper mapper, FlightDbContext flightDbContext)
        {
            _mapper = mapper;
            _flightDbContext = flightDbContext;
        }

        public async Task<IEnumerable<FlightResponseDto>> Handle(GetAvailableFlightsQuery request, CancellationToken cancellationToken)
        {
            var flight = await _flightDbContext.Flights.Where(x => !x.IsDeleted).ToListAsync(cancellationToken);

            if (!flight.Any())
                throw new NotImplementedException();

            return _mapper.Map<List<FlightResponseDto>>(flight);
        }
    }
}
