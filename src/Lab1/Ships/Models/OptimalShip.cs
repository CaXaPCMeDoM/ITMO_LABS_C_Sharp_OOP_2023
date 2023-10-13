using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public static class OptimalShip
{
    public static ISpaceShip? OptimalShipCalculation(Collection<ISpaceShip?>? ships, IEnumerable<IEnvironment> pathShip) // Attention! Obviously, after calling this method, 'Obstacles' will be removed.
    {
        ISpaceShip? optimalShip = null;
        double highestScore = 0;

        if (ships != null)
        {
            foreach (ISpaceShip? spaceShip in ships)
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

    private static double CalculateScore(ISpaceShip? spaceShip, IEnumerable<IEnvironment> pathShip)
    {
        int resultInstenceMove = -1;
        if (spaceShip != null)
        {
            resultInstenceMove = spaceShip.Move(pathShip);
        }

        if (resultInstenceMove == (int)RouteResults.Success)
        {
                Debug.Assert(spaceShip != null, nameof(spaceShip) + " != null");
                return BlackMarket.FuelCost(spaceShip.CheckFuel());
        }

        return -1;
    }
}