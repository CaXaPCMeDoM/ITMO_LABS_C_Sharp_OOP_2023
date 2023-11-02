namespace Itmo.ObjectOrientedProgramming.Lab2.DataStorage.SolidStateDisk;

public interface ISsdBuilder
{
    protected SsdBuilder ConnectionType(string connectionType);

    protected SsdBuilder Capacity(int capacity);

    protected SsdBuilder MaxSpeed(int maxSpeed);

    protected SsdBuilder PowerConsumption(int powerConsumption);

    protected Ssd Builder();
}