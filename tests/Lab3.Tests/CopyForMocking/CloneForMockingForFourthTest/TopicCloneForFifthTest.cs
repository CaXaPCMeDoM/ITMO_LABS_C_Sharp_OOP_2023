using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.CopyForMocking.CloneForMockingForFifthTest;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.CopyForMocking.CloneForMockingForFourthTest;

public class TopicCloneForFifthTest
{
    private TopicCloneForFifthTest(string name, AddresseeComponentCloneForFifthTest? addresseeComponent, Message? message)
    {
        Name = name;
        Message = message;
        AddresseeComponent = addresseeComponent;
    }

    public static INameCloneForFifthTestBuilder Builder => new TopicCloneForFifthTestBuilder();
    public string Name { get; protected set; }
    public AddresseeComponentCloneForFifthTest? AddresseeComponent { get; protected set; }
    public Message? Message { get; protected set; }

    public ResultTestForFourthTest SendMessageToTheAddressee(Message message)
    {
        if (AddresseeComponent != null)
        {
            return AddresseeComponent.AddMessage(message);
        }
        else
        {
            return ResultTestForFourthTest.None;
        }
    }

    private class TopicCloneForFifthTestBuilder : INameCloneForFifthTestBuilder, IAdressCloneForFifthTestBuilder, IMessageCloneForFifthTestBuilder
    {
        private string _name = string.Empty;
        private AddresseeComponentCloneForFifthTest? _addresseeComponent;
        private Message? _message;

        public IAdressCloneForFifthTestBuilder WithName(string name)
        {
            this._name = name;
            return this;
        }

        public IMessageCloneForFifthTestBuilder WithAdress(AddresseeComponentCloneForFifthTest addressee)
        {
            this._addresseeComponent = addressee;
            return this;
        }

        public IMessageCloneForFifthTestBuilder WithMessage(Message message)
        {
            this._message = message;
            return this;
        }

        public TopicCloneForFifthTest Build()
        {
            return new TopicCloneForFifthTest(this._name, this._addresseeComponent, this._message);
        }
    }
}