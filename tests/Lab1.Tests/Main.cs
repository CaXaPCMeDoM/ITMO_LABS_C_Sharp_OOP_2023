using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.RouteShip.Entities;
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
    [MemberData(nameof(TestFirstData))]
    public static void TestFirst(double shipRange, bool hasJumpEngines, int expectedShuttleResult, int expectedAugurResult)
    {
        // Arrange
        ISpaceShip shipWalkingShuttle = new WalkingShuttle(shipRange, hasJumpEngines);
        ISpaceShip shipAugur = new Augur(shipRange, hasJumpEngines);
        var pathShip = new PathShip();
        IEnvironment environment = new HighDensityNebulae((double)RouteLength.AverageLength);
        pathShip.AddPathShip(environment);

        // Act
        int shuttleCompletedRoute = shipWalkingShuttle.Move(pathShip.PathShipEnumerable);
        int augurCompletedRoute = shipAugur.Move(pathShip.PathShipEnumerable);

        // Assert
        Assert.Equal(expectedShuttleResult, shuttleCompletedRoute);
        Assert.Equal(expectedAugurResult, augurCompletedRoute);
    }

    public static IEnumerable<object[]> TestFirstData()
    {
        yield return new object[] { RouteLength.ShortLength, false, (int)RouteResults.EnginesNotSuitable, (int)RouteResults.ShipIsLost };
    }

    [Theory]
    [MemberData(nameof(TestSecondData))]
    public static void TestSecond(int shipRange, int expectedVaclasResult, int expectedVaclasWithPhotonResult)
    {
        // Arrange
        ISpaceShip shipVaclas = new Vaclas(shipRange, false);
        ISpaceShip shipVaclasWithPhoton = new Vaclas(shipRange, true);
        var pathShip = new PathShip();
        IObstacles obstaclesAntimatterFlares;
        obstaclesAntimatterFlares = new AntimatterFlares();

        // Act
        IEnvironment environment = new HighDensityNebulae((double)RouteLength.AverageLength);
        pathShip.AddPathShip(environment);

        pathShip.PathShipEnumerable.First().AddObstacles(obstaclesAntimatterFlares);
        int vaclasCompletedRoute = shipVaclas.Move(pathShip.PathShipEnumerable);
        int vaclasWithPhotonCompletedRoute = shipVaclasWithPhoton.Move(pathShip.PathShipEnumerable);

        // Assert
        Assert.Equal(expectedVaclasResult, vaclasCompletedRoute);
        Assert.Equal(expectedVaclasWithPhotonResult, vaclasWithPhotonCompletedRoute);
    }

    public static IEnumerable<object[]> TestSecondData()
    {
        yield return new object[] { (double)RouteLength.AverageLength, (int)RouteResults.CrewIsDead, (int)RouteResults.Success };
    }

    [Theory]
    [MemberData(nameof(TestThirdData))]
    public static void TestThird(int shipRange)
    {
        // Arrange
        ISpaceShip shipVaclas = new Vaclas(shipRange, false);
        ISpaceShip shipAugur = new Augur(shipRange, false);
        ISpaceShip shipMeredian = new Meredian(shipRange, false);
        var pathShip = new PathShip();

        IObstacles obstaclesAntimatterFlares;
        obstaclesAntimatterFlares = new CosmoWhales();

        // Act
        IEnvironment environment = new NitronParticleNebulae((int)RouteLength.AverageLength);
        pathShip.AddPathShip(environment);

        pathShip.PathShipEnumerable.First().AddObstacles(obstaclesAntimatterFlares);
        int vaclasCompletedRoute = shipVaclas.Move(pathShip.PathShipEnumerable);
        int augurCompletedRoute = shipAugur.Move(pathShip.PathShipEnumerable);
        int meredianCompletedRoute = shipMeredian.Move(pathShip.PathShipEnumerable);

        // Assert
        Assert.Equal((int)RouteResults.ShipDestruction, vaclasCompletedRoute);
        Assert.Equal((int)RouteResults.Success, augurCompletedRoute);
        Assert.Equal((int)RouteResults.Success, meredianCompletedRoute);
    }

    public static IEnumerable<object[]> TestThirdData()
    {
        yield return new object[] { (int)RouteLength.AverageLength };
    }

    [Theory]
    [MemberData(nameof(TestFourthData))]
    public static void TestFourth(int shipRange)
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
        IEnvironment environment = new NormalSpace((int)RouteLength.AverageLength);
        pathShip.AddPathShip(environment);
        pathShip.PathShipEnumerable.First().AddObstacles(obstaclesAntimatterFlares);
        ISpaceShip? optimalShip = OptimalShip.OptimalShipCalculation(ships, pathShip.PathShipEnumerable);

        // Assert
        Assert.Equal(optimalShip, shipWalkingShuttle);
    }

    public static IEnumerable<object[]> TestFourthData()
    {
        yield return new object[] { (int)RouteLength.AverageLength };
    }

    [Theory]
    [MemberData(nameof(TestFifthData))]
    public static void TestFifth(int shipRangeAugur, int shipRangeStella)
    {
        // Arrange
        var ships = new Collection<ISpaceShip?>();
        ISpaceShip shipAugur = new Augur(shipRangeAugur, false);
        ISpaceShip shipStella = new Stella(shipRangeStella, true);
        ships.Add(shipAugur);
        ships.Add(shipStella);
        var pathShip = new PathShip();

        IObstacles obstaclesAntimatterFlares = new CosmoWhales();

        // Act
        IEnvironment environment = new NormalSpace((int)RouteLength.AverageLength);
        pathShip.AddPathShip(environment);

        pathShip.PathShipEnumerable.First().AddObstacles(obstaclesAntimatterFlares);
        ISpaceShip? optimalShip = OptimalShip.OptimalShipCalculation(ships, pathShip.PathShipEnumerable);

        // Assert
        Assert.Equal(optimalShip, shipStella);
    }

    public static IEnumerable<object[]> TestFifthData()
    {
        yield return new object[] { (int)RouteLength.AverageLength, (int)RouteLength.LongsLength };
    }

    [Theory]
    [MemberData(nameof(TestSixthData))]
    public static void TestSixth(int shipRange)
    {
        // Arrange
        var ships = new Collection<ISpaceShip?>();
        ISpaceShip shipWalkingShuttle = new WalkingShuttle(shipRange, false);
        ISpaceShip shipVaclas = new Vaclas(shipRange, true);
        ships.Add(shipWalkingShuttle);
        ships.Add(shipVaclas);
        var pathShip = new PathShip();

        // Act
        IEnvironment environment = new NitronParticleNebulae((int)RouteLength.AverageLength);
        pathShip.AddPathShip(environment);

        ISpaceShip? optimalShip = OptimalShip.OptimalShipCalculation(ships, pathShip.PathShipEnumerable);

        // Assert
        Assert.Equal(optimalShip, shipVaclas);
    }

    public static IEnumerable<object[]> TestSixthData()
    {
        yield return new object[] { (int)RouteLength.AverageLength };
    }

    [Theory]
    [MemberData(nameof(TestSeventhData))]
    public static void TestSeventh(int distanceEnviromentsFirst, int distanceEnviromentsSecond, int distanceEnviromentsThirt)
    {
        const int numberOfSmallAsteroids = 40;
        const int numberOfAntimatterFlares = 3;

        // Arrange
        var ships = new Collection<ISpaceShip?>();
        ISpaceShip shipAugur = new Augur((int)RouteLength.LongsLength, true);
        ISpaceShip shipStella = new Stella((int)RouteLength.LongsLength, true);
        ISpaceShip shipWalkingShuttle = new WalkingShuttle((int)RouteLength.LongsLength, true);
        ISpaceShip shipVaclas = new Vaclas((int)RouteLength.AverageLength, true);
        ships.Add(shipAugur);
        ships.Add(shipStella);
        ships.Add(shipWalkingShuttle);
        ships.Add(shipVaclas);
        var pathShip = new PathShip();

        // Act
        IEnvironment environmentFirst = new HighDensityNebulae(distanceEnviromentsFirst);
        pathShip.AddPathShip(environmentFirst);
        IEnvironment environment = new NitronParticleNebulae(distanceEnviromentsSecond);
        pathShip.AddPathShip(environment);
        IEnvironment environmentThird = new NormalSpace(distanceEnviromentsThirt);
        pathShip.AddPathShip(environmentThird);
        for (int i = 0; i < numberOfSmallAsteroids; i++)
        {
            pathShip.PathShipEnumerable.First().AddObstacles(new SmallAsteroids()); // will not be added. The meteorite will not be added to this Environment, since it cannot exist here
        }

        for (int i = 0; i < numberOfAntimatterFlares; i++)
        {
            pathShip.PathShipEnumerable.First().AddObstacles(new AntimatterFlares());
        }

        for (int i = 0; i < numberOfSmallAsteroids; i++)
        {
            pathShip.PathShipEnumerable.Skip(2).First().AddObstacles(new SmallAsteroids());
        }

        int completeAugur = shipAugur.Move(pathShip.PathShipEnumerable);
        int completeStella = shipStella.Move(pathShip.PathShipEnumerable);
        int completeWalkingShuttle = shipWalkingShuttle.Move(pathShip.PathShipEnumerable);
        int completeVaclas = shipVaclas.Move(pathShip.PathShipEnumerable);

        // Assert
        Assert.Equal((int)RouteResults.EnginesNotSuitable, completeStella);
        Assert.Equal((int)RouteResults.ShipIsLost, completeVaclas);
        Assert.Equal((int)RouteResults.Success, completeAugur);
        Assert.Equal((int)RouteResults.EnginesNotSuitable, completeWalkingShuttle);
    }

    public static IEnumerable<object[]> TestSeventhData()
    {
        yield return new object[] { (int)RouteLength.AverageLength, (int)RouteLength.LongsLength, (int)RouteLength.ShortLength };
    }
}