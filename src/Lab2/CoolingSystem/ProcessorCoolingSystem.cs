using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;

public class ProcessorCoolingSystem
{
    private List<string> _supportedSockets = new List<string>();

    public Dimensions Dimensions { get; init; } = new Dimensions();
    public int Tdp { get; internal set; }
    public string? Name { get; private set; }
    public IList<string> SupportedSockets => _supportedSockets;

    public ProcessorCoolingSystem Clone()
    {
        return new ProcessorCoolingSystem()
        {
            _supportedSockets = _supportedSockets,
            Dimensions = Dimensions,
            Tdp = Tdp,
            Name = Name,
        };
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public void AddSupportedSockets(Collection<string> supportedSockets)
    {
        _supportedSockets.AddRange(supportedSockets);
    }

    public void SetDimensions(int width, int height, int length)
    {
        Dimensions.Width = width;
        Dimensions.Height = height;
        Dimensions.Length = length;
    }

    public void SetTdp(int tdp)
    {
        Tdp = tdp;
    }
}