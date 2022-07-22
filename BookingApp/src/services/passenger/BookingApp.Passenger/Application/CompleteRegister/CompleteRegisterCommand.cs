using BookingApp.Core.CQRS;
using BookingApp.Core.Generator;
using BookingApp.Passenger.Dtos;
using BookingApp.Passenger.Passengers.Models.Enums;

namespace BookingApp.Passenger.Application.CompleteRegister
{
    public record CompleteRegisterCommand(string PassportNumber, PassengerType PassengerType, int Age) : ICommand<PassengerResponseDto>
    {
        public long Id { get; set; } = SnowFlakeIdGenerator.NewId();
    }
}
