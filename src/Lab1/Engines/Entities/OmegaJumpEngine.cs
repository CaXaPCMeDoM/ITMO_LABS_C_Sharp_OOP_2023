using System;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;

public class OmegaJumpEngine : JumpEngine
{
    private const double SpeedConst = 200;
    public OmegaJumpEngine(double maxTravelDistance)
    {
        MaxTravelDistance = maxTravelDistance;
    }

    public override double CalculationFuelConsumption()
    {
        double maxTravelDistance = MaxTravelDistance;
        while (maxTravelDistance > 0)
        {
            maxTravelDistance -= SpeedConst;
            TotalFuelConsumptionGravitationalMatter += Math.Log(FuelConsumption);
        }

        return TotalFuelConsumptionGravitationalMatter;
    }
}