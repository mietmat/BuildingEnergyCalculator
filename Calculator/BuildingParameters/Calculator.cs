

namespace CalcServer.BuildingParameters
{
    public class Calculator : ICalculator
    {
        private double Thickness { get; set; } = 0;
        private double RSum { get; set; }//ThermalResistance m2K/W

        public double CalculateRectangleArea(double a, double b)
        {
            if (a <= 0 || b <= 0)
            {
                throw new ArgumentException("Length is not a valid number");
            }

            var area = a * b;

            return Math.Round(area, 2);
        }

        public double CalculateRectanglePerimeter(double a, double b)
        {
            return 2 * a + 2 * b;

        }    


        public double CalculateR(double thickness, double lambda)
        {
            double r = thickness / lambda;

            return r;
        }

        public double CalculateRSum(double rsi, double rse, List<double> rList)
        {
            foreach (var r in rList)
            {
                RSum += r;
            }
            RSum += rsi;
            RSum += rse;

            return Math.Round(RSum, 2);
        }

        public double CalculateTotalThickness(List<double> thicknesses)
        {
            foreach (var thickness in thicknesses)
            {
                Thickness += thickness;
            }

            return Thickness;
        }

        public double CalculateU(double rSum)
        {
            var u = 1 / rSum;
            return Math.Round(u, 2);

        }
    }
}
