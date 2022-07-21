using BookingApp.Flight.Domain.Airports.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingApp.Flight.Infra.Configurations
{
    public class AirportConfiguration : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.ToTable("Airport");

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedNever();
        }
    }
}
