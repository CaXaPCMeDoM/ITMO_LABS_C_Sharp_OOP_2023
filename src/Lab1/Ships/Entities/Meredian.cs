using System;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHullStrength.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Meredian : ISpaceShip, ICheckFuel
{
    public Meredian(double maxTravelDistance)
    {
        ImpulseEngineE = new ImpulseEngineE(maxTravelDistance);
        AntineutrineEmitter = new AntineutrineEmitter();
        DeflectorsClass2 = new ClassSecond();
        HullClass2 = new HullClass2();

        // DeflectorsClass2.DeflectorDamage(new Meteorites());
        ImpulseEngineE.StartEngine(ImpulseEngineE);
    }

    protected readonly Engine ImpulseEngineE;
    protected readonly Deflectors.Entities.Deflectors AntineutrineEmitter;
    protected readonly Deflectors.Entities.Deflectors DeflectorsClass2;
    protected readonly ShipHulls HullClass2;
    public void CheckFuel()
    {
        double fuelReserve = ImpulseEngineE.TotalFuelConsumption;
        Console.WriteLine($"Топливный резерв: {fuelReserve}");
    }
}