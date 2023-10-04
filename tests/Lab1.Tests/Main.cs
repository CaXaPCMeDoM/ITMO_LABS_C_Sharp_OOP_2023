using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Main
{
    [Theory]
    [InlineData(false, false)]
    public void TestMediumRouteInHighDensityNebula(bool hasJumpEngines, bool hasInsufficientRange)
    {
        // Arrange
        Ship shuttle = new Ship(hasJumpEngines, hasInsufficientRange);
        Ship augur = new Ship(hasJumpEngines: true, hasInsufficientRange: false);

        // Act
        bool shuttleCompletedRoute = shuttle.TravelMediumRouteInHighDensityNebula();
        bool augurCompletedRoute = augur.TravelMediumRouteInHighDensityNebula();

        // Assert
        Assert.False(shuttleCompletedRoute);
        Assert.False(augurCompletedRoute);
    }
}