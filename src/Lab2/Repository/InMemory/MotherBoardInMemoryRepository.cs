using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Mother;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository.InMemory;

public class MotherBoardInMemoryRepository : IRepository<Motherboard>
{
    private Collection<Motherboard> _motherboardsList;

    public MotherBoardInMemoryRepository()
    {
        _motherboardsList = new Collection<Motherboard>();

        // Добавьте доступные компоненты GPU в список
        _motherboardsList.Add(new MotherboardBuilder()
            .HaveWiFiModule(true)
            .Name("ASUS PRIME Z590-P")
            .ProcessorSocket("LGA1200")
            .NumberOfPciExpressLanes(16)
            .NumberOfSataPorts(6)
            .ChipsetSupportXmp(true)
            .ChipsetSupportedRamFrequency(new Collection<string> { "DDR4-2133", "DDR4-2400", "DDR4-2666", "DDR4-2800" })
            .SupportedRamStandard("DDR4")
            .NumberOfRamSlots(4)
            .FormFactor("ATX")
            .Bios("UEFI")
            .BiosVersion("2001")
            .BiosSupportedProcessors(new Collection<string>
                { "Intel Core i9", "Intel Core i7", "Intel Core i5", "Intel Core i3" })
            .Build());
        _motherboardsList.Add(new MotherboardBuilder()
            .Name("ASRock H310CM-DVS")
            .ProcessorSocket("Socket 1151")
            .NumberOfPciExpressLanes(6)
            .NumberOfSataPorts(4)
            .ChipsetSupportXmp(true)
            .ChipsetSupportedRamFrequency(new Collection<string>
                { "DDR4-2133", "DDR4-2400", "DDR4-2666", "DDR4-2800", "DDR4-2933", "DDR4-3200" })
            .SupportedRamStandard("DDR4")
            .NumberOfRamSlots(2)
            .FormFactor("Micro ATX")
            .Bios("UEFI")
            .BiosVersion("P2.10")
            .BiosSupportedProcessors(new Collection<string> { "Intel Core i9", "Intel Core i8", "Pentium Gold", "Celeron" })
            .Build());
        Motherboard newMotherboard = _motherboardsList[0].Clone();
        newMotherboard.FormFactor = "2002";
        _motherboardsList.Add(newMotherboard);
    }

    public Collection<Motherboard> ReadOnlyCollection => _motherboardsList;

    public IEnumerable<Motherboard> GetAll()
    {
        return _motherboardsList;
    }
}