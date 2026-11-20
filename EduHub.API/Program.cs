using EduHub.Infrastructure;
using EduHub.Application;
using EduHub.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IEventRepository, InMemoryEventRepository>();
builder.Services.AddScoped<INotificationService, EmailNotificationService>();

builder.Services.AddScoped<EventService>();

var app = builder.Build();

app.Environment.EnvironmentName = "Development";

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();