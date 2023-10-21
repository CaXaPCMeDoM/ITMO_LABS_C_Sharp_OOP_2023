using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository.InMemory;

public class CaseInMemoryRepository : IRepository<ComputerCase>
{
    private Collection<ComputerCase> _processorList;
    public CaseInMemoryRepository()
    {
        _processorList = new Collection<ComputerCase>();

        _processorList.Add(new ComputerCaseBuilder()
            .Dimensions(200, 423, 394)
            .MaximumDimensionsGpu(295, 1000)
            .SupportedFormFactors(new Collection<string> { "ATX" })
            .Build());
        _processorList.Add(new ComputerCaseBuilder()
            .Dimensions(2000, 4203, 3904)
            .MaximumDimensionsGpu(29, 100)
            .SupportedFormFactors(new Collection<string> { "ATX", "MICRO-ATX" })
            .Build());
    }

    public Collection<ComputerCase> ReadOnlyCollection => _processorList;

    public IEnumerable<ComputerCase> GetAll()
    {
        return _processorList;
    }
}