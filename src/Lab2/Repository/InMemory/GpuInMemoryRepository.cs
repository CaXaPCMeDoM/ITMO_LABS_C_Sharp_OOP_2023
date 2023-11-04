using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class GpuInMemoryRepository : IRepository<Gpu>
{
    private Collection<Gpu> _gpuList;

    public GpuInMemoryRepository()
    {
        _gpuList = new Collection<Gpu>();

        var gpuBuilder = new GpuBuilder();
        _gpuList.Add(gpuBuilder.Name("GTX 1660")
            .Height(10)
            .Width(20)
            .Memory(8)
            .PciVersion("PCI-E 3.0")
            .ChipFrequency(1600)
            .PowerConsumption(120)
            .Build());
        _gpuList.Add(gpuBuilder.Name("GTX 1080")
            .Height(12)
            .Width(20)
            .Memory(8)
            .PciVersion("PCI-E 3.0")
            .ChipFrequency(1800)
            .PowerConsumption(150)
            .Build());
    }

    public Collection<Gpu> ReadOnlyCollection => _gpuList;

    public IEnumerable<Gpu> GetAll()
    {
        return _gpuList;
    }

    public void AddMemoryList(Gpu inMemory)
    {
        _gpuList.Add(inMemory);
    }
}