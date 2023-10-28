namespace Itmo.ObjectOrientedProgramming.Lab2.DataStorage.SolidStateDisk;

public class SsdBuilder : ISsdBuilder
{
    private string _connectionType = string.Empty;
    private int _powerConsumption;
    private int _capacity;
    private int _maxSpeed;

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
        return new Ssd(
            _connectionType,
            _capacity,
            _maxSpeed,
            _powerConsumption);
    }
}