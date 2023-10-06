namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;

public abstract class Engine
{
    protected Engine()
    {
    }

    public double TotalFuelConsumptionGravitationalMatter { get; set; }
    public double TotalFuelConsumptionActivePlasma { get; protected set; }
    public double FuelConsumption { get; protected set; }

    // public double JumpDistance { get; protected set; }
    public double MaxTravelDistance { get; protected set; }
    public double Speed { get; protected set; }
    public abstract double StartEngine(Engine engine);
    public abstract double CalculationFuelConsumption();
}