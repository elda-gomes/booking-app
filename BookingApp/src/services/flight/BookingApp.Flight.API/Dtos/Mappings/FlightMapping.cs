using BookingApp.Flight.API.Application.GetFlightById;
using Mapster;

namespace BookingApp.Flight.API.Dtos.Mappings
{
    public class FlightMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Domain.Flights.Models.Flight, FlightResponseDto>();
            config.NewConfig<GetFlightByIdQuery, FlightResponseDto>();
        }
    }
}
