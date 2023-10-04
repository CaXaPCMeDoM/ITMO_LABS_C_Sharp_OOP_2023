using System;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHullStrength.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Stella : ISpaceShip, ICheckFuel
{
    public Stella(double maxTravelDistance)
    {
        ImpulseEngineС = new ImpulseEngineC(maxTravelDistance);
        JumpEngineOmega = new OmegaJumpEngine(maxTravelDistance);
        DeflectorsClass1 = new ClassFirst();
        HullClass1 = new HullClass1();

        // DeflectorsClass2.DeflectorDamage(new Meteorites());
        ImpulseEngineС.StartEngine(ImpulseEngineС);
    }

    protected readonly Engine ImpulseEngineС;
    protected readonly Engine JumpEngineOmega;
    protected readonly Deflectors.Entities.Deflectors DeflectorsClass1;
    protected readonly ShipHulls HullClass1;
    public void CheckFuel()
    {
        double fuelReserve = ImpulseEngineС.TotalFuelConsumption;
        Console.WriteLine($"Топливный резерв: {fuelReserve}");
    }
}