using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processors;

public class ProcessorBuilder : IProcessorBuilder
{
    private string _name = string.Empty;
    private int _coreFrequency;
    private int _cores;
    private Collection<int> _supportedMemoryFrequencies = new Collection<int>();
    private string _socket = string.Empty;
    private bool _integratedGraphics;
    private int _tdp;
    private int _powerConsumption;

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

    public ProcessorBuilder WithTdp(int tdp)
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