using Microsoft.EntityFrameworkCore;

namespace CarService.Service;

using CarService.Persistence;
using CarService.Domain;

public class CarRepository(CarDbContext dbContext)
{
    public async Task<IEnumerable<Car>> GetAll()
    {
        var result = await dbContext.Cars.ToListAsync();
        return result;
    }

    public async Task<Car> GetById(Guid id)
    {
        var result = await dbContext.Cars
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        return result ?? new Car("noModel", "NoName");
    }


    public async Task Add(Car car)
    {
        dbContext.Cars.Add(new Car(model: car.Model, name: car.Name)
        {
            Model = car.Model,
            Name = car.Name
        });
        await dbContext.SaveChangesAsync();
    }
}