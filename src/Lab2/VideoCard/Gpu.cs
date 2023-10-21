namespace Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

public class Gpu
{
    public int Height { get; set; }
    public int Width { get; set; }
    public int Memory { get; set; }
    public string PciVersion { get; set; } = string.Empty;
    public int ChipFrequency { get; set; }
    public int PowerConsumption { get; set; }
    public string Name { get; set; } = string.Empty;

    public Gpu Clone()
    {
        return new Gpu()
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