using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Power;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository.InMemory;

public class PowerUnitInMemoryRepository : IRepository<PowerUnit>
{
    private Collection<PowerUnit> _powerUnitList;
    public PowerUnitInMemoryRepository()
    {
        _powerUnitList = new Collection<Power.PowerUnit>();

        _powerUnitList.Add(new PowerUnitBuilder()
            .PeakLoad(500)
            .Builder());
        _powerUnitList.Add(new PowerUnitBuilder()
            .PeakLoad(100)
            .Builder());
    }

    public Collection<PowerUnit> ReadOnlyCollection => _powerUnitList;

    public IEnumerable<PowerUnit> GetAll()
    {
        return _powerUnitList;
    }

    public void AddMemoryList(PowerUnit inMemory)
    {
        _powerUnitList.Add(inMemory);
    }
}