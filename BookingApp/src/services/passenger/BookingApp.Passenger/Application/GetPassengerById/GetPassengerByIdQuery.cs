using BookingApp.Core.CQRS;
using BookingApp.Passenger.Dtos;

namespace BookingApp.Passenger.Application.GetPassengerById
{
    public record GetPassengerByIdQuery(long Id) : IQuery<PassengerResponseDto>;
}
