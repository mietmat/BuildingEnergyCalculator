using AutoMapper;
using BuildingEnergyCalculator;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EnergyCalculatorDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EnergyCalculatorDbConnection")));
builder.Services.AddScoped<EnergyCalculatorSeeder>();
builder.Services.AddScoped<IBuildingMaterialService, BuildingMaterialService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BuildingEnergyCalculator", Version = "v1" });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontEndClient", policyBuilder =>
        policyBuilder.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins(builder.Configuration["AllowedOrigins"])
    );
});

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
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BuldingEnergyCalculator v1"));
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Building Energy Calculator");
});

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
