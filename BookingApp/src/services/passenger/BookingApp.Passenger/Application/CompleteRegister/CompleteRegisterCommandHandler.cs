using BookingApp.Core.CQRS;
using BookingApp.Passenger.Data;
using BookingApp.Passenger.Dtos;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Passenger.Application.CompleteRegister
{
    public class CompleteRegisterCommandHandler : ICommandHandler<CompleteRegisterCommand, PassengerResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly PassengerDbContext _passengerDbContext;

        public CompleteRegisterCommandHandler(IMapper mapper, PassengerDbContext passengerDbContext)
        {
            _mapper = mapper;
            _passengerDbContext = passengerDbContext;
        }

        public async Task<PassengerResponseDto> Handle(CompleteRegisterCommand command, CancellationToken cancellationToken)
        {
            var passenger = await _passengerDbContext.Passengers.AsNoTracking()
                .SingleOrDefaultAsync(x => x.PassportNumber == command.PassportNumber, cancellationToken);

            if (passenger is null)
                throw new NotImplementedException();

            var passengerEntity = passenger.CompleteRegistrationPassenger(passenger.Id, passenger.Name, passenger.PassportNumber,
                passenger.PassengerType, passenger.Age);

            var updatedPassenger = _passengerDbContext.Passengers.Update(passengerEntity);

            await _passengerDbContext.SaveChangesAsync();

            return _mapper.Map<PassengerResponseDto>(updatedPassenger.Entity);
        }
    }
}
