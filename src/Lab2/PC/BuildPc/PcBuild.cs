using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.DataStorage.HardDiskDrive;
using Itmo.ObjectOrientedProgramming.Lab2.DataStorage.SolidStateDisk;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Mother;
using Itmo.ObjectOrientedProgramming.Lab2.PC.ValidationCheck;
using Itmo.ObjectOrientedProgramming.Lab2.Processors;
using Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;
using Itmo.ObjectOrientedProgramming.Lab2.Sales;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.WiFi;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.BuildPc;

public class PcBuild
{
    private ResultsProcessingOfPcComponents _result;
    private Motherboard? _motherboard;
    private Processor? _processor;

    private ProcessorCoolingSystem? _processorCoolingSystem;

    private ICollection<Ram>? _ram = new List<Ram>();
    private ICollection<Gpu>? _gpu = new List<Gpu>();
    private ICollection<Ssd>? _ssd = new List<Ssd>();
    private ICollection<Hdd>? _hdd = new List<Hdd>();
    private ComputerCase? _computerCase;
    private Power.PowerUnit? _powerUnit;
    private WiFiAdapter? _wiFiAdapter;

    public int ResultBuild { get; protected set; }

    public PcBuild MotherboardBuilder(Mother.Motherboard? motherboard)
    {
        if (_processor is not null)
        {
            if (ValidationSocketProcessorAndMotherboard.SocketOfTheProcessorAndTheMotherboardAreTheSame(
                    motherboard,
                    _processor))
            {
            }
            else
            {
                _result = ResultsProcessingOfPcComponents.SupportSocketError;
                return this;
            }

            return this;
        }

        if (ValidationNumberPciExpressGpuCount.СoincidencesNumberPciExpressGpuCount(_motherboard, _gpu))
        {
            _result = ResultsProcessingOfPcComponents.PcieCountError;
            return this;
        }

        if (_computerCase is not null)
        {
            if (_computerCase.SupportedFormFactors?.Any() == true)
            {
                bool flagCheckFormFactor = false;
                foreach (string supportedFormFactor in _computerCase.SupportedFormFactors)
                {
                    if (supportedFormFactor == motherboard?.FormFactor)
                    {
                        flagCheckFormFactor = true;
                    }
                }

                if (!flagCheckFormFactor)
                {
                    _result = ResultsProcessingOfPcComponents.FormFactorError;
                    return this;
                }
            }
        }

        bool flagSupportSocket = true;
        if (_processorCoolingSystem is not null)
        {
            flagSupportSocket = false;
            foreach (string collingSupportSocket in _processorCoolingSystem.SupportedSockets)
            {
                if (collingSupportSocket == motherboard?.ProcessorSocket)
                {
                    flagSupportSocket = true;
                }
            }
        }

        int totalSataPorts = _motherboard?.NumberOfSataPorts ?? 0;
        int? requiredSataPorts = _ssd?.Count + _hdd?.Count;
        _result = ValidationMotherBoardSocket.MotherBoardSocket(totalSataPorts, requiredSataPorts, flagSupportSocket);
        if (totalSataPorts < requiredSataPorts)
        {
            _result = ResultsProcessingOfPcComponents.SataCountError;
            return this;
        }

        if (!flagSupportSocket)
        {
            _result = ResultsProcessingOfPcComponents.SupportSocketError;
            return this;
        }

        _motherboard = motherboard;
        return this;
    }

