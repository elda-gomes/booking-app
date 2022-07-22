﻿using BookingApp.Flight.Domain.Seats.Models;
using Mapster;

namespace BookingApp.Flight.API.Dtos.Mappings
{
    public class SeatMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Seat, SeatResponseDto>();
        }
    }
}
