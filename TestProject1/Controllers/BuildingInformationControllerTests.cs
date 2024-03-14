using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Entities.Project;
using BuildingEnergyCalculator.IntegrationTests;
using BuildingEnergyCalculator.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace BuildingEnergyCalculator.Tests.Controllers
{
    public class BuildingInformationControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        public BuildingInformationControllerTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var dbContextOptions = services.SingleOrDefault
                        (service => service.ServiceType == typeof(DbContextOptions<EnergyCalculatorDbContext>));

                        services.Remove(dbContextOptions);

                        services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();//to avoid authentication, authorization
                        services.AddMvc(option => option.Filters.Add(new FakeUserFilter()));

                        services
                         .AddDbContext<EnergyCalculatorDbContext>(options => options.UseInMemoryDatabase("BuildingEnergyCalculatorDb"));

                    });
                })
                .CreateClient();
        }

        [Theory]
        [InlineData("api/buildinginformation")]
        public async Task GetAll_WhenSentGetRequest_ReturnsOkResult(string path)
        {

            // act
            var response = await _httpClient.GetAsync(path);
            var content = await response.Content.ReadAsStringAsync();

            // assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("api/buildinginformation/1")]
        [InlineData("api/buildinginformation/2")]
        [InlineData("api/buildinginformation/3")]
        public async Task GetById_WhenSentGetByIdRequest_ReturnsOkResult(string path)
        {
            // act
            var response = await _httpClient.GetAsync(path);
            var content = await response.Content.ReadAsStringAsync();

            // assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("api/buildinginformation/3333")]
        [InlineData("api/buildinginformation/4444")]
        public async Task GetById_WhenSentGetByIdRequest_InternalServerError(string path)
        {
            // act
            var response = await _httpClient.GetAsync(path);
            var content = await response.Content.ReadAsStringAsync();

            // assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async Task Create_WithValidModel_ReturnsCreatedStatus()
        {
            //arrange
            var model = new CreateBuildingInformationDto()
            {
                Name = "TestBuildingInfo",
                Description = "test",
                Address = new Address()
                {
                    City = "Cracow",
                    Street = "Długa 10",
                    PostalCode = "31-508"
                },
                Investor = new Investor()
                {
                    Name = "Hugon",
                    LastName = "Karp",
                    PhoneNumber = "888777444",
                    Email = "hugonkarp@gmail.com",
                    Address = new Address()
                    {
                        City = "Warsaw",
                        Street = "Krótka 8",
                        PostalCode = "35-508"
                    }
                }

            };
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            //act
            var response = await _httpClient.PostAsync("/api/buildinginformation", httpContent);

            //assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            response.Headers.Location.Should().NotBeNull();
        }
    }
}
