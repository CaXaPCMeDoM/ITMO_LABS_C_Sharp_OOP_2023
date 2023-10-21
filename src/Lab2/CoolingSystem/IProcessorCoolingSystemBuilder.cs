using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;

public interface IProcessorCoolingSystemBuilder
{
    public ProcessorCoolingSystemBuilder Name(string name);

    public ProcessorCoolingSystemBuilder Dimensions(int width, int height, int length);

    public ProcessorCoolingSystemBuilder Tdp(int tdp);
    public ProcessorCoolingSystemBuilder SupportedSockets(Collection<string> supportedSockets);

    public ProcessorCoolingSystem Build();
}