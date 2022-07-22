namespace BookingApp.Bus.Contracts
{
    public record SendEmailRequestDto
    { 
        public string PassengerName { get; init; }
        public string PassengerPassport { get; init; }
        public string FlightNumber { get; init; }
        public DateTime FlightDate { get; init; }
        public string SeatNumber { get; init; }
    }

    public record RequestUserByPassportNumber(string passportNumber);

    public record GetUserResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PassPortNumber { get; set; }
    }
}
