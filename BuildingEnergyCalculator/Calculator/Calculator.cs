using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Calculator
{
    public class Calculator : ICalculator
    {
        public double CalculateRectangleArea(double a, double b)
        {
            if (a <= 0 || b <= 0)
            {
                throw new ArgumentException("Length is not a valid number");
            }

            var area = a * b;

            return Math.Round(area,2);
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
