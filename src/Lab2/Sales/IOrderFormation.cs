using Itmo.ObjectOrientedProgramming.Lab2.PC.BuildPc;

namespace Itmo.ObjectOrientedProgramming.Lab2.Sales;

public interface IOrderFormation
{
    static abstract void SendingAnOrder(Pc pc);
}