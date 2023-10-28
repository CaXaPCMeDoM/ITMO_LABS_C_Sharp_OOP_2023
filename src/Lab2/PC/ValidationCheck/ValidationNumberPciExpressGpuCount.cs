using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Mother;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.ValidationCheck;

public static class ValidationNumberPciExpressGpuCount
{
    public static bool СoincidencesNumberPciExpressGpuCount(Motherboard? motherboard, ICollection<Gpu>? gpu)
    {
        if (motherboard?.NumberOfPciExpressLanes <= gpu?.Count)
        {
            return true;
        }

        return false;
    }
}