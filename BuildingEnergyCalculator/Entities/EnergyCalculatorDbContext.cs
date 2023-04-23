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
        public DbSet<DivisionalStructure> DivisionalStructures { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BuildingMaterialDivisionalStructure> BuildingMaterialDivisionalStructures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuildingMaterial>()
                .HasMany(m => m.DivisionalStructures)
                .WithMany(d => d.BuildingMaterials)
                .UsingEntity<BuildingMaterialDivisionalStructure>(
                    m => m.HasOne(mid => mid.DivisionalStructure)
                    .WithMany()
                    .HasForeignKey(mid => mid.DivisionalStructureId),
                    m => m.HasOne(mid => mid.BuildingMaterial)
                    .WithMany()
                    .HasForeignKey(mid => mid.BuildingMaterialId),

                    mid =>
                    {
                        mid.HasKey(x => new { x.DivisionalStructureId, x.BuildingMaterialId });
                    }
                );

            //modelBuilder.Entity<BuildingMaterialDivisionalStructure>()
            //    .HasKey(c => new { c.BuildingMaterialId, c.DivisionalStructureId });

        }


    }
}
