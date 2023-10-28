namespace Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

public class GpuBuilder : IGpuBuilder
{
    private string _name = string.Empty;
    private int _height;
    private int _width;
    private int _memory;
    private string _pciVersion = string.Empty;
    private int _chipFrequency;
    private int _powerConsumption;

    public GpuBuilder Name(string name)
    {
        _name = name;
        return this;
    }

    public GpuBuilder Height(int height)
    {
        _height = height;
        return this;
    }

    public GpuBuilder Width(int width)
    {
        _width = width;
        return this;
    }

    public GpuBuilder Memory(int memory)
    {
        _memory = memory;
        return this;
    }

    public GpuBuilder PciVersion(string pciVersion)
    {
        _pciVersion = pciVersion;
        return this;
    }

    public GpuBuilder ChipFrequency(int chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public GpuBuilder PowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Gpu Build()
    {
        return new Gpu(
            _height,
            _width,
            _memory,
            _pciVersion,
            _chipFrequency,
            _powerConsumption,
            _name);
    }
}