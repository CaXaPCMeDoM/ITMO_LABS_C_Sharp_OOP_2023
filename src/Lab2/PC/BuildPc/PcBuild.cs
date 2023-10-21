using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.DataStorage.HardDiskDrive;
using Itmo.ObjectOrientedProgramming.Lab2.DataStorage.SolidStateDisk;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.PC.ValidationCheck;
using Itmo.ObjectOrientedProgramming.Lab2.Processors;
using Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;
using Itmo.ObjectOrientedProgramming.Lab2.Sales;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.WiFi;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.BuildPc;

public class PcBuild
{
    public PcBuild()
    {
        Pc = new Pc();
    }

    public int ResultBuild { get; private set; } = (int)ResultsProcessingOfPcComponents.Successful;
    private Pc Pc { get; set; }

    public PcBuild MotherboardBuilder(Mother.Motherboard? motherboard)
    {
        if (Pc.Processor is not null)
        {
            if (Validation.SocketOfTheProcessorAndTheMotherboardAreTheSame(
                    motherboard,
                    Pc.Processor))
            {
            }
            else
            {
                Pc.Result = ResultsProcessingOfPcComponents.SupportSocketError;
                return this;
            }

            return this;
        }

        if (Pc.Motherboard?.NumberOfPciExpressLanes <= Pc.Gpu?.Count)
        {
            Pc.Result = ResultsProcessingOfPcComponents.PcieCountError;
            return this;
        }

        if (Pc.ComputerCase != null)
        {
            if (Pc.ComputerCase.SupportedFormFactors?.Any() == true)
            {
                bool flagCheckFormFactor = false;
                foreach (string supportedFormFactor in Pc.ComputerCase.SupportedFormFactors)
                {
                    if (supportedFormFactor == motherboard?.FormFactor)
                    {
                        flagCheckFormFactor = true;
                    }
                }

                if (!flagCheckFormFactor)
                {
                    Pc.Result = ResultsProcessingOfPcComponents.FormFactorError;
                    return this;
                }
            }
        }

        bool flagSupportSocket = true;
        if (Pc.ProcessorCoolingSystem != null)
        {
            flagSupportSocket = false;
            foreach (string collingSupportSocket in Pc.ProcessorCoolingSystem.SupportedSockets)
            {
                if (collingSupportSocket == motherboard?.ProcessorSocket)
                {
                    flagSupportSocket = true;
                }
            }
        }

        int totalSataPorts = Pc.Motherboard?.NumberOfSataPorts ?? 0;
        int? requiredSataPorts = Pc.Ssd?.Count + Pc.Hdd?.Count;
        if (totalSataPorts < requiredSataPorts)
        {
            Pc.Result = ResultsProcessingOfPcComponents.SataCountError;
            return this;
        }

        if (!flagSupportSocket)
        {
            Pc.Result = ResultsProcessingOfPcComponents.SupportSocketError;
            return this;
        }

        Pc.Motherboard = motherboard;
        return this;
    }

    public PcBuild ProcessorBuilder(Processor? processor)
    {
        if (Pc.Motherboard != null && processor != null)
        {
            // Проверка совместимости сокетов
            if (!Validation.SocketOfTheProcessorAndTheMotherboardAreTheSame(
                    Pc.Motherboard,
                    processor))
            {
                Pc.Result = ResultsProcessingOfPcComponents.SupportSocketError;
                return this;
            }

            // Проверка совместимости системы охлаждения
            bool flagSupportSocket = true;
            if (Pc.ProcessorCoolingSystem != null)
            {
                flagSupportSocket = false;
                foreach (string collingSupportSocket in Pc.ProcessorCoolingSystem.SupportedSockets)
                {
                    if (collingSupportSocket == processor.Socket)
                    {
                        flagSupportSocket = true;
                    }
                }
            }

            // Проверка Bios fuckThisShit
            bool processorSupported = true;
            foreach (string supportedProcessor in Pc.Motherboard.Bios.SupportedProcessors)
            {
                processorSupported = false;
                if (supportedProcessor == processor.Name)
                {
                    processorSupported = true;
                    Pc.Processor = processor;
                    return this;
                }
            }

            if (!processorSupported)
            {
                Pc.Result = ResultsProcessingOfPcComponents.BiosSupportError;
                return this;
            }

            if (!flagSupportSocket)
            {
                Pc.Result = ResultsProcessingOfPcComponents.SupportSocketError;
                return this;
            }

            Pc.Processor = processor;

            return this;
        }
        else if (processor is not null)
        {
            Pc.Processor = processor;
        }

        return this;
    }

