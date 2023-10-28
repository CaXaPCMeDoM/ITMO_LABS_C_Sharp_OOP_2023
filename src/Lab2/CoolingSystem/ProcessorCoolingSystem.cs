using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;

public class ProcessorCoolingSystem
{
    private IList<string> _supportedSockets = new List<string>();
    public ProcessorCoolingSystem(Dimensions dimensions, int tdp, string name, IList<string> supportSockets)
    {
        Dimensions = dimensions;
        Tdp = tdp;
        Name = name;
        _supportedSockets = supportSockets;
    }

    public Dimensions Dimensions { get; init; } = new Dimensions();
    public int Tdp { get; set; }
    public string Name { get; set; }
    public IList<string> SupportedSockets => _supportedSockets;

    public ProcessorCoolingSystem Clone()
    {
        return new ProcessorCoolingSystem(Dimensions, Tdp, Name, _supportedSockets)
        {
            _supportedSockets = _supportedSockets,
            Dimensions = Dimensions,
            Tdp = Tdp,
            Name = Name,
        };
    }
}