    public PcBuild ProcessorBuilder(Processor? processor)
    {
        if (_motherboard != null && processor != null)
        {
            if (!ValidationSocketProcessorAndMotherboard.SocketOfTheProcessorAndTheMotherboardAreTheSame(
                    _motherboard,
                    processor))
            {
                _result = ResultsProcessingOfPcComponents.SupportSocketError;
                return this;
            }

            bool flagSupportSocket = true;
            if (_processorCoolingSystem != null)
            {
                flagSupportSocket = false;
                foreach (string collingSupportSocket in _processorCoolingSystem.SupportedSockets)
                {
                    if (collingSupportSocket == processor.Socket)
                    {
                        flagSupportSocket = true;
                    }
                }
            }

            bool processorSupported = true;
            foreach (Processor supportedProcessor in _motherboard.Bios.SupportedProcessors)
            {
                processorSupported = false;
                if (supportedProcessor == processor)
                {
                    processorSupported = true;
                    _processor = processor;
                    return this;
                }
            }

            if (!processorSupported)
            {
                _result = ResultsProcessingOfPcComponents.BiosSupportError;
                return this;
            }

            if (!flagSupportSocket)
            {
                _result = ResultsProcessingOfPcComponents.SupportSocketError;
                return this;
            }

            _processor = processor;

            return this;
        }
        else if (processor is not null)
        {
            _processor = processor;
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
                if (collingSupportSocket == _processor?.Socket)
                {
                    flagProcessorSupportSocket = true;
                }

                if (collingSupportSocket == _motherboard?.ProcessorSocket)
                {
                    flagMotherboardSupportSocket = true;
                }
            }

            if (_processor != null && _processor.Tdp > processorCoolingSystem.Tdp)
            {
                _processorCoolingSystem = processorCoolingSystem;
                _result = ResultsProcessingOfPcComponents.Warning;
                return this;
            }

            if (_computerCase?.Dimensions.Height < processorCoolingSystem.Dimensions.Height ||
                _computerCase?.Dimensions.Width < processorCoolingSystem.Dimensions.Width
                || _computerCase?.Dimensions.Length < processorCoolingSystem.Dimensions.Length)
            {
                _result = ResultsProcessingOfPcComponents.DimensionsError;
                return this;
            }

            if (!flagMotherboardSupportSocket)
            {
                _result = ResultsProcessingOfPcComponents.SupportSocketError;
                return this;
            }
            else if (!flagProcessorSupportSocket)
            {
                _result = ResultsProcessingOfPcComponents.SupportSocketError;
                return this;
            }
        }

        _processorCoolingSystem = processorCoolingSystem;

