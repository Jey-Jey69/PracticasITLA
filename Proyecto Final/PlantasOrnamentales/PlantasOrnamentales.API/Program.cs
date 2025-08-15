using Microsoft.EntityFrameworkCore;
using PlantasOrnamentales.Application.Contracts;
using PlantasOrnamentales.Application.Services;
using PlantasOrnamentales.Domain.Interfaces;
using PlantasOrnamentales.Infrastructure.Data;
using PlantasOrnamentales.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPlantaRepository, PlantaRepository>();
builder.Services.AddScoped<IPlantaService, PlantaService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// app.UseAuthorization();

app.MapControllers();
app.Run();
