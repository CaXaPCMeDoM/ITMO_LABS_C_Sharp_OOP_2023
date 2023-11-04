using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;
using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;

public class ProcessorCoolingSystemBuilder : IProcessorCoolingSystemBuilder
{
    private const int _emptyVariable = 0;
    private string _name = string.Empty;
    private Collection<string> _supportedSockets = new Collection<string>();
    private int _tdp = _emptyVariable;
    private int _width = _emptyVariable;
    private int _height = _emptyVariable;
    private int _length = _emptyVariable;

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
        _width = width;
        return this;
    }

    public ProcessorCoolingSystemBuilder DimensionsHeight(int height)
    {
        _height = height;
        return this;
    }

    public ProcessorCoolingSystemBuilder DimensionsLength(int length)
    {
        _length = length;
        return this;
    }

    public ProcessorCoolingSystemBuilder Tdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ProcessorCoolingSystem Build()
    {
        if (_tdp == _emptyVariable ||
            _width == _emptyVariable ||
            _length == _emptyVariable ||
            _height == _emptyVariable ||
            _name.Length == _emptyVariable ||
            _supportedSockets.Count == _emptyVariable)
        {
            throw new EmptyValuesException();
        }

        var dimensions = new Dimensions(_width, _height, _length);
        return new ProcessorCoolingSystem(
            dimensions,
            _tdp,
            _name,
            _supportedSockets);
    }
}