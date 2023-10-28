using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;

public interface IProcessorCoolingSystemBuilder
{
    ProcessorCoolingSystemBuilder Name(string name);

    ProcessorCoolingSystemBuilder Dimensions(int width, int height, int length);

    ProcessorCoolingSystemBuilder Tdp(int tdp);
    ProcessorCoolingSystemBuilder SupportedSockets(Collection<string> supportedSockets);

    ProcessorCoolingSystem Build();
}