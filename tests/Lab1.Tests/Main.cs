using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Path.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;
using Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public static class Main
{
    [Theory]
    [InlineData(999, false)]
    public static void TestFirst(int shipRange, bool hasJumpEngines)
    {
        // Arrange
        ISpaceShip? shipWalkingShuttle = new WalkingShuttle(shipRange, hasJumpEngines);
        ISpaceShip? shipAugur = new Augur(shipRange, hasJumpEngines);
        var pathShip = new PathShip();
        Factory.Entities.EnvironmentFactory.CreateEnvironment(ref pathShip, 1000, "HighDensityNebulae");

        // Act
        int shuttleCompletedRoute = shipWalkingShuttle.Move(pathShip.PathShipQueue);
        int avgureCompletedRoute = shipAugur.Move(pathShip.PathShipQueue);

        // Assert
        Assert.Equal((int)RouteResults.EnginesNotSuitable, shuttleCompletedRoute);
        Assert.Equal((int)RouteResults.ShipIsLost, avgureCompletedRoute);
    }

    [Theory]
    [InlineData(1000)]
    public static void TestSecond(int shipRange)
    {
        // Arrange
        ISpaceShip? shipVaclas = new Vaclas(shipRange, false);
        ISpaceShip? shipVaclasWithPhoton = new Vaclas(shipRange, true);
        var pathShip = new PathShip();

        IObstacles obstaclesAntimatterFlares;
        obstaclesAntimatterFlares = new AntimatterFlares();

        // Act
        Factory.Entities.EnvironmentFactory.CreateEnvironment(ref pathShip, 1000, nameof(HighDensityNebulae));
        pathShip.PathShipQueue.Peek().AddObstacles(obstaclesAntimatterFlares);
        int vaclasCompletedRoute = shipVaclas.Move(pathShip.PathShipQueue);
        int vaclasWithPhotonCompletedRoute = shipVaclasWithPhoton.Move(pathShip.PathShipQueue);

        // Assert
        Assert.Equal((int)RouteResults.CrewIsDead, vaclasCompletedRoute);
        Assert.Equal((int)RouteResults.Success, vaclasWithPhotonCompletedRoute);
    }

    [Theory]
    [InlineData(1000, "NitronParticleNebulae")]
    public static void TestThird(int shipRange, string nameEnvironmet)
    {
        // Arrange
        ISpaceShip? shipVaclas = new Vaclas(shipRange, false);
        ISpaceShip? shipAugur = new Augur(shipRange, false);
        ISpaceShip? shipMeredian = new Meredian(shipRange, false);
        var pathShip = new PathShip();

        IObstacles obstaclesAntimatterFlares;
        obstaclesAntimatterFlares = new CosmoWhales();

        // Act
        Factory.Entities.EnvironmentFactory.CreateEnvironment(ref pathShip, 1000, nameEnvironmet);
        pathShip.PathShipQueue.Peek().AddObstacles(obstaclesAntimatterFlares);
        int vaclasCompletedRoute = shipVaclas.Move(pathShip.PathShipQueue);
        int augurCompletedRoute = shipAugur.Move(pathShip.PathShipQueue);
        int meredianCompletedRoute = shipMeredian.Move(pathShip.PathShipQueue);

        // Assert
        Assert.Equal((int)RouteResults.ShipDestruction, vaclasCompletedRoute);
        Assert.Equal((int)RouteResults.Success, augurCompletedRoute);
        Assert.Equal((int)RouteResults.Success, meredianCompletedRoute);
    }

    [Theory]
    [InlineData(1000, "NormalSpace")]
    public static void TestFourth(int shipRange, string nameEnvironmet)
    {
        // Arrange
        var ships = new Collection<ISpaceShip?>();
        ISpaceShip shipWalkingShuttle = new WalkingShuttle(shipRange, false);
        ISpaceShip shipVaclas = new Vaclas(shipRange, true);
        ships.Add(shipWalkingShuttle);
        ships.Add(shipVaclas);
        var pathShip = new PathShip();

        IObstacles obstaclesAntimatterFlares;
        obstaclesAntimatterFlares = new CosmoWhales();

        // Act
        Factory.Entities.EnvironmentFactory.CreateEnvironment(ref pathShip, 200, nameEnvironmet);
        pathShip.PathShipQueue.Peek().AddObstacles(obstaclesAntimatterFlares);
        ISpaceShip? optimalShip = OptimalShip.OptimalShipCalculation(ships, pathShip.PathShipQueue);

        // Assert
        Assert.Equal(optimalShip, shipWalkingShuttle);
    }

    [Theory]
    [InlineData(1000, 2000, "NormalSpace")]
    public static void TestFifth(int shipRangeAugur, int shipRangeStella, string nameEnvironmet)
    {
        // Arrange
        var ships = new Collection<ISpaceShip?>();
        ISpaceShip shipAugur = new Augur(shipRangeAugur, false);
        ISpaceShip shipStella = new Stella(shipRangeStella, true);
        ships.Add(shipAugur);
        ships.Add(shipStella);
        var pathShip = new PathShip();

        IObstacles obstaclesAntimatterFlares;
        obstaclesAntimatterFlares = new CosmoWhales();

        // Act
        Factory.Entities.EnvironmentFactory.CreateEnvironment(ref pathShip, 1000, nameEnvironmet);
        pathShip.PathShipQueue.Peek().AddObstacles(obstaclesAntimatterFlares);
        ISpaceShip? optimalShip = OptimalShip.OptimalShipCalculation(ships, pathShip.PathShipQueue);

        // Assert
        Assert.Equal(optimalShip, shipStella);
    }

    [Theory]
    [InlineData(1000, "NitronParticleNebulae")]
    public static void TestSixth(int shipRange, string nameEnvironmet)
    {
        // Arrange
        var ships = new Collection<ISpaceShip?>();
        ISpaceShip shipWalkingShuttle = new WalkingShuttle(shipRange, false);
        ISpaceShip shipVaclas = new Vaclas(shipRange, true);
        ships.Add(shipWalkingShuttle);
        ships.Add(shipVaclas);
        var pathShip = new PathShip();

        // Act
        Factory.Entities.EnvironmentFactory.CreateEnvironment(ref pathShip, 1000, nameEnvironmet);
        ISpaceShip? optimalShip = OptimalShip.OptimalShipCalculation(ships, pathShip.PathShipQueue);

        // Assert
        Assert.Equal(optimalShip, shipVaclas);
    }

    [Theory]
    [InlineData(1000, 2000, 500)]
    public static void TestSeventh(int distanceEnviromentsFirst, int distanceEnviromentsSecond, int distanceEnviromentsThirt)
    {
        // Arrange
        var ships = new Collection<ISpaceShip?>();
        ISpaceShip shipAugur = new Augur(2000, true);
        ISpaceShip shipStella = new Stella(2000, true);
        ISpaceShip shipWalkingShuttle = new WalkingShuttle(4400, true);
        ISpaceShip shipVaclas = new Vaclas(1000, true);
        ships.Add(shipAugur);
        ships.Add(shipStella);
        ships.Add(shipWalkingShuttle);
        ships.Add(shipVaclas);
        var pathShip = new PathShip();

        // Act
        Factory.Entities.EnvironmentFactory.CreateEnvironment(ref pathShip, distanceEnviromentsFirst, nameof(HighDensityNebulae));
        Factory.Entities.EnvironmentFactory.CreateEnvironment(ref pathShip, distanceEnviromentsSecond, nameof(NitronParticleNebulae));
        Factory.Entities.EnvironmentFactory.CreateEnvironment(ref pathShip, distanceEnviromentsThirt, nameof(NormalSpace));

        Factory.Entities.ObstaclesFactory.GenerateObstacles(pathShip.PathShipQueue.ElementAt(0), 40, nameof(SmallAsteroids)); // The meteorite will not be added to this Environment, since it cannot exist here

        Factory.Entities.ObstaclesFactory.GenerateObstacles(pathShip.PathShipQueue.ElementAt(0), 3, nameof(AntimatterFlares));
        Factory.Entities.ObstaclesFactory.GenerateObstacles(pathShip.PathShipQueue.ElementAt(2), 40, nameof(SmallAsteroids));

        int completeAugur = shipAugur.Move(pathShip.PathShipQueue);
        int completeStella = shipStella.Move(pathShip.PathShipQueue);
        int completeWalkingShuttle = shipWalkingShuttle.Move(pathShip.PathShipQueue);
        int completeVaclas = shipVaclas.Move(pathShip.PathShipQueue);

        // Assert
        Assert.Equal((int)RouteResults.EnginesNotSuitable, completeStella);
        Assert.Equal((int)RouteResults.ShipIsLost, completeVaclas);
        Assert.Equal((int)RouteResults.Success, completeAugur);
        Assert.Equal((int)RouteResults.EnginesNotSuitable, completeWalkingShuttle);
    }
}