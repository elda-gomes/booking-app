using BookingApp.Core.CQRS;
using BookingApp.Passenger.Data;
using BookingApp.Passenger.Dtos;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Passenger.Application.GetPassengerById
{
    public class GetPassengerByIdQueryHandler : IQueryHandler<GetPassengerByIdQuery, PassengerResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly PassengerDbContext _passengerDbContext;

        public GetPassengerByIdQueryHandler(IMapper mapper, PassengerDbContext passengerDbContext)
        {
            _mapper = mapper;
            _passengerDbContext = passengerDbContext;
        }

        public async Task<PassengerResponseDto> Handle(GetPassengerByIdQuery query, CancellationToken cancellationToken)
        {
            var passenger = await _passengerDbContext.Passengers.SingleOrDefaultAsync(x => x.Id == query.Id, cancellationToken);

            if (passenger is null)
                throw new NotImplementedException();

            return _mapper.Map<PassengerResponseDto>(passenger!);   
        }
    }
}
