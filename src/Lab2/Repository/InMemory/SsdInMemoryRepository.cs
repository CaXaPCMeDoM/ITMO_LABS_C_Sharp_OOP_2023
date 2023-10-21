using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.DataStorage.SolidStateDisk;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository.InMemory;

public class SsdInMemoryRepository : IRepository<Ssd>
{
    private Collection<Ssd> _processorList;
    public SsdInMemoryRepository()
    {
        _processorList = new Collection<Ssd>();

        _processorList.Add(new SsdBuilder()
            .ConnectionType("SATA")
            .PowerConsumption(1)
            .Capacity(120)
            .MaxSpeed(520)
            .Builder());
        _processorList.Add(new SsdBuilder()
            .ConnectionType("SATA")
            .PowerConsumption(1)
            .Capacity(1200)
            .MaxSpeed(5200)
            .Builder());
    }

    public Collection<Ssd> ReadOnlyCollection => _processorList;

    public IEnumerable<Ssd> GetAll()
    {
        return _processorList;
    }
}