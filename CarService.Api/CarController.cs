using CarService.Domain;
using CarService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Api;

[ApiController] //not sure TODO
[Route("/api/v1/[controller]")]
public class CarController(CarRepository repository)
{
    [HttpPost]
    public async Task AddCar([FromBody] Car car)
    {
        await repository.Add(car);
    }

    [HttpGet(template: "GetAllCars")]
    public async Task<IEnumerable<Car>> GetAll()
    {
        var result = await repository.GetAll();
        return result;
    }

    //[Authorize(Policy = "CustomAuthentication")]
    [Authorize]
    [HttpGet("GetById/{id}")]
    public async Task<Car> GetById(Guid id)
    {
        var result = await repository.GetById(id);
        return result;
    }
}