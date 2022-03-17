using Microsoft.AspNetCore.Mvc;
using Hotel.Models;
using Hotel.Repositories;
using Hotel.DTOs;

namespace Hotel.Controllers;

[ApiController]
[Route("api/schedule")]
public class ScheduleController : ControllerBase
{
    private readonly ILogger<ScheduleController> _logger;
    private readonly IScheduleRepository _schedule;
    private readonly IGuestRepository _guest;
    private readonly IRoomRepository _room;

    public ScheduleController(ILogger<ScheduleController> logger, IScheduleRepository schedule,
    IGuestRepository guest, IRoomRepository room)
    {
        _logger = logger;
        _schedule = schedule;
        _guest = guest;
        _room = room;
    }

    [HttpGet]
    public async Task<ActionResult<List<Schedule>>> GetList()
    {
        var res = await _schedule.GetList();

        return Ok(res.Select(x => x.asDto));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ScheduleDTO>> GetById([FromRoute] int id)
    {
        var res = await _schedule.GetById(id);

        if (res == null)
            return NotFound();

        var dto = res.asDto;
        dto.Guest = (await _guest.GetListByScheduleId(id)).Select(x => x.asDto).ToList();
        dto.Room = (await _room.GetListByScheduleId(id)).asDto;

        return Ok(dto);

    }

   [HttpPost]
    public async Task<ActionResult<ScheduleDTO>> Create([FromBody] ScheduleCreateDTO Data)
    {
        
          var toCreateSchedule = new Schedule
        {
          CheckIn = Data.CheckIn,
          CheckOut = Data.CheckOut,
          CreatedAt = Data.CreatedAt,
          GuestCount = Data.GuestCount,
          Price = Data.Price,
          GuestId = Data.GuestId,
          RoomId = Data.RoomId,
           
          
        };

        var res = await _schedule.Create(toCreateSchedule);

        return StatusCode(StatusCodes.Status201Created, res.asDto);


    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] ScheduleUpdateDTO Data)
    {
          var existingSchedule = await _schedule.GetById(id);

        if (existingSchedule == null)
            return NotFound();

        var toUpdateSchedule = existingSchedule with
        {
            Price = Data.Price,
         
        };

        var didUpdate = await _schedule.Update(toUpdateSchedule);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError);

        return NoContent();


    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
         var existing = await _schedule.GetById(id);
        if (existing is null)
            return NotFound("No staff found with given Id");

        var didDelete = await _schedule.Delete(id);

        return NoContent();


    }
}
