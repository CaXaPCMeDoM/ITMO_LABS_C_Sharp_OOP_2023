namespace Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;

public static class BlackMarket
{
    private static double _currentPrice = 3570;

    public static double FuelCost(double fuel)
    {
        double totalFuel = fuel;
        return totalFuel * _currentPrice;
    }
}