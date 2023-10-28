namespace Itmo.ObjectOrientedProgramming.Lab2.DataStorage.HardDiskDrive;

public class Hdd
{
    public Hdd(int capacity, int spindleRotationSpeed, int powerConsumption)
    {
        Capacity = capacity;
        SpindleRotationSpeed = spindleRotationSpeed;
        PowerConsumption = powerConsumption;
    }

    public int Capacity { get; protected set; }
    public int SpindleRotationSpeed { get; protected set; }
    public int PowerConsumption { get; protected set; }

    public Hdd Clone()
    {
        return new Hdd(Capacity, SpindleRotationSpeed, PowerConsumption)
        {
            Capacity = Capacity,
            SpindleRotationSpeed = SpindleRotationSpeed,
            PowerConsumption = PowerConsumption,
        };
    }
}