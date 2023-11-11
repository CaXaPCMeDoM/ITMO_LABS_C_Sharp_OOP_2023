using Itmo.ObjectOrientedProgramming.Lab3.Addressees;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public interface IAdressBuilder
{
    IMessageBuilder WithAdress(AddresseeComponent addresseeComponent);
}