using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processors;

public interface IProcessorBuilder
{
    public ProcessorBuilder Name(string name);
    public ProcessorBuilder CoreFrequency(int frequency);

    public ProcessorBuilder Cores(int cores);

    public ProcessorBuilder Socket(string socket);

    public ProcessorBuilder IntegratedGraphics(bool integratedGraphics);

    public ProcessorBuilder SupportedMemoryFrequencies(Collection<int> supportedFrequencies);

    public ProcessorBuilder WithTdp(int tdp);

    public ProcessorBuilder PowerConsumption(int powerConsumption);

    public Processor Build();
}