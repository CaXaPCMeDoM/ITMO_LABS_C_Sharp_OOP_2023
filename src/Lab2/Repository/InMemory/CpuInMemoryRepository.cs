using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Processors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository.InMemory;

public class CpuInMemoryRepository : IRepository<Processor>
{
    private Collection<Processor> _processorList;
    public CpuInMemoryRepository()
    {
        _processorList = new Collection<Processor>();

        _processorList.Add(new ProcessorBuilder()
            .Name("Intel Core i3")
            .PowerConsumption(65)
            .Socket("LGA1200")
            .Cores(4)
            .CoreFrequency(3)
            .IntegratedGraphics(false)
            .WithTdp(65)
            .SupportedMemoryFrequencies(new Collection<int> { 4 })
            .Build());
        _processorList.Add(new ProcessorBuilder()
            .Name("Intel Core i3")
            .PowerConsumption(58)
            .Socket("LGA1200")
            .Cores(4)
            .CoreFrequency(3)
            .IntegratedGraphics(false)
            .WithTdp(58)
            .SupportedMemoryFrequencies(new Collection<int> { 4 })
            .Build());
    }

    public Collection<Processor> ReadOnlyCollection => _processorList;

    public IEnumerable<Processor> GetAll()
    {
        return _processorList;
    }
}