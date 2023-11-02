using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.DataStorage.SolidStateDisk;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository.InMemory;

public class SsdInMemoryRepository : IRepository<Ssd>
{
    private Collection<Ssd> _ssdList;
    public SsdInMemoryRepository()
    {
        _ssdList = new Collection<Ssd>();

        _ssdList.Add(new SsdBuilder()
            .ConnectionType("SATA")
            .PowerConsumption(1)
            .Capacity(120)
            .MaxSpeed(520)
            .Builder());
        _ssdList.Add(new SsdBuilder()
            .ConnectionType("SATA")
            .PowerConsumption(1)
            .Capacity(1200)
            .MaxSpeed(5200)
            .Builder());
    }

    public Collection<Ssd> ReadOnlyCollection => _ssdList;

    public IEnumerable<Ssd> GetAll()
    {
        return _ssdList;
    }

    public void AddMemoryList(Ssd inMemory)
    {
        _ssdList.Add(inMemory);
    }
}