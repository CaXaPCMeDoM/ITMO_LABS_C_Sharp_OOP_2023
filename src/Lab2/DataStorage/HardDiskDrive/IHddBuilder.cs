namespace Itmo.ObjectOrientedProgramming.Lab2.DataStorage.HardDiskDrive;

public interface IHddBuilder
{
    protected HddBuilder Capacity(int capacity);

    protected HddBuilder SpindleRotationSpeed(int spindleRotationSpeed);

    protected HddBuilder PowerConsumption(int powerConsumption);

    protected Hdd Builder();
}