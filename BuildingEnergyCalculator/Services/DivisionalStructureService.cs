using AutoMapper;
using BuildingEnergyCalculator.Calculator;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Exceptions;
using BuildingEnergyCalculator.Models;
using Microsoft.EntityFrameworkCore;
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

            var divisionalStructureEntity = _mapper.Map<DivisionalStructure>(dto);           
            divisionalStructureEntity.BuildingMaterials.Clear();

            _dbContext.DivisionalStructures.Add(divisionalStructureEntity);
            _dbContext.SaveChanges();

            return divisionalStructureEntity.Id;
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DivisionalStructureDto> GetAll()
        {
            var divisionalStructures = _dbContext.DivisionalStructures.Include(ds => ds.BuildingMaterials).ToList();

            //var options = new JsonSerializerOptions
            //{
            //    ReferenceHandler = ReferenceHandler.Preserve
            //};

            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<DivisionalStructure, DivisionalStructureDto>()
            //        .ForMember(dest => dest.BuildingMaterials, opt => opt.MapFrom(src => src.BuildingMaterials))
            //        .ForMember(dest => dest.Id, opt => opt.Ignore())
            //        .ForMember(dest => dest.Name, opt => opt.Ignore())
            //        .ForMember(dest => dest.Description, opt => opt.Ignore())
            //        .ForMember(dest => dest.Rse, opt => opt.Ignore())
            //        .ForMember(dest => dest.Rsi, opt => opt.Ignore())
            //        .ForMember(dest => dest.DivisionalThickness, opt => opt.Ignore())
            //        .ForMember(dest => dest.U, opt => opt.Ignore())
            //        .ForMember(dest => dest.λ, opt => opt.Ignore())
            //        .ForMember(dest => dest.R, opt => opt.Ignore());
            //});

            //var mapper = config.CreateMapper();

            //var divisionalStructuresDtos = _mapper.Map<List<DivisionalStructureDto>>(divisionalStructures);
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
            throw new NotImplementedException();
        }
    }
}
