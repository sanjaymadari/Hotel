

using System.Text.Json.Serialization;
using Hotel.Models;
namespace Hotel.DTOs;
public record StaffDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("date_of_birth")]
    public DateTimeOffset DateOfBirth { get; set; }
    
    [JsonPropertyName("gender")]
    public Gender Gender { get; set; }
    
    [JsonPropertyName("mobile")]
    public long Mobile { get; set; }
    
    [JsonPropertyName("shift")]
    public StaffShift Shift { get; set; }
    
    [JsonPropertyName("rooms_assigned")]
    public List<RoomDTO> Rooms { get; set; }

}
public record StaffCreateDTO
{
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("date_of_birth")]
    public DateTimeOffset DateOfBirth { get; set; }
    
    [JsonPropertyName("gender")]
    public Gender Gender { get; set; }
    
    [JsonPropertyName("mobile")]
    public long Mobile { get; set; }
    
    [JsonPropertyName("shift")]
    public StaffShift Shift { get; set; }

}

