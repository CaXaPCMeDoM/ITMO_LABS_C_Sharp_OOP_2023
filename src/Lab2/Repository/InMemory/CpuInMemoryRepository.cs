using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Processors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository.InMemory;

public class CpuInMemoryRepository : IRepository<Processor>
{
    private Collection<Processor> _cpuList;
    public CpuInMemoryRepository()
    {
        _cpuList = new Collection<Processor>();

        _cpuList.Add(new ProcessorBuilder()
            .Name("Intel Core i3")
            .PowerConsumption(65)
            .Socket("LGA1200")
            .Cores(4)
            .CoreFrequency(3)
            .IntegratedGraphics(false)
            .Tdp(65)
            .SupportedMemoryFrequencies(new Collection<int> { 4 })
            .Build());
        _cpuList.Add(new ProcessorBuilder()
            .Name("Intel Core i3")
            .PowerConsumption(58)
            .Socket("LGA1200")
            .Cores(4)
            .CoreFrequency(3)
            .IntegratedGraphics(false)
            .Tdp(58)
            .SupportedMemoryFrequencies(new Collection<int> { 4 })
            .Build());
    }

    public Collection<Processor> ReadOnlyCollection => _cpuList;

    public IEnumerable<Processor> GetAll()
    {
        return _cpuList;
    }

    public void AddMemoryList(Processor inMemory)
    {
        _cpuList.Add(inMemory);
    }
}