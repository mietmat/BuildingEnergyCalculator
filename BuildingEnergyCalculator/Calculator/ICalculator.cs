using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Calculator
{
    public interface ICalculator
    {
        void CalculateU(double RSum);
        double CalculateRectanglePerimeter(double a, double b);
        double CalculateRectangleArea(double a, double b);

    }
}
