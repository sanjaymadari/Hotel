using System.Text.Json.Serialization;

namespace Hotel.DTOs;

public record ScheduleDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("check_in")]
    public DateTimeOffset CheckIn { get; set; }

    [JsonPropertyName("check_out")]
    public DateTimeOffset CheckOut { get; set; }

    [JsonPropertyName("guest_count")]
    public int GuestCount { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("room")]
    public RoomDTO Room { get; set; }
    
    [JsonPropertyName("guest")]
    public List<GuestDTO> Guest { get; set; }

}


public record ScheduleCreateDTO
{

    [JsonPropertyName("check_in")]
    public DateTimeOffset CheckIn { get; set; }

    [JsonPropertyName("check_out")]
    public DateTimeOffset CheckOut { get; set; }

    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
    
    [JsonPropertyName("guest_id")]
     public int GuestId { get; set; }
    
    [JsonPropertyName("room_id")]
     public int RoomId { get; set; }

    [JsonPropertyName("guest_count")]
    public int GuestCount { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

}

public record ScheduleUpdateDTO
{
    [JsonPropertyName("price")]
    public double Price { get; set; }

}