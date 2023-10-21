using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;

public class ProcessorCoolingSystemBuilder : IProcessorCoolingSystemBuilder
{
    internal ProcessorCoolingSystemBuilder()
    {
        ProcessorCoolingSystem = new ProcessorCoolingSystem();
    }

    private ProcessorCoolingSystem ProcessorCoolingSystem { get; }

    public ProcessorCoolingSystemBuilder Name(string name)
    {
        ProcessorCoolingSystem.SetName(name);
        return this;
    }

    public ProcessorCoolingSystemBuilder SupportedSockets(Collection<string> supportedSockets)
    {
        ProcessorCoolingSystem.AddSupportedSockets(supportedSockets);
        return this;
    }

    public ProcessorCoolingSystemBuilder Dimensions(int width, int height, int length)
    {
        ProcessorCoolingSystem.SetDimensions(width, height, length);
        return this;
    }

    public ProcessorCoolingSystemBuilder Tdp(int tdp)
    {
        ProcessorCoolingSystem.SetTdp(tdp);
        return this;
    }

    public ProcessorCoolingSystem Build()
    {
        return ProcessorCoolingSystem;
    }
}