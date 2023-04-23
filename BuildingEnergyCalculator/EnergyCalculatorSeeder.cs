using BuildingEnergyCalculator.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuildingEnergyCalculator
{
    public class EnergyCalculatorSeeder
    {
        private readonly EnergyCalculatorDbContext _dbContext;

        public EnergyCalculatorSeeder(EnergyCalculatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();//not implemented migration list
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();

                }

                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.BuildingMaterials.Any()) // sprawdzenie czy nie ma żadnego wiersza
                {
                    var buildingMaterials = GetBuildingMaterials();
                    _dbContext.BuildingMaterials.AddRange(buildingMaterials);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Manager"
                },
                new Role()
                {
                    Name = "Admin"
                }

            };
            return roles;
        }

        private IEnumerable<BuildingMaterial> GetBuildingMaterials()
        {
            var buildingMaterials = new List<BuildingMaterial>()
            {
                new BuildingMaterial()
                {
                    Name="Aluminium",
                    Description="AL",
                    LambdaSW=200,
                    LambdaW=200,
                    Ro=2700,
                    Cw=0.87
                    

                },
                new BuildingMaterial()
                {
                    Name="Beton",
                    Description="beton z kruszywa kamiennego - 1200",
                    LambdaSW=0.5,
                    LambdaW=0.6,
                    Ro=1200,
                    Cw=0.84



                },
                new BuildingMaterial()
                {
                    Name="Beton komórkowy",
                    Description="ściana z bloczków z betonu komórkowego - 500",
                    LambdaSW=0.25,
                    LambdaW=0.3,
                    Ro=500,
                    Cw=0.84


                },
                new BuildingMaterial()
                {
                    Name="Beton z kruszywa keramzytowego",
                    Description="beton z kruszywa keramzytowego 1000",
                    LambdaSW=0.39,
                    LambdaW=0.43,
                    Ro=1000,
                    Cw=0.84

                },
                new BuildingMaterial()
                {
                    Name="Maty z włókna szklanego",
                    Description="",
                    LambdaSW=0.045,
                    LambdaW=0.05,
                    Ro=80,
                    Cw=0.84

                },
                new BuildingMaterial()
                {
                    Name="Cegła dziurawka",
                    Description="mur z cegły dziurawki 120x250x65",
                    LambdaSW=0.64,
                    LambdaW=0.7,
                    Ro=1400,
                    Cw=0.88

                },


            };
            return buildingMaterials;
        }

        private IEnumerable<DivisionalStructure> GetDivisionalStructure()
        {
            var divisionalStructure = new List<DivisionalStructure>()
            {
                new DivisionalStructure()
                {
                    Description="ściana wewnętrzna",
                    DivisionalThickness=0.016,
                    RSum=1,
                    U=1,
                    Rse=1,
                    Rsi = 1
                }
             };

            return divisionalStructure;
        }
    }
}
