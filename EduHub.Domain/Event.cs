namespace EduHub.Domain.Entities;

public class Event
{
    public Guid Id { get; private set; }
    public Guid ClubId { get; private set; }
    public string Title { get; private set; }
    public DateTime Date { get; private set; }
    public int Capacity { get; private set; }

    private Event(Guid id, Guid clubId, string title, DateTime date, int capacity)
    {
        Id = id; ClubId = clubId; Title = title; Date = date; Capacity = capacity;
    }

    public static Event Create(Guid clubId, string title, DateTime date, int capacity)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Tiêu đề không được rỗng.");
        if (capacity <= 0)
            throw new ArgumentException("Sức chứa phải lớn hơn 0.");

        return new Event(Guid.NewGuid(), clubId, title, date, capacity);
    }
}