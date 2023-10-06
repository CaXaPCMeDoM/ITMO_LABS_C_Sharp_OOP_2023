using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Factory.Entities;

public static class ObstaclesFactory
{
    public static IEnvironment GenerateObstacles(IEnvironment environment, int numberOfObstacles, string nameObstacles)
    {
        for (int i = 0; i < numberOfObstacles; i++)
        {
            IObstacles obstacles;
            if (nameObstacles == nameof(Meteorites))
            {
                obstacles = new Meteorites();
                environment?.AddObstacles(obstacles);
            }
            else if (nameObstacles == nameof(SmallAsteroids))
            {
                obstacles = new SmallAsteroids();
                environment?.AddObstacles(obstacles);
            }
            else if (nameObstacles == nameof(CosmoWhales))
            {
                obstacles = new CosmoWhales();
                environment?.AddObstacles(obstacles);
            }
            else if (nameObstacles == nameof(AntimatterFlares))
            {
                obstacles = new AntimatterFlares();
                environment?.AddObstacles(obstacles);
            }
        }

        if (environment != null)
        {
            return environment;
        }
        else
        {
            return new HighDensityNebulae(1000);
        }
    }
}