namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;

public abstract class ImpulseEngine : Engine
{
    public override double StartEngine(Engine engine)
    {
        TotalFuelConsumptionActivePlasma += FuelConsumptionOnStartupConst;

        return TotalFuelConsumptionActivePlasma;
    }
}