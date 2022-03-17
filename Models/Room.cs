using Hotel.DTOs;
namespace Hotel.Models;

public enum RoomType
{
    Regular = 1,
    Double = 2,
    Master = 3,
    Suite = 4,
}

public record Room
{
    public int Id { get; set; }
    public RoomType Type { get; set; }
    public int Size { get; set; }
    public double Price { get; set; }
    public int StaffId { get; set; }
    public string StaffName { get; set; }

    public RoomDTO asDto => new RoomDTO
    {
        Id = Id,
        Size = Size,
        Type = Type.ToString(),
        StaffName = StaffName,
    };
}