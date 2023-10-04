using System;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHullStrength.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Vaclas : ISpaceShip, ICheckFuel
{
    public Vaclas(double maxTravelDistance)
    {
        ImpulseEngineE = new ImpulseEngineE(maxTravelDistance);
        JumpEngineGamma = new GammaJumpEngine(maxTravelDistance);
        DeflectorsClass1 = new ClassFirst();
        HullClass2 = new HullClass2();

        // DeflectorsClass2.DeflectorDamage(new Meteorites());
        ImpulseEngineE.StartEngine(ImpulseEngineE);
    }

    protected readonly Engine ImpulseEngineE;
    protected readonly Engine JumpEngineGamma;
    protected readonly Deflectors.Entities.Deflectors DeflectorsClass1;
    protected readonly ShipHulls HullClass2;
    public void CheckFuel()
    {
        double fuelReserve = ImpulseEngineE.TotalFuelConsumption;
        Console.WriteLine($"Топливный резерв: {fuelReserve}");
    }
}