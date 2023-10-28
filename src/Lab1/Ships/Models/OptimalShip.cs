using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public static class OptimalShip
{
    private const int ResultNotFound = -1;
    public static SpaceShip? OptimalShipCalculation(Collection<SpaceShip?>? ships, IEnumerable<IEnvironment> pathShip) // Attention! Obviously, after calling this method, 'Obstacles' will be removed.
    {
        SpaceShip? optimalShip = null;
        double highestScore = 0;

        if (ships is not null)
        {
            foreach (SpaceShip? spaceShip in ships)
            {
                IEnumerable<IEnvironment> environments = pathShip.ToList();
                double score = CalculateScore(spaceShip, environments);
                if (score >= highestScore)
                {
                    highestScore = score;
                    optimalShip = spaceShip;
                }
            }
        }

        return optimalShip;
    }

    private static double CalculateScore(SpaceShip? spaceShip, IEnumerable<IEnvironment> pathShip)
    {
        int resultInstenceMove;
        if (spaceShip is not null)
        {
            resultInstenceMove = spaceShip.Move(pathShip);

            if (resultInstenceMove == (int)RouteResults.Success)
            {
                return BlackMarket.FuelCost(spaceShip.CheckFuel());
            }
        }

        return ResultNotFound;
    }
}