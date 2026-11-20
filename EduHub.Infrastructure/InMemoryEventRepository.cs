using EduHub.Domain.Entities;
using EduHub.Domain.Interfaces;

namespace EduHub.Infrastructure;

public class InMemoryEventRepository : IEventRepository
{
    private static readonly List<Event> _events = new();

    public void Add(Event ev) => _events.Add(ev);
    public Event? GetById(Guid id) => _events.FirstOrDefault(e => e.Id == id);
    public IEnumerable<Event> GetByClubId(Guid clubId) => _events.Where(e => e.ClubId == clubId);
    public void Delete(Guid id) => _events.RemoveAll(e => e.Id == id);
}