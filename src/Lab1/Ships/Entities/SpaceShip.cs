using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHullStrength.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public abstract class SpaceShip : ICheckFuel
{
    protected SpaceShip()
    {
        DeflectorsClass = null;
        HullClass = null;
        Photon = null;
        AntiNeutrinoEmitter = null;
    }

    public abstract double MaxTravelDistance { get; }
    public abstract IReadOnlyCollection<Engine> EnginesCollection { get; }
    public abstract Deflector? DeflectorsClass { get; protected set; }
    public abstract ShipHulls? HullClass { get; protected set; }
    public abstract Deflector? Photon { get; protected set; }
    public abstract Deflector? AntiNeutrinoEmitter { get; protected set; }
    public abstract int Move(IEnumerable<IEnvironment> pathShip);
    public abstract double CheckFuel();
}