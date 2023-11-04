namespace Itmo.ObjectOrientedProgramming.Lab2.Enums;

public enum ResultsProcessingOfPcComponents : int
{
    None,
    Successful = 1,
    DisclaimerOfWarranty = 2,
    PcieCountError = 3,
    SataCountError = 4,
    FormFactorError = 5,
    SupportSocketError = 6,
    BiosSupportError = 7,
    Warning = 8,
    DimensionsError = 9,
    PowerInsufficient = 10,
    WiFiModuleError = 11,
    RamSlotsError = 12,
}