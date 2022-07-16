using BookingApp.Core.AggregateModels;
using BookingApp.Flight.Domain.Seats.Enums;

namespace BookingApp.Flight.Domain.Seats.Models
{
    public class Seat : Aggregate<long>
    {
        public string SeatNumber { get; private set; }
        public SeatType Type { get; private set; }
        public SeatClass Class { get; private set; }
        public long FlightId { get; private set; }
    }
}
