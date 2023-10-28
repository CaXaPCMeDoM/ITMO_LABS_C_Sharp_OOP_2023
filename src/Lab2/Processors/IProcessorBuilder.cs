using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processors;

public interface IProcessorBuilder
{
    ProcessorBuilder Name(string name);
    ProcessorBuilder CoreFrequency(int frequency);

    ProcessorBuilder Cores(int cores);

    ProcessorBuilder Socket(string socket);

    ProcessorBuilder IntegratedGraphics(bool integratedGraphics);

    ProcessorBuilder SupportedMemoryFrequencies(Collection<int> supportedFrequencies);

    ProcessorBuilder WithTdp(int tdp);

    ProcessorBuilder PowerConsumption(int powerConsumption);

    Processor Build();
}