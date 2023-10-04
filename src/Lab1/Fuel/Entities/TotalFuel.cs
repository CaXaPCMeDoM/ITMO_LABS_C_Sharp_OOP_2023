namespace Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;

public static class TotalFuel
{
    public static double TotalFuelConsumptionActivePlasma { get; set; }
    public static double TotalFuelConsumptionGravitationalMatter { get; set; }

#pragma warning disable SA1201
    static TotalFuel()
#pragma warning restore SA1201
    {
        TotalFuelConsumptionActivePlasma = 0;
        TotalFuelConsumptionGravitationalMatter = 0;
    }
}