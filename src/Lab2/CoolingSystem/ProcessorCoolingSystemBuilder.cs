using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;

public class ProcessorCoolingSystemBuilder : IProcessorCoolingSystemBuilder
{
    private string _name = string.Empty;
    private Collection<string> _supportedSockets = new Collection<string>();
    private Dimensions _dimensions = new Dimensions();
    private int _tdp;

    public ProcessorCoolingSystemBuilder Name(string name)
    {
        _name = name;
        return this;
    }

    public ProcessorCoolingSystemBuilder SupportedSockets(Collection<string> supportedSockets)
    {
        _supportedSockets = supportedSockets;
        return this;
    }

    public ProcessorCoolingSystemBuilder DimensionsWidth(int width)
    {
        _dimensions.Width = width;
        return this;
    }

    public ProcessorCoolingSystemBuilder DimensionsHeight(int height)
    {
        _dimensions.Height = height;
        return this;
    }

    public ProcessorCoolingSystemBuilder DimensionsLength(int length)
    {
        _dimensions.Length = length;
        return this;
    }

    public ProcessorCoolingSystemBuilder Tdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ProcessorCoolingSystem Build()
    {
        return new ProcessorCoolingSystem(
            _dimensions,
            _tdp,
            _name,
            _supportedSockets);
    }
}