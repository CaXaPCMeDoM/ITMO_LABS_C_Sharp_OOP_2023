namespace Itmo.ObjectOrientedProgramming.Lab2.DataStorage.SolidStateDisk;

public class SsdBuilder : ISsdBuilder
{
    internal SsdBuilder()
    {
        Ssd = new Ssd();
    }

    private Ssd Ssd { get; set; }

    public SsdBuilder ConnectionType(string connectionType)
    {
        Ssd.ConnectionType = connectionType;
        return this;
    }

    public SsdBuilder Capacity(int capacity)
    {
        Ssd.Capacity = capacity;
        return this;
    }

    public SsdBuilder MaxSpeed(int maxSpeed)
    {
        Ssd.MaxSpeed = maxSpeed;
        return this;
    }

    public SsdBuilder PowerConsumption(int powerConsumption)
    {
        Ssd.PowerConsumption = powerConsumption;
        return this;
    }

    public Ssd Builder()
    {
        return Ssd;
    }
}