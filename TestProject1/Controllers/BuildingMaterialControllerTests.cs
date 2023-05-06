using BuildingEnergyCalculator.Controllers;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Models;
using BuildingEnergyCalculator.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BuildingEnergyCalculator.Tests.Controllers
{
    public class BuildingMaterialControllerTests
    {
        private readonly Mock<IBuildingMaterialService> buildingMaterialStub = new();
        private readonly Random rand = new();

        [Fact]
        public void GetItem_WithUnexistingItem_ReturnsNotFound()
        {
            //arrange
            buildingMaterialStub.Setup(x => x.GetById(It.IsAny<int>()))
            .Returns((BuildingMaterialDto)null);

            var controller = new BuildingMaterialController(buildingMaterialStub.Object);

            //act
            var result = controller.GetItem(1);

            //assert
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void GetItem_WithExistingItem_ReturnsExpectedItem()
        {
            //arrange
            var expectedMaterial = CreateRandomBuildingMaterialDto();

            buildingMaterialStub.Setup(x => x.GetById(It.IsAny<int>()))
            .Returns(expectedMaterial);

            var controller = new BuildingMaterialController(buildingMaterialStub.Object);

            //act
            var result = controller.GetItem(1);

            //assert
            result.Value.Should().BeEquivalentTo(
            expectedMaterial, options => options.ComparingByMembers<BuildingMaterialDto>());
            //Assert.IsType<BuildingMaterialDto>(result.Value);
            //var dto = (result as ActionResult<BuildingMaterialDto>).Value;
            //Assert.Equal(expectedMaterial.Id, dto.Id);
            //Assert.Equal(expectedMaterial.Name, dto.Name);
        }

        [Fact]
        public void GetAll_WithExistingItems_ReturnsAll()
        {
            //arrange
            var expectedMaterials = new[] { CreateRandomBuildingMaterialDto(), CreateRandomBuildingMaterialDto(), CreateRandomBuildingMaterialDto() };
            buildingMaterialStub.Setup(x => x.GetAll())
                .Returns(expectedMaterials);

            var controller = new BuildingMaterialController(buildingMaterialStub.Object);

            //act
            var actualItems = controller.GetAll();

            //assert
            actualItems.Should().BeEquivalentTo(expectedMaterials,
                options => options.ComparingByMembers<BuildingMaterialDto>());
        }

        [Fact]
        public void CreateBuildingMaterial_WithItemToCreate_ReturnsCreatedItem()
        {
            //arrange
            var buildingMaterialToCreate = new CreateBuldingMaterialDto()
            {
                Name = Guid.NewGuid().ToString(),
                LambdaSW = rand.Next(1000),
                Thickness = 10 + DateTime.Now.Ticks,
                Description = $"Test + {DateTime.Now.Ticks}"
            };

            var controller = new BuildingMaterialController(buildingMaterialStub.Object);

            //act
            var result = controller.CreateBuildingMaterial(buildingMaterialToCreate);

            //assert
            var createdItem = (result as CreatedResult).Value as BuildingMaterialDto;
            buildingMaterialToCreate.Should().BeEquivalentTo(createdItem,
                options => options.ComparingByMembers<BuildingMaterialDto>().ExcludingMissingMembers());
            createdItem.Id.Should().NotBe(null);
        }

        [Fact]
        public void Update_WithExistingItem_ReturnsOk()
        {
            //arrange
            BuildingMaterialDto existingMaterial = CreateRandomBuildingMaterialDto();

            buildingMaterialStub.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(existingMaterial);

            var itemId = existingMaterial.Id;
            var itemToUpdate = new UpdateBuildingMaterialDto()
            {
                Name = Guid.NewGuid().ToString(),
                Description = $"Test + {DateTime.Now.Ticks}"

            };

            var controller = new BuildingMaterialController(buildingMaterialStub.Object);

            //act
            var result = controller.Update(itemToUpdate, itemId);

            //assert
            result.Should().BeOfType<OkResult>();

        }

        [Fact]
        public void Delete_WithExistingItem_ReturnsNoContent()
        {
            //arrange
            BuildingMaterialDto existingMaterial = CreateRandomBuildingMaterialDto();

            buildingMaterialStub.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(existingMaterial);


            var controller = new BuildingMaterialController(buildingMaterialStub.Object);

            //act
            var result = controller.Delete(existingMaterial.Id);

            //assert
            result.Should().BeOfType<NoContentResult>();

        }

        private BuildingMaterialDto CreateRandomBuildingMaterialDto()
        {
            return new()
            {
                Id = (int)DateTime.Now.Minute + (int)DateTime.Now.Ticks,
                Name = Guid.NewGuid().ToString(),
                LambdaSW = rand.Next(1000),
                Thickness = 10,
                Description = "Test"

            };


        }
    }
}