    public PcBuild ProcessorCoolingSystemBuilder(ProcessorCoolingSystem? processorCoolingSystem)
    {
        if (processorCoolingSystem != null)
        {
            bool flagProcessorSupportSocket = false;
            bool flagMotherboardSupportSocket = false;
            foreach (string collingSupportSocket in processorCoolingSystem.SupportedSockets)
            {
                if (collingSupportSocket == Pc.Processor?.Socket)
                {
                    flagProcessorSupportSocket = true;
                }

                if (collingSupportSocket == Pc.Motherboard?.ProcessorSocket)
                {
                    flagMotherboardSupportSocket = true;
                }
            }

            if (Pc.Processor != null && Pc.Processor.Tdp > processorCoolingSystem.Tdp)
            {
                Pc.ProcessorCoolingSystem = processorCoolingSystem;
                Pc.Result = ResultsProcessingOfPcComponents.Warning;
                return this;
            }

            if (Pc.ComputerCase?.Dimensions.Height < processorCoolingSystem.Dimensions.Height ||
                Pc.ComputerCase?.Dimensions.Width < processorCoolingSystem.Dimensions.Width
                || Pc.ComputerCase?.Dimensions.Length < processorCoolingSystem.Dimensions.Length)
            {
                Pc.Result = ResultsProcessingOfPcComponents.DimensionsError;
                return this;
            }

            if (!flagMotherboardSupportSocket)
            {
                Pc.Result = ResultsProcessingOfPcComponents.SupportSocketError;
                return this;
            }
            else if (!flagProcessorSupportSocket)
            {
                Pc.Result = ResultsProcessingOfPcComponents.SupportSocketError;
                return this;
            }
        }

        Pc.ProcessorCoolingSystem = processorCoolingSystem;

        return this;
    }

    public PcBuild RamBuilder(Ram? ram)
    {
        if (ram != null)
        {
            if (Pc.Motherboard is not null)
            {
                if (Pc.Motherboard.NumberOfRamSlots <= Pc.Ram?.Count)
                {
                    Pc.Result = ResultsProcessingOfPcComponents.RamSlotsError;
                    return this;
                }
            }

            Pc.Ram?.Add(ram);
        }

        return this;
    }

    public PcBuild GpuBuilder(Gpu? gpu)
    {
        if (gpu != null)
        {
            if (Pc.ComputerCase is not null)
            {
                if (gpu.Height >= Pc.ComputerCase.MaximumDimensionsGpu.MaxLengthGPU ||
                    gpu.Width >= Pc.ComputerCase.MaximumDimensionsGpu.MaxWidthGPU)
                {
                    Pc.Result = ResultsProcessingOfPcComponents.DimensionsError;
                    return this;
                }
            }

            if (Pc.Gpu?.Any() == true)
            {
                if (Pc.Motherboard is not null)
                {
                    if (Pc.Gpu.Count >= Pc.Motherboard.NumberOfPciExpressLanes)
                    {
                        Pc.Result = ResultsProcessingOfPcComponents.PcieCountError;
                        return this;
                    }
                }
            }

            Pc.Gpu?.Add(gpu);
        }

        return this;
    }

    public PcBuild SsdBuilder(Ssd? ssd)
    {
        if (ssd != null)
        {
            if (Pc.Motherboard is not null)
            {
                int totalSataPorts = Pc?.Motherboard.NumberOfSataPorts ?? 0;
                int? requiredSataPorts = Pc?.Ssd?.Count + Pc?.Hdd?.Count;
                if (totalSataPorts <= requiredSataPorts)
                {
                    if (Pc != null)
                    {
                        Pc.Result = ResultsProcessingOfPcComponents.SataCountError;
                    }

                    return this;
                }
            }

            Pc?.Ssd?.Add(ssd);
        }

        return this;
    }

