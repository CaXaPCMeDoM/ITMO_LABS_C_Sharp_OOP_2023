using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Power;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository.InMemory;

public class PowerUnitInMemoryRepository : IRepository<PowerUnit>
{
    private Collection<PowerUnit> _processorList;
    public PowerUnitInMemoryRepository()
    {
        _processorList = new Collection<Power.PowerUnit>();

        _processorList.Add(new PowerUnitBuilder()
            .PeakLoad(500)
            .Builder());
        _processorList.Add(new PowerUnitBuilder()
            .PeakLoad(100)
            .Builder());
    }

    public Collection<PowerUnit> ReadOnlyCollection => _processorList;

    public IEnumerable<PowerUnit> GetAll()
    {
        return _processorList;
    }
}