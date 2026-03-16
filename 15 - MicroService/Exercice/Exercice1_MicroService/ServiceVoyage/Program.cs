using Microsoft.EntityFrameworkCore;
using ServiceVoyage.Data;
using ServiceVoyage.Dto;
using ServiceVoyage.Models;
using ServiceVoyage.Repository;
using ServiceVoyage.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IRepository<Voyage>, VoyageRepository>();

builder.Services.AddScoped<IService<VoyageSend, VoyageReceive>, Service>();

string connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


app.UseAuthorization();
app.MapControllers();

app.Run();