    public PcBuild HddBuilder(Hdd? hdd)
    {
        if (hdd != null)
        {
            if (Pc.Motherboard is not null)
            {
                int totalSataPorts = Pc?.Motherboard.NumberOfSataPorts ?? 0;
                int? requiredSataPorts = Pc?.Ssd?.Count + Pc?.Hdd?.Count;
                if (totalSataPorts <= requiredSataPorts)
                {
                    if (Pc != null)
                    {
                        Pc.Result = ResultsProcessingOfPcComponents.SataCountError;
                    }

                    return this;
                }
            }

            Pc?.Hdd?.Add(hdd);
        }

        return this;
    }

    public PcBuild ComputerCaseBuilder(ComputerCase? computerCase)
    {
        if (computerCase != null)
        {
            if (computerCase.Dimensions.Height < Pc?.ProcessorCoolingSystem?.Dimensions.Height ||
                computerCase.Dimensions.Length < Pc?.ProcessorCoolingSystem?.Dimensions.Length ||
                computerCase.Dimensions.Width < Pc?.ProcessorCoolingSystem?.Dimensions.Width)
            {
                Pc.Result = ResultsProcessingOfPcComponents.DimensionsError;
                return this;
            }

            if (Pc?.Motherboard is not null)
            {
                bool flagSupportFormFactor = false;
                ICollection<string>? supportedFormFactors = computerCase.SupportedFormFactors;
                if (supportedFormFactors != null)
                {
                    foreach (string supportedFormFactor in supportedFormFactors)
                    {
                        if (Pc.Motherboard.FormFactor == supportedFormFactor)
                        {
                            flagSupportFormFactor = true;
                        }
                    }

                    if (!flagSupportFormFactor)
                    {
                        Pc.Result = ResultsProcessingOfPcComponents.FormFactorError;
                        return this;
                    }
                }
            }

            if (Pc != null) Pc.ComputerCase = computerCase;
        }

        return this;
    }

    public PcBuild PowerUnitBuilder(Power.PowerUnit? powerUnit)
    {
        double powerConsumption = 0;
        if (Pc.Ssd?.Any() == true)
        {
            foreach (Ssd ssd in Pc.Ssd)
            {
                powerConsumption += ssd.PowerConsumption;
            }
        }

        if (Pc.Hdd?.Any() == true)
        {
            foreach (Hdd hdd in Pc.Hdd)
            {
                powerConsumption += hdd.PowerConsumption;
            }
        }

        if (Pc.Gpu?.Any() == true)
        {
            foreach (Gpu gpu in Pc.Gpu)
            {
                powerConsumption += gpu.PowerConsumption;
            }
        }

        if (Pc.Ram?.Any() == true)
        {
            foreach (Ram ram in Pc.Ram)
            {
                powerConsumption += ram.PowerConsumption;
            }
        }

        if (Pc.Processor is not null)
        {
            powerConsumption += Pc.Processor.PowerConsumption;
        }

        if (powerUnit?.PeakLoad < powerConsumption)
        {
            Pc.Result = ResultsProcessingOfPcComponents.Warning;
            return this;
        }

        if (powerUnit != null)
        {
            Pc.PowerUnit = powerUnit;
        }

        return this;
    }

    public PcBuild WiFiAdapterBuilder(WiFiAdapter? wiFiAdapter)
    {
        if (wiFiAdapter != null)
        {
            if (Pc.Motherboard != null && Pc.Motherboard.HaveWiFiModule)
            {
                Pc.Result = ResultsProcessingOfPcComponents.WiFiModuleError;
                return this;
            }

            Pc.WiFiAdapter = wiFiAdapter;
        }

        return this;
    }

    public Pc Build()
    {
        if (Pc.Result == ResultsProcessingOfPcComponents.Successful ||
            Pc.Result == ResultsProcessingOfPcComponents.Warning)
        {
            OrderFormation.SendingAnOrder(Pc);
            MessageToTheSalesDepartment.Send(Pc.Result);
        }

        return Pc;
    }
}