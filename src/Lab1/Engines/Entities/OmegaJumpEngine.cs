using System;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;

public class OmegaJumpEngine : JumpEngine
{
    public OmegaJumpEngine(double maxTravelDistance)
    {
        FuelConsumption = 5; // quadratic consumption
        MaxTravelDistance = maxTravelDistance;
    }

    public override double CalculationFuelConsumption()
    {
        double maxTravelDistance = MaxTravelDistance;
        while (maxTravelDistance > 0)
        {
            maxTravelDistance -= Speed;
            TotalFuel.TotalFuelConsumptionGravitationalMatter += Math.Log(FuelConsumption);
        }

        return TotalFuel.TotalFuelConsumptionGravitationalMatter;
    }
}