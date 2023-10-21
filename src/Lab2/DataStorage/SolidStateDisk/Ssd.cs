namespace Itmo.ObjectOrientedProgramming.Lab2.DataStorage.SolidStateDisk;

public class Ssd
{
    public string ConnectionType { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public int MaxSpeed { get; set; }
    public int PowerConsumption { get; set; }

    public Ssd Clone()
    {
        return new Ssd()
        {
            ConnectionType = ConnectionType,
            PowerConsumption = PowerConsumption,
            MaxSpeed = MaxSpeed,
            Capacity = Capacity,
        };
    }
}