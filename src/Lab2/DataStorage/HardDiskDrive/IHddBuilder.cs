namespace Itmo.ObjectOrientedProgramming.Lab2.DataStorage.HardDiskDrive;

public interface IHddBuilder
{
    public HddBuilder Capacity(int capacity);

    public HddBuilder SpindleRotationSpeed(int spindleRotationSpeed);

    public HddBuilder PowerConsumption(int powerConsumption);

    public Hdd Builder();
}