namespace Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;

public static class BlackMarket
{
    private static double _currentPrice;

    public static double FuelCost(double fuel)
    {
        double totalFuel = fuel;
#pragma warning disable CA5394
        _currentPrice = 3570;
#pragma warning restore CA5394
        return totalFuel * _currentPrice;
    }
}