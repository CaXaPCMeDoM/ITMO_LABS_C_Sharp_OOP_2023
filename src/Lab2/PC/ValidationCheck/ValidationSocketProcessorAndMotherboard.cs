using Itmo.ObjectOrientedProgramming.Lab2.Processors;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.ValidationCheck;

public static class ValidationSocketProcessorAndMotherboard
{
    public static bool SocketOfTheProcessorAndTheMotherboardAreTheSame(
        Mother.Motherboard? motherboard,
        Processor? processor)
    {
        if (motherboard is not null)
        {
            if (processor is not null)
            {
                if (motherboard.ProcessorSocket == processor.Socket)
                {
                    return true;
                }
            }
        }

        return false;
    }
}