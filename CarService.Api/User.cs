using System.Text.Json.Serialization;

namespace CarService.Api;

public class User
{
    public User()
    {
            
    }

    public int Id { get; set; }
    public string FirstName
    {
        get;
        set;
    }
    public string LastName
    {
        get;
        set;
    }
    public string Username
    {
        get;
        set;
    }
    [JsonIgnore]
    public string Password
    {
        get;
        set;
    }
}