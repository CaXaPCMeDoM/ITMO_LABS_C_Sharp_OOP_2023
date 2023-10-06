using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;

public class AlphaJumpEngine : JumpEngine
{
    public AlphaJumpEngine(double maxTravelDistance)
    {
        FuelConsumption = 10; // quadratic consumption
        MaxTravelDistance = maxTravelDistance;
        Speed = 200;
    }

    public override double CalculationFuelConsumption()
    {
        double maxTravelDistance = MaxTravelDistance;
        int i = 0;
        while (maxTravelDistance > 0)
        {
            i++;
            maxTravelDistance -= Speed;
            TotalFuelConsumptionActivePlasma += FuelConsumption * i;
            TotalFuel.TotalFuelConsumptionActivePlasma += FuelConsumption * i;
        }

        return TotalFuelConsumptionGravitationalMatter;
    }
}