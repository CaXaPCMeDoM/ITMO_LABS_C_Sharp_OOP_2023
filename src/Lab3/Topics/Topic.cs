using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic
{
    private Topic(string name, AddresseeComponent? addresseeComponent, Message? message)
    {
        Name = name;
        Message = message;
        AddresseeComponent = addresseeComponent;
    }

    public static INameBuilder Builder => new TopicBuilder();
    public string Name { get; protected set; }
    public AddresseeComponent? AddresseeComponent { get; protected set; }
    public Message? Message { get; protected set; }

    public void SendMessageToTheAddressee(Message message)
    {
        AddresseeComponent?.AddMessage(message);
    }

    private class TopicBuilder : INameBuilder, IAdressBuilder, IMessageBuilder
    {
        private string _name = string.Empty;
        private AddresseeComponent? _addresseeComponent;
        private Message? _message;

        public IAdressBuilder WithName(string name)
        {
            this._name = name;
            return this;
        }

        public IMessageBuilder WithAdress(AddresseeComponent addressee)
        {
            this._addresseeComponent = addressee;
            return this;
        }

        public IMessageBuilder WithMessage(Message message)
        {
            this._message = message;
            return this;
        }

        public Topic Build()
        {
            return new Topic(this._name, this._addresseeComponent, this._message);
        }
    }
}