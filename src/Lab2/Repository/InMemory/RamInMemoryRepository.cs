using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository.InMemory;

public class RamInMemoryRepository : IRepository<Ram>
{
    private Collection<Ram> _processorList;
    public RamInMemoryRepository()
    {
        _processorList = new Collection<Ram>();

        _processorList.Add(new RamBuilder()
            .AvailableProfile("XMP")
            .AvailableTimings(16)
            .AvailableFrequency(17)
            .AvailableVoltage(36)
            .RamSize(4)
            .FormFactor("DIMM")
            .SupportedFrequencyAndVoltage(2, 1.2)
            .DdrVersion("DDR4")
            .PowerConsumption(1.2)
            .Build());
        _processorList.Add(new RamBuilder()
            .RamSize(4)
            .FormFactor("DIMM")
            .SupportedFrequencyAndVoltage(2, 1.2)
            .DdrVersion("DDR3")
            .PowerConsumption(1.2)
            .Build());
    }

    public Collection<Ram> ReadOnlyCollection => _processorList;

    public IEnumerable<Ram> GetAll()
    {
        return _processorList;
    }
}