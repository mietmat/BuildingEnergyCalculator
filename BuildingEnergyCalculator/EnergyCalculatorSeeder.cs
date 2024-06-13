using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Entities.Library;
using BuildingEnergyCalculator.Entities.Project;
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
                if (_dbContext.Database.IsRelational())// for inMemoryDbContext it avoid taking data from not relational db
                {
                    var pendingMigrations = _dbContext.Database.GetPendingMigrations();//not implemented migration list
                    if (pendingMigrations != null && pendingMigrations.Any())
                    {
                        _dbContext.Database.Migrate();

                    }
                }


                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.BuildingMaterials.Any())
                {
                    var buildingMaterials = GetBuildingMaterials();
                    _dbContext.BuildingMaterials.AddRange(buildingMaterials);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.BuildingInformation.Any())
                {
                    var buildingInformations = GetBuildingInformations();
                    _dbContext.BuildingInformation.AddRange(buildingInformations);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.KNRs.Any())
                {
                    var KNRs = GetKNRs();
                    _dbContext.KNRs.AddRange(KNRs);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<KNR> GetKNRs()
        {
            var knrs = new List<KNR>()
            {
                new KNR
                {
                    KNRName = "Budowle i roboty ziemne",
                    KNRNo = "KNR 2-01",
                    TableNo = "0221",
                    Topic = "WYKOPY JAMISTE WYKONYWANE KOPARKAMI PODSIĘBIERNYMI NA ODKŁAD",
                    OccupationList = new List<Occupation>
                    {
                        new Occupation
                        {
                            Name = "Robotnicy - grupa I",
                            WorkLoad = 9.1,
                            ColumnNo = "01",
                            Description = "Koparka podsiębierna 0,15m3, kategoria gruntu I-II"
                        },
                        new Occupation
                        {
                            Name = "Robotnicy - grupa I",
                            WorkLoad = 12.4,
                            ColumnNo = "02",
                            Description = "Koparka podsiębierna 0,15m3, kategoria gruntu III"

                        },
                        new Occupation
                        {
                            Name = "Robotnicy - grupa I",
                            WorkLoad = 9.1,
                            ColumnNo = "03",
                            Description = "Koparka podsiębierna 0,25m3, kategoria gruntu I-II"
                                                    },
                        new Occupation
                        {
                            Name = "Robotnicy - grupa I",
                            WorkLoad = 11.24,
                            ColumnNo = "04",
                            Description = "Koparka podsiębierna 0,25m3, kategoria gruntu III"
                        },
                        new Occupation
                        {
                            Name = "Robotnicy - grupa I",
                            WorkLoad = 6.00,
                            ColumnNo = "05",
                            Description = "Koparka podsiębierna 0,40m3, kategoria gruntu I-II"
                                                    },
                        new Occupation
                        {
                            Name = "Robotnicy - grupa I",
                            WorkLoad = 8.9,
                            ColumnNo = "06",
                            Description = "Koparka podsiębierna 0,40m3, kategoria gruntu III"
                        },
                        new Occupation
                        {
                            Name = "Robotnicy - grupa I",
                            WorkLoad = 6.00,
                            ColumnNo = "07",
                            Description = "Koparka podsiębierna 0,60m3, kategoria gruntu I-II"
                                                    },
                        new Occupation
                        {
                            Name = "Robotnicy - grupa I",
                            WorkLoad = 8.9,
                            ColumnNo = "08",
                            Description = "Koparka podsiębierna 0,60m3, kategoria gruntu III"
                        },
                        new Occupation
                        {
                            Name = "Robotnicy - grupa I",
                            WorkLoad = 9.4,
                            ColumnNo = "09",
                            Description = "Koparka podsiębierna 0,60m3, kategoria gruntu IV"
                        }

                    },
                    MachineList = new List<KNRMachine>
                    {
                        new KNRMachine
                        {
                            Name = "Koparka 0,15m3 na podwoziu ciągnika kołowego",
                            WorkLoad = 7.25,
                            ColumnNo = "01",
                            Description = "Koparka podsiębierna 0,15m3, kategoria gruntu I-II"
                        },
                        new KNRMachine
                        {
                            Name = "Koparka 0,15m3 na podwoziu ciągnika kołowego",
                            WorkLoad = 9.24,
                            ColumnNo = "02",
                            Description = "Koparka podsiębierna 0,15m3, kategoria gruntu III"
                        },
                        new KNRMachine
                        {
                            Name = "Koparka gąsiennicowa 0,25m3",
                            WorkLoad = 5.98,
                            ColumnNo = "03",
                            Description = "Koparka podsiębierna 0,25m3, kategoria gruntu I-II"
                        },
                        new KNRMachine
                        {
                            Name = "Koparka gąsiennicowa 0,25m3",
                            WorkLoad = 7.82,
                            ColumnNo = "04",
                            Description = "Koparka podsiębierna 0,25m3, kategoria gruntu III"
                        },
                        new KNRMachine
                        {
                            Name = "Koparka gąsiennicowa 0,40m3",
                            WorkLoad = 4.56,
                            ColumnNo = "05",
                            Description = "Koparka podsiębierna 0,40m3, kategoria gruntu I-II"
                        },
                        new KNRMachine
                        {
                            Name = "Koparka gąsiennicowa 0,40m3",
                            WorkLoad = 5.95,
                            ColumnNo = "06",
                            Description = "Koparka podsiębierna 0,40m3, kategoria gruntu III"
                        },
                        new KNRMachine
                        {
                            Name = "Koparka gąsiennicowa 0,60m3",
                            WorkLoad = 4.04,
                            ColumnNo = "07",
                            Description = "Koparka podsiębierna 0,60m3, kategoria gruntu I-II"
                        },
                        new KNRMachine
                        {
                            Name = "Koparka gąsiennicowa 0,60m3",
                            WorkLoad = 4.72,
                            ColumnNo = "08",
                            Description = "Koparka podsiębierna 0,60m3, kategoria gruntu III"
                        },
                        new KNRMachine
                        {
                            Name = "Koparka gąsiennicowa 0,60m3",
                            WorkLoad = 5.64,
                            ColumnNo = "09",
                            Description = "Koparka podsiębierna 0,60m3, kategoria gruntu IV"
                        }
                    },
                    LaborList = new List<Labor>
                    {
                        new Labor
                        {
                            Description = "1. Odspojenie gruntu koparką ze złożeniem urobku na odkład bezpośrednio przy wykopie."
                        },
                        new Labor
                        {
                            Description = "2. Ręczne zsuwanie odspojonych brył gruntu ze skarpy pod koparkę oraz wyrównanie dna wykopu."
                        }
                    }
                }
            };
            return knrs;

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

        private IEnumerable<BuildingInformation> GetBuildingInformations()
        {
            var buildingInformations = new List<BuildingInformation>()
            {
                new BuildingInformation()
                {
                    Name= "PK",
                    Description= "Offices",
                    Address = new Address()
                    {
                        City= "Cracow",
                        Street= "Pawia 5",
                        PostalCode= "31-201"
                    },
                    Investor = new Investor()
                    {
                        Name= "Hugon",
                        LastName= "Karp",
                        PhoneNumber= "888777444",
                        Email= "hugonkarp@gmail.com",
                        Address= new Address()
                        {
                            City= "Warsaw",
                            Street= "Krótka 8",
                            PostalCode= "35-508"
                        }
                    },
                    BuildingParameters= new BuildingParameters()
                    {
                        BuildingLengthN= 10,
                        BuildingLengthE= 20,
                        BuildingLengthS= 10,
                        BuildingLengthW= 20,
                        StoreyHeightNet= 0,
                        StoreyHeightGross= 0,
                        CellarHeight = 0,
                        StoreyQuantity= 0,
                        BuildingArea= 0,
                        StaircaseSurface= 0,
                        UsableAreaOfTheStairCase= 0,
                        StaircaseWidth= 0,
                        HeatAtticArea= 0,
                        UnheatedAtticArea= 0,
                        UsableAreaOfTheBuilding= 0,
                        AtticUsableArea= 0,
                        BalconyLength= 0,
                        TotalWindowAreaN= 0,
                        TotalWindowAreaE= 0,
                        TotalWindowAreaS= 0,
                        TotalWindowAreaW= 0,
                        TotalDoorAreaN= 0,
                        TotalDoorAreaE= 0,
                        TotalDoorAreaS= 0,
                        TotalDoorAreaW= 0,
                        Windows = new List<Window>()
                        {
                            new Window()
                            {
                                Name = "Window 1",
                                Description="Velux",
                                Width= 1,
                                Height= 20,
                                Perimeter= 30,
                                Quantity= 40,
                                SingleArea= 0,
                                U= 0,
                                CardinalDirection= "N",
                                Floor= 0

                            }
                        },
                        Doors = new List<Door>()
                        {
                            new Door()
                            {
                                Name = "Door 1",
                                Description="Velux",
                                Width= 5,
                                Height= 6,
                                Perimeter= 8,
                                Quantity= 0,
                                SingleArea= 0,
                                U= 0,
                                CardinalDirection= "S",
                                Floor= 0

                            }
                        }




                    }
                },
                 new BuildingInformation()
                {
                    Name= "PK",
                    Description= "Offices",
                    Address = new Address()
                    {
                        City= "Cracow",
                        Street= "Pawia 5",
                        PostalCode= "31-201"
                    },
                    Investor = new Investor()
                    {
                        Name= "Hugon",
                        LastName= "Karp",
                        PhoneNumber= "888777444",
                        Email= "hugonkarp@gmail.com",
                        Address= new Address()
                        {
                            City= "Warsaw",
                            Street= "Krótka 8",
                            PostalCode= "35-508"
                        }
                    },
                    BuildingParameters= new BuildingParameters()
                    {
                        BuildingLengthN= 10,
                        BuildingLengthE= 20,
                        BuildingLengthS= 10,
                        BuildingLengthW= 20,
                        StoreyHeightNet= 0,
                        StoreyHeightGross= 0,
                        CellarHeight = 0,
                        StoreyQuantity= 0,
                        BuildingArea= 0,
                        StaircaseSurface= 0,
                        UsableAreaOfTheStairCase= 0,
                        StaircaseWidth= 0,
                        HeatAtticArea= 0,
                        UnheatedAtticArea= 0,
                        UsableAreaOfTheBuilding= 0,
                        AtticUsableArea= 0,
                        BalconyLength= 0,
                        TotalWindowAreaN= 0,
                        TotalWindowAreaE= 0,
                        TotalWindowAreaS= 0,
                        TotalWindowAreaW= 0,
                        TotalDoorAreaN= 0,
                        TotalDoorAreaE= 0,
                        TotalDoorAreaS= 0,
                        TotalDoorAreaW= 0,
                        Windows = new List<Window>()
                        {
                            new Window()
                            {
                                Name = "Window 1",
                                Description="Velux",
                                Width= 1,
                                Height= 20,
                                Perimeter= 30,
                                Quantity= 40,
                                SingleArea= 0,
                                U= 0,
                                CardinalDirection= "N",
                                Floor= 0

                            }
                        },
                        Doors = new List<Door>()
                        {
                            new Door()
                            {
                                Name = "Door 1",
                                Description="Velux",
                                Width= 5,
                                Height= 6,
                                Perimeter= 8,
                                Quantity= 0,
                                SingleArea= 0,
                                U= 0,
                                CardinalDirection= "S",
                                Floor= 0

                            }
                        }




                    }
                },
                  new BuildingInformation()
                {
                    Name= "PK",
                    Description= "Offices",
                    Address = new Address()
                    {
                        City= "Cracow",
                        Street= "Pawia 5",
                        PostalCode= "31-201"
                    },
                    Investor = new Investor()
                    {
                        Name= "Hugon",
                        LastName= "Karp",
                        PhoneNumber= "888777444",
                        Email= "hugonkarp@gmail.com",
                        Address= new Address()
                        {
                            City= "Warsaw",
                            Street= "Krótka 8",
                            PostalCode= "35-508"
                        }
                    },
                    BuildingParameters= new BuildingParameters()
                    {
                        BuildingLengthN= 10,
                        BuildingLengthE= 20,
                        BuildingLengthS= 10,
                        BuildingLengthW= 20,
                        StoreyHeightNet= 0,
                        StoreyHeightGross= 0,
                        CellarHeight = 0,
                        StoreyQuantity= 0,
                        BuildingArea= 0,
                        StaircaseSurface= 0,
                        UsableAreaOfTheStairCase= 0,
                        StaircaseWidth= 0,
                        HeatAtticArea= 0,
                        UnheatedAtticArea= 0,
                        UsableAreaOfTheBuilding= 0,
                        AtticUsableArea= 0,
                        BalconyLength= 0,
                        TotalWindowAreaN= 0,
                        TotalWindowAreaE= 0,
                        TotalWindowAreaS= 0,
                        TotalWindowAreaW= 0,
                        TotalDoorAreaN= 0,
                        TotalDoorAreaE= 0,
                        TotalDoorAreaS= 0,
                        TotalDoorAreaW= 0,
                        Windows = new List<Window>()
                        {
                            new Window()
                            {
                                Name = "Window 1",
                                Description="Velux",
                                Width= 1,
                                Height= 20,
                                Perimeter= 30,
                                Quantity= 40,
                                SingleArea= 0,
                                U= 0,
                                CardinalDirection= "N",
                                Floor= 0

                            }
                        },
                        Doors = new List<Door>()
                        {
                            new Door()
                            {
                                Name = "Door 1",
                                Description="Velux",
                                Width= 5,
                                Height= 6,
                                Perimeter= 8,
                                Quantity= 0,
                                SingleArea= 0,
                                U= 0,
                                CardinalDirection= "S",
                                Floor= 0

                            }
                        }




                    }
                }
            };

            return buildingInformations;
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
