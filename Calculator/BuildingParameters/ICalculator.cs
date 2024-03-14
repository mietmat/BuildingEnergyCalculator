using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcServer.BuildingParameters
{
    public interface ICalculator
    {
        double CalculateRectanglePerimeter(double a, double b);
        double CalculateRectangleArea(double a, double b);
        double CalculateR(double thickness, double lambda);
        double CalculateTotalThickness(List<double> thicknesses);
        double CalculateU(double rSum);
        double CalculateRSum(double rsi, double rse, List<double> rList);

    }
}
