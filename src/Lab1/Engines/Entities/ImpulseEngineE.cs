using System;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;

public class ImpulseEngineE : ImpulseEngine
{
    private const double SpeedConst = 200;
    public ImpulseEngineE(double maxTravelDistance)
    {
        MaxTravelDistance = maxTravelDistance;
    }

    public override double CalculationFuelConsumption()
    {
        double maxTravelDistance = MaxTravelDistance;
        double growingSpeed = SpeedConst;
        int i = 0;
        while (maxTravelDistance > 0)
        {
            TotalFuelConsumptionActivePlasma += FuelConsumption * Math.Exp(i);
            TotalFuelConsumptionActivePlasma %= double.MaxValue;
            maxTravelDistance -= growingSpeed;
            growingSpeed += SpeedConst * Math.Exp(i++);
        }

        return TotalFuelConsumptionActivePlasma;
    }
}