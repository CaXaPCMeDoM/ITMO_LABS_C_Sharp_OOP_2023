using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;

public interface IProcessorCoolingSystemBuilder
{
    ProcessorCoolingSystemBuilder Name(string name);

    public ProcessorCoolingSystemBuilder DimensionsWidth(int width);
    public ProcessorCoolingSystemBuilder DimensionsHeight(int height);
    public ProcessorCoolingSystemBuilder DimensionsLength(int length);
    ProcessorCoolingSystemBuilder Tdp(int tdp);
    ProcessorCoolingSystemBuilder SupportedSockets(Collection<string> supportedSockets);

    ProcessorCoolingSystem Build();
}