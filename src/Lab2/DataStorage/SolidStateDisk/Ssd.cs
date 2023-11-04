namespace Itmo.ObjectOrientedProgramming.Lab2.DataStorage.SolidStateDisk;

public class Ssd
{
    public Ssd(string connectionType, int capacity, int maxSpeed, int powerConsumption)
    {
        ConnectionType = connectionType;
        Capacity = capacity;
        MaxSpeed = maxSpeed;
        PowerConsumption = powerConsumption;
    }

    public string ConnectionType { get; private set; }
    public int Capacity { get; private set; }
    public int MaxSpeed { get; private set; }
    public int PowerConsumption { get; private set; }

    public Ssd Clone()
    {
        return new Ssd(ConnectionType, Capacity, MaxSpeed, PowerConsumption)
        {
            ConnectionType = ConnectionType,
            PowerConsumption = PowerConsumption,
            MaxSpeed = MaxSpeed,
            Capacity = Capacity,
        };
    }

    public SsdBuilder Debuilder()
    {
        return new SsdBuilder()
            .Capacity(Capacity)
            .ConnectionType(ConnectionType)
            .PowerConsumption(PowerConsumption)
            .MaxSpeed(MaxSpeed);
    }
}