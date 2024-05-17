using AutoMapper;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Entities.Library;
using BuildingEnergyCalculator.Entities.Project;
using BuildingEnergyCalculator.Exceptions;
using BuildingEnergyCalculator.Helpers;
using BuildingEnergyCalculator.Models;
using CalcServer.BuildingParameters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace BuildingEnergyCalculator.Services
{
    public class DivisionalStructureService : IDivisionalStructureService
    {
        private readonly EnergyCalculatorDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICalculator _calculator;
        private readonly DataPreparer _dataPreparer;

        public DivisionalStructureService(EnergyCalculatorDbContext dbContext,
            IMapper mapper,
            ICalculator calculator,
            DataPreparer dataPreparer)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _calculator = calculator;
            _dataPreparer = dataPreparer;
        }

        public int Create(CreateDivisionalStructureDto dto)
        {
            var thicknessesList = _dataPreparer.CalculateTotalThicknessForDivisionalStructure(dto.BuildingMaterials);
            var totalThickness = _calculator.CalculateTotalThickness(thicknessesList);
            dto.DivisionalThickness = totalThickness;
            var rList = _dataPreparer.PrepareRList(dto.BuildingMaterials);
            var rSum = _calculator.CalculateRSum(dto.Rsi, dto.Rse, rList);
            dto.RSum = rSum;
            var U = _calculator.CalculateU(rSum);
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
            if (itemToRemove == null)
                throw new NotFoundException("Divisional Structure not found");

            _dbContext.DivisionalStructures.Remove(itemToRemove);

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
            var divisionalStructure = _dbContext.DivisionalStructures.FirstOrDefault(x => x.Id == id);

            if (divisionalStructure is null)
                throw new NotFoundException("Divisional Structure not found");

            var divisionalStructureDto = _mapper.Map<DivisionalStructureDto>(divisionalStructure);

            return divisionalStructureDto;
        }

        public void Update(UpdateDivisionalStructureDto dto, int id)
        {
            var divisionalStructure = _dbContext.DivisionalStructures.Include(ds => ds.BuildingMaterials).FirstOrDefault(x => x.Id == id); 
            if (divisionalStructure is null)
                throw new NotFoundException("Material not found");

            var divisionalStructureEntity = _mapper.Map<DivisionalStructure>(dto);

            divisionalStructure.Name = divisionalStructureEntity.Name;
            divisionalStructure.Description = divisionalStructureEntity.Description;
            divisionalStructure.Rsi = divisionalStructureEntity.Rsi;
            divisionalStructure.Rse = divisionalStructureEntity.Rse;


            var thicknessesList = _dataPreparer.CalculateTotalThicknessForDivisionalStructure(dto.BuildingMaterials);
            var totalThickness = _calculator.CalculateTotalThickness(thicknessesList);
            divisionalStructure.DivisionalThickness = totalThickness;

            divisionalStructure.BuildingMaterials.Clear();

            foreach (var materialDto in dto.BuildingMaterials)
            {
                var material = _dbContext.BuildingMaterials.FirstOrDefault(m => m.Id == materialDto.Id);
                if (material != null)
                {
                    divisionalStructure.BuildingMaterials.Add(material);
                }
            }
            _dbContext.SaveChanges();
        }
    }
}
