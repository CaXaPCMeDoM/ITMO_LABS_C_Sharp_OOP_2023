using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository.InMemory;

public class ProcessorCoolingInMemoryRepository : IRepository<ProcessorCoolingSystem>
{
    private Collection<ProcessorCoolingSystem> _processorList;
    public ProcessorCoolingInMemoryRepository()
    {
        _processorList = new Collection<ProcessorCoolingSystem>();

        _processorList.Add(new ProcessorCoolingSystemBuilder()
            .Name("AeroCool Verkho i")
            .Dimensions(103, 45, 103)
            .SupportedSockets(new Collection<string> { "LGA775", "LGA1150", "LGA1151", "LGA1151-v2", "LGA1155", "LGA1156", "LGA1200" })
            .Tdp(90)
            .Build());
        _processorList.Add(new ProcessorCoolingSystemBuilder()
            .Name("DEEPCOOL Alta 9")
            .Dimensions(103, 45, 103)
            .SupportedSockets(new Collection<string> { "LGA775", "LGA1150", "LGA1151", "LGA1151-v2", "LGA1155", "LGA1156", "LGA1200" })
            .Tdp(10)
            .Build());
    }

    public Collection<ProcessorCoolingSystem> ReadOnlyCollection => _processorList;

    public IEnumerable<ProcessorCoolingSystem> GetAll()
    {
        return _processorList;
    }
}