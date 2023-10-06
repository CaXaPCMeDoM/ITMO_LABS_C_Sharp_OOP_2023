namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;

public abstract class ImpulseEngine : Engine
{
    private double FuelConsumptionOnStartup { get; } = 50;
    public override double StartEngine(Engine engine)
    {
        TotalFuelConsumptionActivePlasma += FuelConsumptionOnStartup;

        return TotalFuelConsumptionActivePlasma;
    }
}