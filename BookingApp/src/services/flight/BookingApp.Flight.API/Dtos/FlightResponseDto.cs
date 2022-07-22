using BookingApp.Flight.Domain.Flights.Enums;

namespace BookingApp.Flight.API.Dtos
{
    public class FlightResponseDto
    {
        public long Id { get; set; }
        public string FlightNumber { get; set; }
        public long AircraftId { get; set; }
        public long DepartureAirportId { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArriveDate { get; set; }
        public long ArriveAirportId { get; set; }
        public decimal DurationMinutes { get; set; }
        public DateTime FlightDate { get; set; }
        public FlightStatus Status { get; set; }
        public decimal Price { get; set; }
    }
}
