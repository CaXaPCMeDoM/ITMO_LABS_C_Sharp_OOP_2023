namespace Itmo.ObjectOrientedProgramming.Lab2.DataStorage.HardDiskDrive;

public class Hdd
{
    public Hdd(int capacity, int spindleRotationSpeed, int powerConsumption)
    {
        Capacity = capacity;
        SpindleRotationSpeed = spindleRotationSpeed;
        PowerConsumption = powerConsumption;
    }

    public int Capacity { get; private set; }
    public int SpindleRotationSpeed { get; private set; }
    public int PowerConsumption { get; private set; }

    public Hdd Clone()
    {
        return new Hdd(Capacity, SpindleRotationSpeed, PowerConsumption)
        {
            Capacity = Capacity,
            SpindleRotationSpeed = SpindleRotationSpeed,
            PowerConsumption = PowerConsumption,
        };
    }

    public HddBuilder Debuilder()
    {
        return new HddBuilder()
            .Capacity(Capacity)
            .PowerConsumption(PowerConsumption)
            .SpindleRotationSpeed(SpindleRotationSpeed);
    }
}