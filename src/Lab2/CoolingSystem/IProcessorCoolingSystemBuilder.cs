using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;

public interface IProcessorCoolingSystemBuilder
{
    ProcessorCoolingSystemBuilder Name(string name);

    protected ProcessorCoolingSystemBuilder DimensionsWidth(int width);
    protected ProcessorCoolingSystemBuilder DimensionsHeight(int height);
    protected ProcessorCoolingSystemBuilder DimensionsLength(int length);
    protected ProcessorCoolingSystemBuilder Tdp(int tdp);
    protected ProcessorCoolingSystemBuilder SupportedSockets(Collection<string> supportedSockets);

    protected ProcessorCoolingSystem Build();
}