        return this;
    }

    public PcBuild RamBuilder(Ram? ram)
    {
        if (ram != null)
        {
            if (_motherboard is not null)
            {
                if (_motherboard.NumberOfRamSlots <= _ram?.Count)
                {
                    _result = ResultsProcessingOfPcComponents.RamSlotsError;
                    return this;
                }
            }

            _ram?.Add(ram);
        }

        return this;
    }

    public PcBuild GpuBuilder(Gpu? gpu)
    {
        if (gpu != null)
        {
            if (_computerCase is not null)
            {
                if (gpu.Height >= _computerCase.MaximumDimensionsGpu.MaxLengthGPU ||
                    gpu.Width >= _computerCase.MaximumDimensionsGpu.MaxWidthGPU)
                {
                    _result = ResultsProcessingOfPcComponents.DimensionsError;
                    return this;
                }
            }

            if (_gpu?.Any() == true)
            {
                if (_motherboard is not null)
                {
                    if (ValidationNumberPciExpressGpuCount.СoincidencesNumberPciExpressGpuCount(_motherboard, _gpu))
                    {
                        _result = ResultsProcessingOfPcComponents.PcieCountError;
                        return this;
                    }
                }
            }

            _gpu?.Add(gpu);
        }

        return this;
    }

    public PcBuild SsdBuilder(Ssd? ssd)
    {
        if (ssd != null)
        {
            if (_motherboard is not null)
            {
                int totalSataPorts = _motherboard.NumberOfSataPorts;
                int? requiredSataPorts = _ssd?.Count + _hdd?.Count;
                if (totalSataPorts <= requiredSataPorts)
                {
                    _result = ResultsProcessingOfPcComponents.SataCountError;

                    return this;
                }
            }

            _ssd?.Add(ssd);
        }

        return this;
    }

    public PcBuild HddBuilder(Hdd? hdd)
    {
        if (hdd != null)
        {
            if (_motherboard is not null)
            {
                int totalSataPorts = _motherboard.NumberOfSataPorts;
                int? requiredSataPorts = _ssd?.Count + _hdd?.Count;
                if (totalSataPorts <= requiredSataPorts)
                {
                    _result = ResultsProcessingOfPcComponents.SataCountError;

                    return this;
                }
            }

            _hdd?.Add(hdd);
        }

        return this;
    }

    public PcBuild ComputerCaseBuilder(ComputerCase? computerCase)
    {
        if (computerCase != null)
        {
            if (computerCase.Dimensions.Height < _processorCoolingSystem?.Dimensions.Height ||
                computerCase.Dimensions.Length < _processorCoolingSystem?.Dimensions.Length ||
                computerCase.Dimensions.Width < _processorCoolingSystem?.Dimensions.Width)
            {
                _result = ResultsProcessingOfPcComponents.DimensionsError;
                return this;
            }

            if (_motherboard is not null)
            {
                bool flagSupportFormFactor = false;
                ICollection<string>? supportedFormFactors = computerCase.SupportedFormFactors;
                if (supportedFormFactors != null)
                {
                    foreach (string supportedFormFactor in supportedFormFactors)
                    {
                        if (_motherboard.FormFactor == supportedFormFactor)
                        {
                            flagSupportFormFactor = true;
                        }
                    }

                    if (!flagSupportFormFactor)
                    {
                        _result = ResultsProcessingOfPcComponents.FormFactorError;
                        return this;
                    }
                }
            }

            _computerCase = computerCase;
        }

        return this;
    }

    public PcBuild PowerUnitBuilder(Power.PowerUnit? powerUnit)
    {
        double powerConsumption = 0;
        if (_ssd?.Any() == true)
        {
            foreach (Ssd ssd in _ssd)
            {
                powerConsumption += ssd.PowerConsumption;
            }
        }

        if (_hdd?.Any() == true)
        {
            foreach (Hdd hdd in _hdd)
            {
                powerConsumption += hdd.PowerConsumption;
            }
        }

        if (_gpu?.Any() == true)
        {
            foreach (Gpu gpu in _gpu)
            {
                powerConsumption += gpu.PowerConsumption;
            }
        }

        if (_ram?.Any() == true)
        {
            foreach (Ram ram in _ram)
            {
                powerConsumption += ram.PowerConsumption;
            }
        }

        if (_processor is not null)
        {
            powerConsumption += _processor.PowerConsumption;
        }

        if (powerUnit?.PeakLoad < powerConsumption)
        {
            _result = ResultsProcessingOfPcComponents.Warning;
            return this;
        }

        if (powerUnit != null)
        {
            _powerUnit = powerUnit;
        }

        return this;
    }

    public PcBuild WiFiAdapterBuilder(WiFiAdapter? wiFiAdapter)
    {
        if (wiFiAdapter != null)
        {
            if (_motherboard != null && _motherboard.HaveWiFiModule)
            {
                _result = ResultsProcessingOfPcComponents.WiFiModuleError;
                return this;
            }

            _wiFiAdapter = wiFiAdapter;
        }

        return this;
    }

    public Pc Build()
    {
        var pc = new Pc(
            _result,
            _motherboard,
            _processor,
            _processorCoolingSystem,
            _ram,
            _gpu,
            _ssd,
            _hdd,
            _computerCase,
            _powerUnit,
            _wiFiAdapter);
        if (_result == ResultsProcessingOfPcComponents.Successful ||
            _result == ResultsProcessingOfPcComponents.Warning)
        {
            OrderFormation.SendingAnOrder(pc);
            MessageToTheSalesDepartment.Send(pc.Result);
        }

        return pc;
    }
}