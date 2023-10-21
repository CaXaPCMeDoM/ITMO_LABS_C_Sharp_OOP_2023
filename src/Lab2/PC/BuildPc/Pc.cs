using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.DataStorage.HardDiskDrive;
using Itmo.ObjectOrientedProgramming.Lab2.DataStorage.SolidStateDisk;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Processors;
using Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.WiFi;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.BuildPc;

public class Pc
{
    public ResultsProcessingOfPcComponents Result { get; set; } = ResultsProcessingOfPcComponents.Successful;
    public Mother.Motherboard? Motherboard { get; set; }
    public Processor? Processor { get; set; }

    public ProcessorCoolingSystem? ProcessorCoolingSystem { get; set; }

    public ICollection<Ram>? Ram { get; } = new List<Ram>();
    public ICollection<Gpu>? Gpu { get; } = new List<Gpu>();
    public ICollection<Ssd>? Ssd { get; } = new Collection<Ssd>();
    public ICollection<Hdd>? Hdd { get; } = new Collection<Hdd>();
    public ComputerCase? ComputerCase { get; set; }
    public Power.PowerUnit? PowerUnit { get; set; }
    public WiFiAdapter? WiFiAdapter { get; set; }
}