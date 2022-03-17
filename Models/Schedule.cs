using Hotel.DTOs;

namespace Hotel.Models;

public record Schedule
{
    public int Id { get; set; }
    public DateTimeOffset CheckIn { get; set; }
    public DateTimeOffset CheckOut { get; set; }
    public int GuestCount { get; set; }
    public double Price { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public int GuestId { get; set; }
    public int RoomId { get; set; }

    public ScheduleDTO asDto => new ScheduleDTO
    {
        CheckIn = CheckIn,
        CheckOut = CheckOut,
        GuestCount = GuestCount,
        Id = Id,
        Price = Price,
    };
}