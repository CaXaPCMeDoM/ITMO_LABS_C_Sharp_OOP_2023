namespace Itmo.ObjectOrientedProgramming.Lab2.DataStorage.SolidStateDisk;

public interface ISsdBuilder
{
    SsdBuilder ConnectionType(string connectionType);

    SsdBuilder Capacity(int capacity);

    SsdBuilder MaxSpeed(int maxSpeed);

    SsdBuilder PowerConsumption(int powerConsumption);

    Ssd Builder();
}