using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;

public class ComputerCaseBuilder : IComputerCaseBuilder
{
    private const int _emptyVariable = 0;
    private int _maxLengthGpu = _emptyVariable;
    private int _maxWidthGpu = _emptyVariable;
    private ICollection<string>? _supportedFormFactors = new List<string>();
    private int _width = _emptyVariable;
    private int _height = _emptyVariable;
    private int _length = _emptyVariable;

    public ComputerCaseBuilder MaximumLengthGpu(int length)
    {
        _maxLengthGpu = length;
        return this;
    }

    public ComputerCaseBuilder MaximumWeightGpu(int weight)
    {
        _maxWidthGpu = weight;
        return this;
    }

    public ComputerCaseBuilder SupportedFormFactors(Collection<string>? supportedFormFactors)
    {
        if (supportedFormFactors is not null)
        {
            foreach (string formFactor in supportedFormFactors)
            {
                _supportedFormFactors?.Add(formFactor);
            }
        }

        return this;
    }

    public ComputerCaseBuilder DimensionsWidth(int width)
    {
        _width = width;
        return this;
    }

    public ComputerCaseBuilder DimensionsHeight(int height)
    {
        _height = height;
        return this;
    }

    public ComputerCaseBuilder DimensionsLength(int length)
    {
        _length = length;
        return this;
    }

    public ComputerCase Build()
    {
        if (_maxLengthGpu == _emptyVariable ||
            _maxWidthGpu == _emptyVariable ||
            _supportedFormFactors == null ||
            _supportedFormFactors.Count == _emptyVariable ||
            _width == _emptyVariable ||
            _height == _emptyVariable ||
            _length == _emptyVariable)
        {
            throw new EmptyValuesException();
        }

        var dimensions = new Dimensions(_width, _height, _length);
        return new ComputerCase(
            _maxLengthGpu,
            _maxWidthGpu,
            _supportedFormFactors,
            dimensions);
    }
}