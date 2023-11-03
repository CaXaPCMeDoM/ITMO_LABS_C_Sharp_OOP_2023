using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;

public class User : FinalRecipent
{
    private Dictionary<int, Message> _messageCollection = new Dictionary<int, Message>();
    private Dictionary<int, bool> _messageRead = new Dictionary<int, bool>();
    public int Id { get; private set; }

    public void SetMessage(Message message)
    {
        _messageCollection.TryAdd(message.Id, message);
        _messageRead.TryAdd(message.Id, false);
    }

    public bool GetMessageStatus(int key)
    {
        return _messageRead[key];
    }

    public ResultAttemptMakrReadMessage MarkAsRead(int key)
    {
        if (_messageRead.TryGetValue(key, out _) && _messageRead[key] is not true)
        {
            _messageRead[key] = true;
            return ResultAttemptMakrReadMessage.Successful;
        }
        else
        {
            return ResultAttemptMakrReadMessage.Mistake;
        }
    }
}