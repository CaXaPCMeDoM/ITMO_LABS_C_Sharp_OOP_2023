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

    public int Height { get; set; }
    public int Width { get; set; }
    public int Memory { get; set; }
    public string PciVersion { get; set; }
    public int ChipFrequency { get; set; }
    public int PowerConsumption { get; set; }
    public string Name { get; set; }

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
}