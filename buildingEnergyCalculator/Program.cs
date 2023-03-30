using AutoMapper;
using BuildingEnergyCalculator;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<EnergyCalculatorSeeder>();
builder.Services.AddScoped<IBuildingMaterialService, BuildingMaterialService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<EnergyCalculatorDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EnergyCalculatorDbConnection")));


var app = builder.Build();

//configure
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<EnergyCalculatorSeeder>();

app.UseCors("FrontEndClient");
seeder.Seed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","buildingEnergyCalculator"));
}

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Building Energy Calculator");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
