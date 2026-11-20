using System;

namespace EduHub.Application.DTOs;

public record CreateEventRequest(string Title, DateTime Date, int Capacity, string Channel);