using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public interface ISegments
{
    protected internal Queue<IEnvironment> Path { get; }
    protected internal Collection<Engine> EnginesCollection { get; }
}