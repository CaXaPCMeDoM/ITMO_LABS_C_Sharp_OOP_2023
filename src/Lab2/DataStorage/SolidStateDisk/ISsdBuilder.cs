namespace Itmo.ObjectOrientedProgramming.Lab2.DataStorage.SolidStateDisk;

public interface ISsdBuilder
{
    public SsdBuilder ConnectionType(string connectionType);

    public SsdBuilder Capacity(int capacity);

    public SsdBuilder MaxSpeed(int maxSpeed);

    public SsdBuilder PowerConsumption(int powerConsumption);

    public Ssd Builder();
}