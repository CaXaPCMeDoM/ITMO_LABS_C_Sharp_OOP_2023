namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;

public abstract class Engine
{
    protected const double FuelConsumptionOnStartupConst = 50;
    protected const double FuelConsumption = 10;
    protected Engine()
    {
    }

    public double TotalFuelConsumptionGravitationalMatter { get; set; }
    public double TotalFuelConsumptionActivePlasma { get; protected set; }
    public double MaxTravelDistance { get; protected set; }
    public abstract double StartEngine(Engine engine);
    public abstract double CalculationFuelConsumption();
}