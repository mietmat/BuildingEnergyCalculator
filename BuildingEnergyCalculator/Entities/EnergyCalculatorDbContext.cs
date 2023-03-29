using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BuildingEnergyCalculator.Entities
{
    public class EnergyCalculatorDbContext : DbContext
    {
        public EnergyCalculatorDbContext(DbContextOptions<EnergyCalculatorDbContext> options) : base(options)
        { 
        
        }
        public DbSet<BuildingMaterial> BuildingMaterials { get; set; }
        public DbSet<Role> Roles { get; set; }



    }
}
