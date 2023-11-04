using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Attributes;
using Itmo.ObjectOrientedProgramming.Lab2.Mother;
using Itmo.ObjectOrientedProgramming.Lab2.Processors;
using Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository.InMemory;

public class MotherBoardInMemoryRepository : IRepository<Motherboard>
{
    private Collection<Motherboard> _motherboardsList;

    public MotherBoardInMemoryRepository()
    {
        var ram = new RamInMemoryRepository();
        var xmp = new Xmp(20, 123, 1);
        var cpuInMemoryRepository = new CpuInMemoryRepository();
        _motherboardsList = new Collection<Motherboard>();

        // Добавьте доступные компоненты GPU в список
        _motherboardsList.Add(new MotherboardBuilder()
            .HaveWiFiModule(true)
            .Name("ASUS PRIME Z590-P")
            .ProcessorSocket("LGA1200")
            .NumberOfPciExpressLanes(16)
            .NumberOfSataPorts(6)
            .ChipsetSupportXmp(xmp)
            .ChipsetSupportedRamFrequency(new Collection<Ram> { ram.ReadOnlyCollection[0], ram.ReadOnlyCollection[1] })
            .SupportedRamStandard("DDR4")
            .NumberOfRamSlots(4)
            .FormFactor("ATX")
            .BiosType("UEFI")
            .BiosVersion("2001")
            .BiosSupportedProcessors(new Collection<Processor>
                { cpuInMemoryRepository.ReadOnlyCollection[0], cpuInMemoryRepository.ReadOnlyCollection[1] })
            .Build());
        _motherboardsList.Add(new MotherboardBuilder()
            .Name("ASRock H310CM-DVS")
            .ProcessorSocket("Socket 1151")
            .NumberOfPciExpressLanes(6)
            .NumberOfSataPorts(4)
            .ChipsetSupportXmp(null)
            .ChipsetSupportedRamFrequency(new Collection<Ram>
                { ram.ReadOnlyCollection[0], ram.ReadOnlyCollection[1] })
            .SupportedRamStandard("DDR4")
            .NumberOfRamSlots(2)
            .FormFactor("Micro ATX")
            .BiosType("UEFI")
            .BiosVersion("P2.10")
            .BiosSupportedProcessors(new Collection<Processor> { cpuInMemoryRepository.ReadOnlyCollection[0], cpuInMemoryRepository.ReadOnlyCollection[1] })
            .Build());
        Motherboard newMotherboard;
        MotherboardBuilder newMotherboardBuilder = _motherboardsList[0].Clone().Debuilder();
        newMotherboardBuilder.FormFactor("2002");
        newMotherboard = newMotherboardBuilder.Build();
        _motherboardsList.Add(newMotherboard);
    }

    public Collection<Motherboard> ReadOnlyCollection => _motherboardsList;

    public IEnumerable<Motherboard> GetAll()
    {
        return _motherboardsList;
    }

    public void AddMemoryList(Motherboard inMemory)
    {
        _motherboardsList.Add(inMemory);
    }
}