using System;
using Moq;
using Xunit;
using EduHub.Application;
using EduHub.Domain.Entities;
using EduHub.Domain.Interfaces;

namespace EduHub.Tests;

public class EventServiceTests
{
    [Fact]
    public void CreateEvent_ValidData_CallsAddOnce()
    {
        var mockRepo = new Mock<IEventRepository>();
        var mockNotification = new Mock<INotificationService>(); 
        var service = new EventService(mockRepo.Object, mockNotification.Object);
        service.CreateEvent(Guid.NewGuid(), "Test Event", DateTime.Now, 100, "email");
        mockRepo.Verify(r => r.Add(It.IsAny<Event>()), Times.Once);
    }
}