namespace Itmo.ObjectOrientedProgramming.Lab2.DataStorage.HardDiskDrive;

public interface IHddBuilder
{
    HddBuilder Capacity(int capacity);

    HddBuilder SpindleRotationSpeed(int spindleRotationSpeed);

    HddBuilder PowerConsumption(int powerConsumption);

    Hdd Builder();
}