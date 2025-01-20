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
// //تست شد این مدلی انونیموس برای پراپرتی بنویسی خطا میده        
//         builder
//             .Property(c => new { c.Name }) //این مدلی برای پراپرتی خطا میداد، حالا باید تست بشه
//             .HasMaxLength(50);

        builder
            .HasIndex(c => new { c.Name })
            .IsUnique(unique: true)
            ;
    }
}