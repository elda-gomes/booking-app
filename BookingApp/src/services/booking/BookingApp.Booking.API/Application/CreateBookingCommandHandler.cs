using BookingApp.Booking.API.Dtos;
using BookingApp.Booking.Domain.Interfaces;
using BookingApp.Booking.Domain.Models.ValueObjects;
using BookingApp.Bus.Contracts;
using BookingApp.Core.CQRS;
using Mapster;
using MassTransit;

namespace BookingApp.Booking.API.Application
{
    public class CreateBookingCommandHandler : ICommandHandler<CreateBookingCommand, CreateReservationResponseDto>
    {
        private readonly IBookingRepository _repository;
        private readonly IRequestClient<GetFlightById> _clientA;
        private readonly IRequestClient<GetAvailableSeatsById> _clientB;
        private readonly IRequestClient<GetPassengerByIdRequest> _clientC;
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public CreateBookingCommandHandler(IBookingRepository repository, 
            IRequestClient<GetFlightById> clientA, 
            IRequestClient<GetAvailableSeatsById> clientB, 
            IRequestClient<GetPassengerByIdRequest> clientC,
            ISendEndpointProvider sendEndpointProvider)
        {
            _repository = repository;
            _clientA = clientA;
            _clientB = clientB;
            _clientC = clientC;
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task<CreateReservationResponseDto> Handle(CreateBookingCommand command, CancellationToken cancellationToken)
        {
            var flightMessage = await _clientA.GetResponse<FlightResponse>(new { FlightId = command.FlightId }, cancellationToken);            
            var flight = flightMessage.Message;

            var emptySeatMessage = await _clientB.GetResponse<SeatResponse>(new { FlightId = command.FlightId }, cancellationToken);
            var emptySeat = emptySeatMessage.Message;

            var passengerMessage = await _clientC.GetResponse<PassengerResponse>(new { PassengerId = command.PassengerId }, cancellationToken);
            var passenger = passengerMessage.Message;

            var reservation = await _repository.GetById(command.Id);

            if (reservation is not null && !reservation.IsDeleted)
            {
                throw new NotImplementedException("A reserva já existe!");
            }

            var aggregate = Domain.Models.Booking.Create(command.Id, new PassengerInfo(passenger.Name), new Trip(flight.FlightNumber, flight.AircraftId,
                flight.DepartureAirportId, flight.ArriveAirportId, flight.FlightDate, flight.Price, command.Description, emptySeat?.SeatNumber));

            var _serviceAdress = "queue:ReserveSeat";
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri(_serviceAdress));

            await endpoint.Send(new ReserveSeatRequestDto
            { 
                FlighId = flight.Id,
                SeatNumber = emptySeat?.SeatNumber
            });

            _repository.Add(aggregate);

            var result = await _repository.UnitOfWork.Commit();
            var reservationResponseDto = aggregate.Adapt<CreateReservationResponseDto>();

            if (result is true)
            {

                var _serviceAdressEmail = "queue:SendEmail";
                var endpointEmail = await _sendEndpointProvider.GetSendEndpoint(new Uri(_serviceAdressEmail));

                await endpointEmail.Send(new SendEmailRequestDto
                {
                    PassengerName = passenger.Name,
                    PassengerPassport = passenger.PassportNumber,
                    FlightNumber = reservationResponseDto.FlightNumber,
                    FlightDate = reservationResponseDto.FlightDate,
                    SeatNumber = reservationResponseDto.SeatNumber
                });
            }           

            return reservationResponseDto;
        }
    }
}
