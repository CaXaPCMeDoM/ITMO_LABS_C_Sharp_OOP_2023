using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHullStrength.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public sealed class Meredian : SpaceShip
{
    public Meredian(double maxTravelDistance, bool photonIsActive)
    {
        MaxTravelDistance = maxTravelDistance;
        EnginesCollection = new ReadOnlyCollection<Engine>(new List<Engine> { new Engines.Entities.ImpulseEngineE(maxTravelDistance) });
        DeflectorsClass = new DeflectorClassSecond();
        HullClass = new HullClassSecond();
        AntiNeutrinoEmitter = new AntiNeutrinoEmitter();

        EnginesCollection[0].StartEngine(EnginesCollection[0]);
        Photon = photonIsActive ? new Photon() : null;
    }

    public override double MaxTravelDistance { get; }
    public override ReadOnlyCollection<Engine> EnginesCollection { get; }
    public override Deflector? DeflectorsClass { get; protected set; }
    public override ShipHulls? HullClass { get; protected set; }
    public override Deflector? Photon { get; protected set; }
    public override Deflector? AntiNeutrinoEmitter { get; protected set; }

    public int WeightShip { get; } = (int)WeightOverallCharacteristics.Average;

    public override int Move(IEnumerable<IEnvironment> pathShip)
    {
        return ShipMove.Move(this, pathShip);
    }

    public override double CheckFuel()
    {
        double fuelReserve = 0;
        foreach (Engine engine in EnginesCollection)
        {
            fuelReserve += engine.TotalFuelConsumptionActivePlasma + engine.TotalFuelConsumptionGravitationalMatter;
        }

        return fuelReserve;
    }
}