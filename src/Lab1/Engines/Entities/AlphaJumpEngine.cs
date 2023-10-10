using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;

public class AlphaJumpEngine : JumpEngine
{
    protected const double SpeedConst = 200;
    public AlphaJumpEngine(double maxTravelDistance)
    {
        MaxTravelDistance = maxTravelDistance;
    }

    public override double CalculationFuelConsumption()
    {
        double maxTravelDistance = MaxTravelDistance;
        int i = 0;
        while (maxTravelDistance > 0)
        {
            i++;
            maxTravelDistance -= SpeedConst;
            TotalFuelConsumptionActivePlasma += FuelConsumption * i;
            TotalFuel.TotalFuelConsumptionActivePlasma += FuelConsumption * i;
        }

        return TotalFuelConsumptionGravitationalMatter;
    }
}