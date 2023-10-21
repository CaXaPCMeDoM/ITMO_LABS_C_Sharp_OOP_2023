namespace Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

public interface IGpuBuilder
{
    public GpuBuilder Name(string name);
    public GpuBuilder Height(int height);

    public GpuBuilder Width(int width);

    public GpuBuilder Memory(int memory);

    public GpuBuilder PciVersion(string pciVersion);

    public GpuBuilder ChipFrequency(int chipFrequency);

    public GpuBuilder PowerConsumption(int powerConsumption);

    public Gpu Build();
}