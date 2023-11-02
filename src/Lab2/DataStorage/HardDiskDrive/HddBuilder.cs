using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.DataStorage.HardDiskDrive;

public class HddBuilder : IHddBuilder
{
    private const int _emptyVariable = 0;
    private int _capacity = _emptyVariable;
    private int _spindleRotationSpeed = _emptyVariable;
    private int _powerConsumption = _emptyVariable;

    public HddBuilder Capacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public HddBuilder SpindleRotationSpeed(int spindleRotationSpeed)
    {
        _spindleRotationSpeed = spindleRotationSpeed;
        return this;
    }

    public HddBuilder PowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Hdd Builder()
    {
        if (_capacity == _emptyVariable ||
            _powerConsumption == _emptyVariable ||
            _spindleRotationSpeed == _emptyVariable)
        {
            throw new EmptyValuesException();
        }

        return new Hdd(
            _capacity,
            _spindleRotationSpeed,
            _powerConsumption);
    }
}