using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository.InMemory;

public class RamInMemoryRepository : IRepository<Ram>
{
    private Collection<Ram> _ramList;
    public RamInMemoryRepository()
    {
        _ramList = new Collection<Ram>();

        _ramList.Add(new RamBuilder()
            .AvailableProfile(new Collection<string> { "XMP" })
            .AvailableTimings(16)
            .AvailableFrequency(17)
            .AvailableVoltage(36)
            .RamSize(4)
            .FormFactor("DIMM")
            .SupportedFrequency(new Collection<int> { 2 })
            .SupportedVoltage(new Collection<double> { 1.2 })
            .DdrVersion("DDR4")
            .PowerConsumption(1.2)
            .Build());
        _ramList.Add(new RamBuilder()
            .RamSize(4)
            .FormFactor("DIMM")
            .SupportedFrequency(new Collection<int> { 2 })
            .SupportedVoltage(new Collection<double> { 1.2 })
            .DdrVersion("DDR3")
            .PowerConsumption(1.2)
            .Build());
    }

    public Collection<Ram> ReadOnlyCollection => _ramList;

    public IEnumerable<Ram> GetAll()
    {
        return _ramList;
    }

    public void AddMemoryList(Ram inMemory)
    {
        _ramList.Add(inMemory);
    }
}