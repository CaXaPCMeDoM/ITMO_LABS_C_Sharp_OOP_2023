using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processors;

public class ProcessorBuilder : IProcessorBuilder
{
    private const int _emptyVariable = 0;
    private string _name = string.Empty;
    private int _coreFrequency = _emptyVariable;
    private int _cores = _emptyVariable;
    private Collection<int> _supportedMemoryFrequencies = new Collection<int>();
    private string _socket = string.Empty;
    private bool _integratedGraphics;
    private int _tdp = _emptyVariable;
    private int _powerConsumption = _emptyVariable;

    public ProcessorBuilder Name(string name)
    {
        _name = name;
        return this;
    }

    public ProcessorBuilder CoreFrequency(int frequency)
    {
        _coreFrequency = frequency;
        return this;
    }

    public ProcessorBuilder Cores(int cores)
    {
        _cores = cores;
        return this;
    }

    public ProcessorBuilder Socket(string socket)
    {
        _socket = socket;
        return this;
    }

    public ProcessorBuilder IntegratedGraphics(bool integratedGraphics)
    {
        _integratedGraphics = integratedGraphics;
        return this;
    }

    public ProcessorBuilder SupportedMemoryFrequencies(Collection<int> supportedFrequencies)
    {
        _supportedMemoryFrequencies = supportedFrequencies;
        return this;
    }

    public ProcessorBuilder Tdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ProcessorBuilder PowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Processor Build()
    {
        if (_name.Length == _emptyVariable ||
            _powerConsumption == _emptyVariable ||
            _cores == _emptyVariable ||
            _socket.Length == _emptyVariable ||
            _supportedMemoryFrequencies.Count == _emptyVariable ||
            _tdp == _emptyVariable ||
            _coreFrequency == _emptyVariable)
        {
            throw new EmptyValuesException();
        }

        return new Processor(
            _name,
            _coreFrequency,
            _cores,
            _socket,
            _integratedGraphics,
            _supportedMemoryFrequencies,
            _tdp,
            _powerConsumption);
    }
}