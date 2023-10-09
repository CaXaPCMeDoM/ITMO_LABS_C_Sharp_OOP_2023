using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHullStrength.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public sealed class WalkingShuttle : ISpaceShip, ICheckFuel
{
    public WalkingShuttle(double maxTravelDistance, bool photonIsActive)
    {
        MaxTravelDistance = maxTravelDistance;
        EnginesCollection.Add(new Engines.Entities.ImpulseEngineC(maxTravelDistance));
        DeflectorsClass = null;
        HullClass = new HullClassSecond();
        AntiNeutrinoEmitter = null;

        EnginesCollection[0].StartEngine(EnginesCollection[0]);
        Photon = photonIsActive ? new Photon() : null;
    }

    public override double MaxTravelDistance { get; }
    public sealed override Collection<Engine> EnginesCollection { get; } = new Collection<Engine>();

    public override Deflector? DeflectorsClass { get; protected set; }
    public override ShipHulls? HullClass { get; protected set; }
    public override Deflector? Photon { get; protected set; }
    public override Deflector? AntiNeutrinoEmitter { get; protected set; }

    public int WeightShip { get; set; } = (int)WeightOverallCharacteristics.Average;

    public override int Move(Queue<IEnvironment> pathShip)
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