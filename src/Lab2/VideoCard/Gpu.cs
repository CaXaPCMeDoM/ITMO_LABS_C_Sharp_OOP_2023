namespace Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

public class Gpu
{
    public Gpu(int height, int width, int memory, string pciVersion, int chipFrequency, int powerConsumption, string name)
    {
        Height = height;
        Width = width;
        Memory = memory;
        PciVersion = pciVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
        Name = name;
    }

    public int Height { get; private set; }
    public int Width { get; private set; }
    public int Memory { get; private set; }
    public string PciVersion { get; private set; }
    public int ChipFrequency { get; private set; }
    public int PowerConsumption { get; private set; }
    public string Name { get; private set; }

    public Gpu Clone()
    {
        return new Gpu(
            Height,
            Width,
            Memory,
            PciVersion,
            ChipFrequency,
            PowerConsumption,
            Name)
        {
            Height = Height,
            PowerConsumption = PowerConsumption,
            Width = Width,
            Memory = Memory,
            PciVersion = PciVersion,
            ChipFrequency = ChipFrequency,
            Name = Name,
        };
    }

    public GpuBuilder Debuilder()
    {
        return new GpuBuilder()
            .Height(Height)
            .Width(Width)
            .Memory(Memory)
            .PciVersion(PciVersion)
            .ChipFrequency(ChipFrequency)
            .PowerConsumption(PowerConsumption)
            .Name(Name);
    }
}