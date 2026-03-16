using Microsoft.EntityFrameworkCore;
using ReservationService.Data;
using ReservationService.Dto;
using ReservationService.Dtos;
using ReservationService.Models;
using ReservationService.Repository;
using ReservationService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IRepository<Reservation>, ReservationRepository>();

builder.Services.AddScoped<IService<ReservationSend, ReservationReceive>, Service>();

string connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


app.UseAuthorization();
app.MapControllers();

app.Run();

