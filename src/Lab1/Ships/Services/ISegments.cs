using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public interface ISegments
{
    protected internal Collection<Engine> EnginesCollection { get; }
}