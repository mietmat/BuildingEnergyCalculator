using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Helpers
{
    public class DataPreparer
    {
        private List<double> thicknesses = new List<double>();
        private List<double> rList = new List<double>();

        public List<string> PrepareStrings(List<string> strings)
        {
            return new List<string>();
        }

        public List<double> CalculateTotalThicknessForDivisionalStructure(List<CreateBuildingMaterialDto> buildingMaterials)
        {
            foreach (var material in buildingMaterials)
            {
                thicknesses.Add(material.Thickness);
            }

            return thicknesses;
        }
        public List<double> PrepareRList(List<CreateBuildingMaterialDto> buildingMaterials)
        {
            foreach (var material in buildingMaterials)
            {
                rList.Add(material.R);
            }

            return rList;
        }

    }
}
