using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

public class GpuBuilder : IGpuBuilder
{
    private const int _emptyVariable = 0;
    private string _name = string.Empty;
    private int _height = _emptyVariable;
    private int _width = _emptyVariable;
    private int _memory = _emptyVariable;
    private string _pciVersion = string.Empty;
    private int _chipFrequency = _emptyVariable;
    private int _powerConsumption = _emptyVariable;

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
        if (_height == _emptyVariable ||
            _width == _emptyVariable ||
            _memory == _emptyVariable ||
            _pciVersion.Length == _emptyVariable ||
            _chipFrequency == _emptyVariable ||
            _powerConsumption == _emptyVariable ||
            _name.Length == _emptyVariable)
        {
            throw new EmptyValuesException();
        }

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