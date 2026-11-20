using EduHub.Domain.Entities;
namespace EduHub.Domain.Interfaces;

public interface IEventRepository
{
    void Add(Event ev);
    Event? GetById(Guid id);
    IEnumerable<Event> GetByClubId(Guid clubId);
    void Delete(Guid id);
}