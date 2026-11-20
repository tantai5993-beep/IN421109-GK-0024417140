using System;

namespace EduHub.Application.DTOs;

public record EventResponse(Guid Id, Guid ClubId, string Title, DateTime Date, int Capacity);