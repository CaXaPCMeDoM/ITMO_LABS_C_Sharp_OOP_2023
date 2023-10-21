namespace Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

public class GpuBuilder : IGpuBuilder
{
    internal GpuBuilder()
    {
        Gpu = new Gpu();
    }

    private Gpu Gpu { get; set; }

    public GpuBuilder Name(string name)
    {
        Gpu.Name = name;
        return this;
    }

    public GpuBuilder Height(int height)
    {
        Gpu.Height = height;
        return this;
    }

    public GpuBuilder Width(int width)
    {
        Gpu.Width = width;
        return this;
    }

    public GpuBuilder Memory(int memory)
    {
        Gpu.Memory = memory;
        return this;
    }

    public GpuBuilder PciVersion(string pciVersion)
    {
        Gpu.PciVersion = pciVersion;
        return this;
    }

    public GpuBuilder ChipFrequency(int chipFrequency)
    {
        Gpu.ChipFrequency = chipFrequency;
        return this;
    }

    public GpuBuilder PowerConsumption(int powerConsumption)
    {
        Gpu.PowerConsumption = powerConsumption;
        return this;
    }

    public Gpu Build()
    {
        return Gpu;
    }
}