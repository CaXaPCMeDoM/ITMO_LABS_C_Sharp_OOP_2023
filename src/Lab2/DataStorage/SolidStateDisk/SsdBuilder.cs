using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.DataStorage.SolidStateDisk;

public class SsdBuilder : ISsdBuilder
{
    private const int _emptyVariable = 0;
    private string _connectionType = string.Empty;
    private int _powerConsumption = _emptyVariable;
    private int _capacity = _emptyVariable;
    private int _maxSpeed = _emptyVariable;

    public SsdBuilder ConnectionType(string connectionType)
    {
        _connectionType = connectionType;
        return this;
    }

    public SsdBuilder Capacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public SsdBuilder MaxSpeed(int maxSpeed)
    {
        _maxSpeed = maxSpeed;
        return this;
    }

    public SsdBuilder PowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Ssd Builder()
    {
        if (_capacity == _emptyVariable ||
            _powerConsumption == _emptyVariable ||
            _maxSpeed == _emptyVariable ||
            _connectionType.Length == _emptyVariable)
        {
            throw new EmptyValuesException();
        }

        return new Ssd(
            _connectionType,
            _capacity,
            _maxSpeed,
            _powerConsumption);
    }
}