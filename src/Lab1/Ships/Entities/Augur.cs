using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHullStrength.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Augur : ISpaceShip
{
    private readonly Deflectors.Entities.Deflectors? _deflectorsClassThird;
    private readonly ShipHulls _hullClassTrird;
    private readonly Deflectors.Entities.Deflectors? _photon;
    private readonly Deflectors.Entities.Deflectors? _antiNeutrinoEmitter;

    private bool _deflectorIsActive = true;
    private bool _crewIsAlive = true;
    private bool _shipIsActive = true;

    public Augur(double maxTravelDistance, bool photonIsActive)
    {
        MaxTravelDistance = maxTravelDistance;
        ((ISegments)this).EnginesCollection.Add(new Engines.Entities.ImpulseEngineE(maxTravelDistance));
        ((ISegments)this).EnginesCollection.Add(new Engines.Entities.AlphaJumpEngine(maxTravelDistance));
        _deflectorsClassThird = new DeflectorClassThird();
        _hullClassTrird = new HullClassThird();
        _antiNeutrinoEmitter = null;

        ((ISegments)this).EnginesCollection[0].StartEngine(((ISegments)this).EnginesCollection[0]);
        ((ISegments)this).EnginesCollection[1].StartEngine(((ISegments)this).EnginesCollection[1]);
        if (photonIsActive)
        {
            _photon = new Photon();
            _photon.DeflectorIsActive = true;
        }
        else
        {
            _photon = null;
        }
    }

    public double MaxTravelDistance { get; }
    Collection<Engine> ISegments.EnginesCollection { get; } = new Collection<Engine>();

    public int WeightShip { get; set; } = (int)WeightOverallCharacteristics.Big;

    public int Move(Queue<IEnvironment> pathShip)
    {
        return ShipMove.Move(_deflectorsClassThird, _hullClassTrird, pathShip,  ((ISegments)this).EnginesCollection, ref _deflectorIsActive, ref _shipIsActive, ref _crewIsAlive, _photon, _antiNeutrinoEmitter);
    }

    public double CheckFuel()
    {
        double fuelReserve = 0;
        foreach (Engine engine in ((ISegments)this).EnginesCollection)
        {
            fuelReserve += engine.TotalFuelConsumptionActivePlasma + engine.TotalFuelConsumptionGravitationalMatter;
        }

        return fuelReserve;
    }
}