namespace Itmo.ObjectOrientedProgramming.Lab2.DataStorage.HardDiskDrive;

public class HddBuilder : IHddBuilder
{
    private int _capacity;
    private int _spindleRotationSpeed;
    private int _powerConsumption;

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
        return new Hdd(
            _capacity,
            _spindleRotationSpeed,
            _powerConsumption);
    }
}