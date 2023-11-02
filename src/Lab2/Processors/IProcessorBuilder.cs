using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processors;

public interface IProcessorBuilder
{
    protected ProcessorBuilder Name(string name);
    protected ProcessorBuilder CoreFrequency(int frequency);

    protected ProcessorBuilder Cores(int cores);

    protected ProcessorBuilder Socket(string socket);

    protected ProcessorBuilder IntegratedGraphics(bool integratedGraphics);

    protected ProcessorBuilder SupportedMemoryFrequencies(Collection<int> supportedFrequencies);

    protected ProcessorBuilder Tdp(int tdp);

    protected ProcessorBuilder PowerConsumption(int powerConsumption);

    protected Processor Build();
}