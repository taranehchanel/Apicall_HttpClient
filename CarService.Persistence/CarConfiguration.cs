using CarService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CarService.Persistence;

internal sealed class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public CarConfiguration() : base()
    {
    }

    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder
            .HasIndex(c => new { c.Model })
            .IsUnique(unique: true)
            ;
        
        builder
            .HasIndex(c => new { c.Name })
            .IsUnique(unique: true)
            ;
    }
}