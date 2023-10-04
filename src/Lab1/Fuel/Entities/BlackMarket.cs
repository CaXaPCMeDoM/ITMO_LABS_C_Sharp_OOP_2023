using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;

public static class BlackMarket
{
    private static readonly Random Random = new Random();
    private static double _currentPrice;

    public static double FuelCost()
    {
        double totalFuel = TotalFuel.TotalFuelConsumptionActivePlasma + TotalFuel.TotalFuelConsumptionGravitationalMatter;
#pragma warning disable CA5394
        _currentPrice = (Random.NextDouble() * (10.0 - 5.0)) + 5.0;
#pragma warning restore CA5394
        return totalFuel * _currentPrice;
    }
}