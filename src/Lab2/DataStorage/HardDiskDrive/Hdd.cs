namespace Itmo.ObjectOrientedProgramming.Lab2.DataStorage.HardDiskDrive;

public class Hdd
{
    public int Capacity { get; private set; }
    public int SpindleRotationSpeed { get; private set; }
    public int PowerConsumption { get; private set; }
    public string ConnectionType { get; } = "Sata";

    public Hdd Clone()
    {
        return new Hdd
        {
            Capacity = Capacity,
            SpindleRotationSpeed = SpindleRotationSpeed,
            PowerConsumption = PowerConsumption,
        };
    }

    internal void SetCapacity(int capacity)
    {
        Capacity = capacity;
    }

    internal void SetSpindleRotationSpeed(int spindleRotationSpeed)
    {
        SpindleRotationSpeed = spindleRotationSpeed;
    }

    internal void SetPowerConsumption(int powerConsumption)
    {
        PowerConsumption = powerConsumption;
    }
}