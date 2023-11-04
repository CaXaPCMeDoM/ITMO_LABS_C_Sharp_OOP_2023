using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;

public class ProcessorCoolingSystem
{
    private IList<string> _supportedSockets;
    public ProcessorCoolingSystem(Dimensions dimensions, int tdp, string name, IList<string> supportSockets)
    {
        Dimensions = dimensions;
        Tdp = tdp;
        Name = name;
        _supportedSockets = supportSockets;
    }

    public Dimensions Dimensions { get; private set; }
    public int Tdp { get; private set; }
    public string Name { get; private set; }
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

    public ProcessorCoolingSystemBuilder Debuilder()
    {
        return new ProcessorCoolingSystemBuilder()
            .Tdp(Tdp)
            .Name(Name)
            .SupportedSockets((Collection<string>)SupportedSockets)
            .DimensionsHeight(Dimensions.Height)
            .DimensionsLength(Dimensions.Length)
            .DimensionsWidth(Dimensions.Width);
    }
}