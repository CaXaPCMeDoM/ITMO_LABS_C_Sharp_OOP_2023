using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;

public class User
{
    private Dictionary<int, MessageWithStatus> _messageCollectionWithStatus = new Dictionary<int, MessageWithStatus>();
    public int Id { get; private set; }

    public void SetMessage(Message message)
    {
        _messageCollectionWithStatus.TryAdd(message.Id, new MessageWithStatus { Message = message, IsRead = false });
    }

    public bool GetMessageStatus(int key)
    {
        if (_messageCollectionWithStatus.TryGetValue(key, out MessageWithStatus? messageWithStatus))
        {
            return messageWithStatus.IsRead;
        }

        return false;
    }

    public ResultAttemptMakrReadMessage MarkAsRead(int key)
    {
        if (_messageCollectionWithStatus.TryGetValue(key, out MessageWithStatus? messageWithStatus) && !messageWithStatus.IsRead)
        {
            messageWithStatus.IsRead = true;
            return ResultAttemptMakrReadMessage.Successful;
        }
        else
        {
            return ResultAttemptMakrReadMessage.Mistake;
        }
    }
}