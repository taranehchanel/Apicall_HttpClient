using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace CarService.Domain;

public class Car : object
{
    public Car(string model, string name) : base()
    {
        Id = System.Guid.NewGuid();
        ManufacturingDate = DateTime.Now;
        Model = model;
        Name = name;
    }

    [Key] public Guid Id { get; set; }
    [Required] public DateTime ManufacturingDate { get; set; }
    [Required] public string Model { get; set; }
    [Required] public string Name { get; set; }
}