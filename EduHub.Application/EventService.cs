using EduHub.Domain.Entities;
using EduHub.Domain.Interfaces;

namespace EduHub.Application;

public class EventService
{
    private readonly IEventRepository _repository;
    private readonly INotificationService _notification;

    public EventService(IEventRepository repository, INotificationService notification)
    {
        _repository = repository;
        _notification = notification;
    }

    public Event CreateEvent(Guid clubId, string title, DateTime date, int capacity, string channel)
    {
        var ev = Event.Create(clubId, title, date, capacity);
        _repository.Add(ev);
        _notification.Send($"Sự kiện mới: {title}");
        return ev;
    }

    public IEnumerable<Event> GetEventsByClub(Guid clubId)
    {
        return _repository.GetByClubId(clubId);
    }

    public Event? GetById(Guid id)
    {
        return _repository.GetById(id);
    }

    public void Delete(Guid id)
    {
        _repository.Delete(id);
    }
}