using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Calculator
{
    public class Calculator : ICalculator
    {
        public double CalculateRectangleArea(double a, double b)
        {
            return a * b;
        }

        public double CalculateRectanglePerimeter(double a, double b)
        {
            return 2 * a + 2 * b;

        }

        public void CalculateU(double RSum)
        {
            throw new NotImplementedException();
        }
    }
}
