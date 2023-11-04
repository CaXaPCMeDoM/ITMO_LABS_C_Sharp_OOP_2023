using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.DataStorage.HardDiskDrive;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository.InMemory;

public class HddInMemoryRepository : IRepository<Hdd>
{
    private Collection<Hdd> _hddList;
    public HddInMemoryRepository()
    {
        _hddList = new Collection<Hdd>();

        _hddList.Add(new HddBuilder()
            .Capacity(1024)
            .PowerConsumption(1)
            .SpindleRotationSpeed(1000)
            .Builder());
        _hddList.Add(new HddBuilder()
            .Capacity(2024)
            .PowerConsumption(2)
            .SpindleRotationSpeed(10000)
            .Builder());
    }

    public Collection<Hdd> ReadOnlyCollection => _hddList;

    public IEnumerable<Hdd> GetAll()
    {
        return _hddList;
    }

    public void AddMemoryList(Hdd inMemory)
    {
        _hddList.Add(inMemory);
    }
}