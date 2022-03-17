using Hotel.DTOs;

namespace Hotel.Models;

public enum Gender
{
    Female = 1,
    Male = 2,
}

public record Guest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public long Mobile { get; set; }
    public string Email { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public string Address { get; set; }
    public Gender Gender { get; set; }

    public GuestDTO asDto => new GuestDTO
    {
        Email = Email,
        Id = Id,
        Mobile = Mobile,
        Name = Name,
    };
}