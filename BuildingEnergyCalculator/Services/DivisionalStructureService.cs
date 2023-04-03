using AutoMapper;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Exceptions;
using BuildingEnergyCalculator.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildingEnergyCalculator.Services
{
    public class DivisionalStructureService : IDivisionalStructureService
    {
        private readonly EnergyCalculatorDbContext _dbContext;
        private readonly IMapper _mapper;

        public DivisionalStructureService(EnergyCalculatorDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Create(CreateDivisionalStructureDto dto)
        {
            var divisionalStructureEntity = _mapper.Map<DivisionalStructure>(dto);

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
            throw new NotImplementedException();
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
