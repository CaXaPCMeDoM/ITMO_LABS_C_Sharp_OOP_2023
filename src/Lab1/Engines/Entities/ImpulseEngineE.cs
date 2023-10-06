using System;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;

public class ImpulseEngineE : ImpulseEngine
{
    public ImpulseEngineE(double maxTravelDistance)
    {
        MaxTravelDistance = maxTravelDistance;
        FuelConsumption = 200;
        Speed = 200;
    }

    public override double CalculationFuelConsumption()
    {
        double maxTravelDistance = MaxTravelDistance;
        int i = 0;
        while (maxTravelDistance > 0)
        {
            TotalFuelConsumptionActivePlasma += FuelConsumption * Math.Exp(i);
            TotalFuelConsumptionActivePlasma %= double.MaxValue;
            TotalFuel.TotalFuelConsumptionActivePlasma += FuelConsumption * Math.Exp(i);
            TotalFuel.TotalFuelConsumptionActivePlasma %= double.MaxValue;
            maxTravelDistance -= Speed;
            Speed += Speed * Math.Exp(i++);
        }

        return TotalFuelConsumptionActivePlasma;
    }
}