using AutoMapper;
using BuildingEnergyCalculator;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Helpers;
using BuildingEnergyCalculator.Models;
using BuildingEnergyCalculator.Models.Validators;
using BuildingEnergyCalculator.Services;
using CalcServer.BuildingParameters;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// configure service

var authenticationSettings = new AuthenticationSettings();

builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);

builder.Services.AddSingleton(authenticationSettings);
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //option.DefaultScheme = "Bearer";

}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EnergyCalculatorDbContext>
//(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EnergyCalculatorDbConnection")));
(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EnergyCalculatorDbConnection2")));
builder.Services.AddScoped<EnergyCalculatorSeeder>();
builder.Services.AddScoped<IBuildingMaterialService, BuildingMaterialService>();
builder.Services.AddScoped<IDivisionalStructureService, DivisionalStructureService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
builder.Services.AddScoped<IUserContextService, UserContextService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IBuildingParametersService, BuildingParametersService>();
builder.Services.AddScoped<IBuildingInformationService, BuildingInformationService>();
builder.Services.AddScoped<IDoorService, DoorService>();
builder.Services.AddScoped<ICalculator, Calculator>();
builder.Services.AddScoped<IWindowService, WindowService>();
builder.Services.AddScoped<IFloorOnTheGroundService, FloorOnTheGroundService>();
builder.Services.AddScoped<DataPreparer>();
builder.Services.AddScoped<IProjectModelService, ProjectModelService>();
builder.Services.AddScoped<ISolutionService, SolutionService>();
builder.Services.AddHttpContextAccessor();


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
public partial class Program { }

