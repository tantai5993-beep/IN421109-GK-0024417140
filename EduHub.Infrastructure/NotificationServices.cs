using EduHub.Domain.Interfaces;
namespace EduHub.Infrastructure;

public class EmailNotificationService : INotificationService
{
    public void Send(string message) => Console.WriteLine($"[EMAIL] {message}");
}

public class SmsNotificationService : INotificationService
{
    public void Send(string message) => Console.WriteLine($"[SMS] {message}");
}

public class NotificationFactory
{
    public static INotificationService GetService(string channel)
    {
        return channel.ToLower() switch
        {
            "email" => new EmailNotificationService(),
            "sms" => new SmsNotificationService(),
            _ => throw new ArgumentException("Kênh không hợp lệ")
        };
    }
}