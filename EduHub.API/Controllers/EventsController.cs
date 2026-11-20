using Microsoft.AspNetCore.Mvc;
using EduHub.Domain.Entities;
using EduHub.Application;

namespace EduHub.API.Controllers;

public record CreateEventRequest(string Title, DateTime Date, int Capacity, string Channel);

[ApiController]
public class EventsController : ControllerBase
{
    private readonly EventService _eventService;

    public EventsController(EventService eventService)
    {
        _eventService = eventService;
    }

    // 1. Lấy danh sách sự kiện của CLB
    [HttpGet("api/clubs/{clubId:guid}/events")]
    public ActionResult<IEnumerable<Event>> GetByClub(Guid clubId)
    {
        var events = _eventService.GetEventsByClub(clubId);
        return Ok(events);
    }

    // 2. Xem một sự kiện theo Id (ĐÂY LÀ HÀM BẠN ĐANG THIẾU)
    [HttpGet("api/events/{id:guid}")]
    public ActionResult<Event> GetById(Guid id)
    {
        var ev = _eventService.GetById(id);
        if (ev is null) return NotFound(new { message = $"Event {id} not found" });
        return Ok(ev);
    }

    // 3. Tạo sự kiện mới cho CLB
    [HttpPost("api/clubs/{clubId:guid}/events")]
    public ActionResult<Event> Create(Guid clubId, [FromBody] CreateEventRequest request)
    {
        try
        {
            var ev = _eventService.CreateEvent(clubId, request.Title, request.Date, request.Capacity, request.Channel);
            return CreatedAtAction(nameof(GetById), new { id = ev.Id }, ev);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // 4. Xoá một sự kiện
    [HttpDelete("api/events/{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        _eventService.Delete(id);
        return NoContent();
    }
}