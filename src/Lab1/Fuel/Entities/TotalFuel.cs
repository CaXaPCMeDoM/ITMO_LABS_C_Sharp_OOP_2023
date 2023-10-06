namespace Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;

public static class TotalFuel
{
    public static double TotalFuelConsumptionActivePlasma { get; set; }
    public static double TotalFuelConsumptionGravitationalMatter { get; set; }

    public static double FuelTotal()
    {
        return TotalFuelConsumptionActivePlasma + TotalFuelConsumptionGravitationalMatter;
    }
}