using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Path.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Factory.Entities;

public static class EnvironmentFactory
{
    public static void CreateEnvironment(ref PathShip pathShip, int distance, string nameEnvironments)
    {
        switch (nameEnvironments)
        {
            case nameof(HighDensityNebulae):
            {
                IEnvironment environment = new HighDensityNebulae(distance);
                pathShip?.AddPathShip(environment);
                break;
            }

            case nameof(NitronParticleNebulae):
            {
                IEnvironment environment = new NitronParticleNebulae(distance);
                pathShip?.AddPathShip(environment);
                break;
            }

            case nameof(NormalSpace):
            {
                IEnvironment environment = new NormalSpace(distance);
                pathShip?.AddPathShip(environment);
                break;
            }
        }
    }
}