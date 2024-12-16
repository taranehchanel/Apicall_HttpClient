using Microsoft.EntityFrameworkCore;
using CarService.Domain;

namespace CarService.Persistence;

internal static class ModelBuilderExtenssion
{
    static ModelBuilderExtenssion()
    {
    }

    public static void Seed(this ModelBuilder modelBuilder)
    {
        Car car;
        for (int i = 0; i <= 9; i++)
        {
            string model = $"CarModel{i}";
            string name = $"CarName{i} ";

            car = new Car(model: model, name: name) { };

            modelBuilder.Entity<Car>().HasData(data: car);
        }
    }
}