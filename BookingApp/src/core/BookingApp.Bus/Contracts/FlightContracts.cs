using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Bus.Contracts
{
    public record GetFlightById
    { 
        public long FlightId { get; init; }
    }

    public record GetAvailableSeatsById
    { 
        public long FlightId { get; init; }
    }

    public record FlightResponse
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

    public enum FlightStatus
    {
        Flying,
        Delay,
        Canceled,
        Completed
    }

    public class SeatResponse
    {
        public long Id { get; init; }
        public string SeatNumber { get; init; }
        public SeatType Type { get; init; }
        public SeatClass Class { get; init; }
        public long FlightId { get; init; }
    }

    public enum SeatType
    {
        Window,
        Middle,
        Aisle
    }

    public enum SeatClass
    {
        FirstClass,
        Business,
        Economy
    }

    public record ReserveSeatRequestDto
    { 
        public long FlighId { get; init; }
        public string SeatNumber { get; init; }
    }
}
