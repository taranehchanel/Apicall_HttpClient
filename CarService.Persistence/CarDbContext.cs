using CarService.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarService.Persistence;

public sealed class CarDbContext : DbContext
{
    public CarDbContext(DbContextOptions<CarDbContext> options) : base(options: options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Car> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly
            (assembly: typeof(CarDbContext).Assembly);

        modelBuilder.Seed();
    }
}