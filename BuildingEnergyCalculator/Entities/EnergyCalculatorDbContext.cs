using BuildingEnergyCalculator.Entities.Library;
using BuildingEnergyCalculator.Entities.Project;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public DbSet<BuildingParameters> BuildingParameters { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<Window> Windows { get; set; }
        public DbSet<BuildingInformation> BuildingInformation { get; set; }
        public DbSet<FloorOnTheGround> FloorOnTheGround { get; set; }
        public DbSet<Investor> Investors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BuildingObject> BuildingObjects { get; set; }
        public DbSet<ProjectModel> ProjectModels { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<KNR> KNRs { get; set; }

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
            //modelBuilder.Entity<Door>()
            //    .ToTable("Doors");

            //if you have additional prop in door but not in BuildingHole
            //modelBuilder.Entity<Door>()
            //.Property(d => d.Material)
            //.HasMaxLength(50);



            ////1:1
            //modelBuilder.Entity<Investment>()
            //    .HasOne(u => u.Address)
            //    .WithOne(a => a.Investment)
            //    .HasForeignKey<Address>(a => a.InvestmentId);

            //modelBuilder.Entity<Investor>()
            //    .HasOne(u => u.Address)
            //    .WithOne(a => a.Investor)
            //    .HasForeignKey<Address>(a => a.InvestorId);

            ////1:many
            //modelBuilder.Entity<Investor>()
            //    .HasMany(u => u.Investments)
            //    .WithOne(c => c.Investor)
            //    .HasForeignKey(c => c.InvestorId);
            ////whether is correct ?
            //modelBuilder.Entity<Investment>()
            //   .HasOne(u => u.Investor)
            //   .WithMany(c => c.Investments)
            //   .OnDelete(DeleteBehavior.ClientSetNull);




            //modelBuilder.Entity<Address>()
            //    .HasKey(x => new { x.InvestorId, x.InvestmentId });

            //modelBuilder.Entity<Address>()
            //    .HasOne(x => x.Investor)
            //    .WithMany(z => z.Investments)
            //    .HasForeignKey(x => x.InvestorId)
            //    .OnDelete(DeleteBehavior.ClientSetNull);

            //modelBuilder.Entity<Address>()
            //   .HasOne(x => x.Investment)
            //   .WithMany(z => z.Investor)
            //   .HasForeignKey(x => x.InvestmentId)
            //   .OnDelete(DeleteBehavior.ClientSetNull);


        }


    }
}
