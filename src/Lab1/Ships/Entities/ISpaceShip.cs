using Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public interface ISpaceShip : ICheckFuel, ISegments, IRegistrationOfObstacles
{
}