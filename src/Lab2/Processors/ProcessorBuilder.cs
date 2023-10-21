using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processors;

public class ProcessorBuilder : IProcessorBuilder
{
    internal ProcessorBuilder()
    {
        Processor = new Processor();
    }

    private Processor Processor { get; set; }

    public ProcessorBuilder Name(string name)
    {
        Processor.Name = name;
        return this;
    }

    public ProcessorBuilder CoreFrequency(int frequency)
    {
        Processor.CoreFrequency = frequency;
        return this;
    }

    public ProcessorBuilder Cores(int cores)
    {
        Processor.Cores = cores;
        return this;
    }

    public ProcessorBuilder Socket(string socket)
    {
        Processor.Socket = socket;
        return this;
    }

    public ProcessorBuilder IntegratedGraphics(bool integratedGraphics)
    {
        Processor.IntegratedGraphics = integratedGraphics;
        return this;
    }

    public ProcessorBuilder SupportedMemoryFrequencies(Collection<int> supportedFrequencies)
    {
        Processor.AddSupportedMemoryFrequencies(supportedFrequencies);
        return this;
    }

    public ProcessorBuilder WithTdp(int tdp)
    {
        Processor.Tdp = tdp;
        return this;
    }

    public ProcessorBuilder PowerConsumption(int powerConsumption)
    {
        Processor.PowerConsumption = powerConsumption;
        return this;
    }

    public Processor Build()
    {
        return Processor;
    }
}