using System;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;

public class GammaJumpEngine : JumpEngine
{
    public GammaJumpEngine(double maxTravelDistance)
    {
        FuelConsumption = 1; // quadratic consumption
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
            TotalFuelConsumptionActivePlasma += Math.Pow(i, 2) * FuelConsumption;
            TotalFuel.TotalFuelConsumptionActivePlasma += Math.Pow(i, 2) * FuelConsumption;
        }

        return TotalFuelConsumptionGravitationalMatter;
    }
}