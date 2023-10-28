namespace Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

public interface IGpuBuilder
{
    GpuBuilder Name(string name);
    GpuBuilder Height(int height);

    GpuBuilder Width(int width);

    GpuBuilder Memory(int memory);

    GpuBuilder PciVersion(string pciVersion);

    GpuBuilder ChipFrequency(int chipFrequency);

    GpuBuilder PowerConsumption(int powerConsumption);

    Gpu Build();
}