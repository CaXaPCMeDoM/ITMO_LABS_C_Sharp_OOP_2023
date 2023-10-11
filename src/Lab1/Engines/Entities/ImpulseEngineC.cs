using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;

public class ImpulseEngineC : ImpulseEngine
{
    public ImpulseEngineC(double maxTravelDistance)
    {
        MaxTravelDistance = maxTravelDistance;
    }

    public override double CalculationFuelConsumption()
    {
        TotalFuelConsumptionActivePlasma += FuelConsumption * MaxTravelDistance;
        TotalFuel.TotalFuelConsumptionActivePlasma += FuelConsumption * MaxTravelDistance;
        return TotalFuelConsumptionActivePlasma;
    }
}