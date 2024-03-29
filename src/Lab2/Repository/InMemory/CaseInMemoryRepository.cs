using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository.InMemory;

public class CaseInMemoryRepository : IRepository<ComputerCase>
{
    private Collection<ComputerCase> _caseList;
    public CaseInMemoryRepository()
    {
        _caseList = new Collection<ComputerCase>();

        _caseList.Add(new ComputerCaseBuilder()
            .DimensionsWidth(200)
            .DimensionsHeight(423)
            .DimensionsLength(394)
            .MaximumLengthGpu(295)
            .MaximumWeightGpu(1000)
            .SupportedFormFactors(new Collection<string> { "ATX" })
            .Build());
        _caseList.Add(new ComputerCaseBuilder()
            .DimensionsWidth(2000)
            .DimensionsHeight(4230)
            .DimensionsLength(3940)
            .MaximumLengthGpu(29)
            .MaximumWeightGpu(100)
            .SupportedFormFactors(new Collection<string> { "ATX", "MICRO-ATX" })
            .Build());
    }

    public Collection<ComputerCase> ReadOnlyCollection => _caseList;

    public IEnumerable<ComputerCase> GetAll()
    {
        return _caseList;
    }

    public void AddMemoryList(ComputerCase inMemory)
    {
        _caseList.Add(inMemory);
    }
}