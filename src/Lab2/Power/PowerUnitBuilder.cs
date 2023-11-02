using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.Power;

public class PowerUnitBuilder : IPowerUnitBuilder
{
    private const int _emptyVariable = 0;
    private int _peakLoad = _emptyVariable;

    public PowerUnitBuilder PeakLoad(int peakLoad)
    {
        _peakLoad = peakLoad;
        return this;
    }

    public Power.PowerUnit Builder()
    {
        if (_peakLoad == _emptyVariable)
        {
            throw new EmptyValuesException();
        }

        return new PowerUnit(_peakLoad);
    }
}