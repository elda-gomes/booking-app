using BookingApp.Core.AggregateModels;
using BookingApp.Flight.Domain.Flights.Enums;

namespace BookingApp.Flight.Domain.Flights.Models
{
    public class Flight : Aggregate<long>
    {
        public string FlightNumber { get; private set; }
        public long AircraftId { get; private set; }
        public DateTime DepatureDate { get; private set; }
        public long DepartureAirportId { get; private set; }
        public DateTime ArriveDate { get; private set; }
        public long ArriveAirportId { get; private set; }
        public decimal DurationMinutes { get; private set; }
        public DateTime FlightDate { get; private set; }
        public FlightStatus Status { get; private set; }
        public decimal Price { get; private set; }

        public static Flight Create(long id, string flightNumber, long aircraftId, long departureAirpotId, DateTime departureDate, DateTime arriveDate,
            long arriveAirportId, decimal durationMinutes, DateTime flightDate, FlightStatus status, decimal price, bool isDeleted = false)
        {
            var flight = new Flight()
            {
                Id = id,
                FlightNumber = flightNumber,
                AircraftId = aircraftId,
                DepartureAirportId = departureAirpotId,
                DepatureDate = departureDate,
                ArriveDate = arriveDate,
                ArriveAirportId = arriveAirportId,
                DurationMinutes = durationMinutes,
                FlightDate = flightDate,
                Status = status,
                Price = price,
                IsDeleted = isDeleted
            };

            return flight;
        }
    }
}
