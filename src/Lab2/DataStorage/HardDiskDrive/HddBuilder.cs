namespace Itmo.ObjectOrientedProgramming.Lab2.DataStorage.HardDiskDrive;

public class HddBuilder : IHddBuilder
{
    internal HddBuilder()
    {
        Hdd = new Hdd();
    }

    private Hdd Hdd { get; }

    public HddBuilder Capacity(int capacity)
    {
        Hdd.SetCapacity(capacity);
        return this;
    }

    public HddBuilder SpindleRotationSpeed(int spindleRotationSpeed)
    {
        Hdd.SetSpindleRotationSpeed(spindleRotationSpeed);
        return this;
    }

    public HddBuilder PowerConsumption(int powerConsumption)
    {
        Hdd.SetPowerConsumption(powerConsumption);
        return this;
    }

    public Hdd Builder()
    {
        return Hdd;
    }
}