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

    public string ConnectionType { get; protected set; } = string.Empty;
    public int Capacity { get; protected set; }
    public int MaxSpeed { get; protected set; }
    public int PowerConsumption { get; protected set; }

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
}