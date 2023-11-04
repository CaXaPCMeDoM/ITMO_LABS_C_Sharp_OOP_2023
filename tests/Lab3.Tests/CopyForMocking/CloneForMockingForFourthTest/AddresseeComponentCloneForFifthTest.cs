using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.CopyForMocking.CloneForMockingForFifthTest;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.CopyForMocking.Mocking;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.CopyForMocking.CloneForMockingForFourthTest;

public abstract class AddresseeComponentCloneForFifthTest
{
    private ImportanceLevel _importanceLevel;

    protected AddresseeComponentCloneForFifthTest(ImportanceLevel importanceLevel)
    {
        _importanceLevel = importanceLevel;
    }

    public IMocking MockingLogger { get; private set; } = new Mocking.Mocking();

    public ResultTestForFourthTest AddMessage(Message message)
    {
        if (message.ImportanceLevel == _importanceLevel)
        {
            ReceiveMessage(message);
            return ResultTestForFourthTest.Successful;
        }
        else
        {
            return ResultTestForFourthTest.Mistake;
        }
    }

    public abstract void ReceiveMessage(Message message);
}