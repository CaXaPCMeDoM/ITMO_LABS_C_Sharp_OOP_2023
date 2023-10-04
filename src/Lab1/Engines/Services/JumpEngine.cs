using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;

public abstract class JumpEngine : Engine
{
    public override double StartEngine(Engine engine)
    {
        return TotalFuel.TotalFuelConsumptionGravitationalMatter;
    }

    public bool TravelDistance(IEnvironment? environment)
    {
        if (environment != null && MaxTravelDistance - environment.Distance < 0)
        {
            return false;
        }
        else if (environment != null)
        {
            return true;
        }
        else
        {
            throw new ArgumentNullException(nameof(environment), "The 'environment' parameter cannot be null.");
        }
    }
}