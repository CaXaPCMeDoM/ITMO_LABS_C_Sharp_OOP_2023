using Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;

public abstract class ImpulseEngine : Engine
{
    private double FuelConsumptionOnStartup { get; } = 50;
    public override double StartEngine(Engine engine)
    {
        TotalFuel.TotalFuelConsumptionActivePlasma += FuelConsumptionOnStartup;

        return TotalFuel.TotalFuelConsumptionActivePlasma;
    }
}