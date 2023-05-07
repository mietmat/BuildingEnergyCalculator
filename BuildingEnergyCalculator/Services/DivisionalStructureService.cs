using AutoMapper;
using BuildingEnergyCalculator.Calculator;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Exceptions;
using BuildingEnergyCalculator.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace BuildingEnergyCalculator.Services
{
    public class DivisionalStructureService : IDivisionalStructureService
    {
        private readonly EnergyCalculatorDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IDivisionalStructureCalc _divisionalStructureCalc;

        public DivisionalStructureService(EnergyCalculatorDbContext dbContext, IMapper mapper, IDivisionalStructureCalc divisionalStructureCalc)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _divisionalStructureCalc = divisionalStructureCalc;
        }

        public int Create(CreateDivisionalStructureDto dto)
        {
            var thickness = _divisionalStructureCalc.CalculateThickness(dto.BuildingMaterials);
            dto.DivisionalThickness = thickness;
            var rSum = _divisionalStructureCalc.CalculateRSum(dto, dto.BuildingMaterials);
            dto.RSum = rSum;
            var U = _divisionalStructureCalc.CalculateU(dto.RSum);
            dto.U = U;

            var divisionalStructureEntity = new DivisionalStructure
            {
                Name = dto.Name,
                Description = dto.Description,
                DivisionalThickness = dto.DivisionalThickness,
                RSum = dto.RSum,
                U = dto.U,
                Rsi = dto.Rsi,
                Rse = dto.Rse,
                BuildingMaterials = new List<BuildingMaterial>()
            };

            foreach (var material in dto.BuildingMaterials)
            {
                var buildingMaterial = _mapper.Map<BuildingMaterial>(material);

                var existingBuildingMaterial = _dbContext.BuildingMaterials.Find(buildingMaterial.Id);

                if (existingBuildingMaterial != null)
                {
                    divisionalStructureEntity.BuildingMaterials.Add(existingBuildingMaterial);
                }

            }

            _dbContext.DivisionalStructures.Add(divisionalStructureEntity);
            _dbContext.SaveChanges();

            return divisionalStructureEntity.Id;

        }


        public void Delete(int id)
        {
            var itemToRemove = _dbContext.DivisionalStructures.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(itemToRemove);

            _dbContext.SaveChanges();

        }

        public IEnumerable<DivisionalStructureDto> GetAll()
        {
            var divisionalStructures = _dbContext.DivisionalStructures.Include(ds => ds.BuildingMaterials).ToList();

            var divisionalStructuresDtos = JsonConvert.DeserializeObject<List<DivisionalStructureDto>>(
                JsonConvert.SerializeObject(divisionalStructures, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    MaxDepth = 1
                })
                );
            return divisionalStructuresDtos;
        }

        public DivisionalStructureDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateDivisionalStructureDto dto, int id)
        {
            var divisionalStructure = _dbContext.DivisionalStructures.FirstOrDefault(x => x.Id == id);
            if (divisionalStructure is null)
                throw new NotFoundException("Material not found");

            var divisionalStructureEntity = _mapper.Map<DivisionalStructure>(dto);

            divisionalStructure.Id = id;
            divisionalStructure.Name = divisionalStructureEntity.Name;
            divisionalStructure.Description = divisionalStructureEntity.Description;
            divisionalStructure.Rsi = divisionalStructureEntity.Rsi;
            divisionalStructure.Rse = divisionalStructureEntity.Rse;

            //foreach (var material in dto.BuildingMaterials)
            //{
            //    var buildingMaterial = _mapper.Map<BuildingMaterial>(material);

            //    var existingBuildingMaterial = _dbContext.BuildingMaterials.Find(buildingMaterial.Id);

            //    if (existingBuildingMaterial != null)
            //    {
            //        divisionalStructureEntity.BuildingMaterials.Add(existingBuildingMaterial);
            //    }

            //}

            //divisionalStructure.BuildingMaterials = divisionalStructureEntity.BuildingMaterials;
            divisionalStructure.DivisionalThickness = _divisionalStructureCalc.CalculateThickness(dto.BuildingMaterials);


            _dbContext.SaveChanges();
        }
    }
}
