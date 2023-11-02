using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository.InMemory;

public class ProcessorCoolingInMemoryRepository : IRepository<ProcessorCoolingSystem>
{
    private Collection<ProcessorCoolingSystem> _processorCoolingList;
    public ProcessorCoolingInMemoryRepository()
    {
        _processorCoolingList = new Collection<ProcessorCoolingSystem>();

        _processorCoolingList.Add(new ProcessorCoolingSystemBuilder()
            .Name("AeroCool Verkho i")
            .DimensionsWidth(103)
            .DimensionsHeight(45)
            .DimensionsLength(103)
            .SupportedSockets(new Collection<string> { "LGA775", "LGA1150", "LGA1151", "LGA1151-v2", "LGA1155", "LGA1156", "LGA1200" })
            .Tdp(90)
            .Build());
        _processorCoolingList.Add(new ProcessorCoolingSystemBuilder()
            .Name("DEEPCOOL Alta 9")
            .DimensionsWidth(103)
            .DimensionsHeight(45)
            .DimensionsLength(103)
            .SupportedSockets(new Collection<string> { "LGA775", "LGA1150", "LGA1151", "LGA1151-v2", "LGA1155", "LGA1156", "LGA1200" })
            .Tdp(10)
            .Build());
    }

    public Collection<ProcessorCoolingSystem> ReadOnlyCollection => _processorCoolingList;

    public IEnumerable<ProcessorCoolingSystem> GetAll()
    {
        return _processorCoolingList;
    }

    public void AddMemoryList(ProcessorCoolingSystem inMemory)
    {
        _processorCoolingList.Add(inMemory);
    }
}