using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Hotel.Models;

namespace Hotel.DTOs;

public record GuestDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("mobile")]
    public long Mobile { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("schedules")]
    public List<ScheduleDTO> Schedules { get; set; }

    [JsonPropertyName("rooms")]
    public List<RoomDTO> Rooms { get; set; }
}

public record GuestCreateDTO
{
    [JsonPropertyName("name")]
    [Required]
    [MinLength(3)]
    [MaxLength(255)]
    public string Name { get; set; }

    [JsonPropertyName("mobile")]
    [Required]
    public long Mobile { get; set; }

    [JsonPropertyName("email")]
    [Required]
    [MaxLength(255)]
    public string Email { get; set; }

    [JsonPropertyName("date_of_birth")]
    [Required]
    public DateTimeOffset DateOfBirth { get; set; }

    [JsonPropertyName("address")]
    [MaxLength(255)]
    public string Address { get; set; }

    [JsonPropertyName("gender")]
    [Required]
    public Gender Gender { get; set; }
}