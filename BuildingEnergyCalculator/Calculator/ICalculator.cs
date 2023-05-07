using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Calculator
{
    public interface ICalculator<T>
    {
        void CalculateU(double RSum);

    }
}
