using System;
using Xunit;
using EduHub.Domain.Entities;

namespace EduHub.Tests
{
    public class RegistrationTests
    {
        [Fact]
        public void Create_WithValidIds_ShouldSetStatusToPending()
        {
            var memberId = Guid.NewGuid();
            var eventId = Guid.NewGuid();

            var registration = Registration.Create(memberId, eventId);

            Assert.NotNull(registration);
            Assert.Equal(memberId, registration.MemberId);
            Assert.Equal(eventId, registration.EventId);
            Assert.Equal(RegistrationStatus.Pending, registration.Status);
        }

        [Fact]
        public void Create_WithEmptyGuid_ShouldThrowArgumentException()
        {
            var emptyId = Guid.Empty;
            var validId = Guid.NewGuid();

            Assert.Throws<ArgumentException>(() => Registration.Create(emptyId, validId));
            Assert.Throws<ArgumentException>(() => Registration.Create(validId, emptyId));
        }

        [Fact]
        public void Confirm_WhenPending_ShouldSetStatusToConfirmed()
        {
            var registration = Registration.Create(Guid.NewGuid(), Guid.NewGuid());

            registration.Confirm();

            Assert.Equal(RegistrationStatus.Confirmed, registration.Status);
        }

        [Fact]
        public void Confirm_AfterCancelled_ShouldThrowInvalidOperationException_AndKeepStatusCancelled()
        {
            var registration = Registration.Create(Guid.NewGuid(), Guid.NewGuid());

            registration.Cancel();

            var exception = Assert.Throws<InvalidOperationException>(() => registration.Confirm());

            Assert.Equal("Chỉ xác nhận được phiếu Pending.", exception.Message);

            Assert.Equal(RegistrationStatus.Cancelled, registration.Status);
        }
    }
}