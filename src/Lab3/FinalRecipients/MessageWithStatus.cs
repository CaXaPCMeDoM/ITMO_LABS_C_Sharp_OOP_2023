using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;

public class MessageWithStatus
{
    public Message? Message { get; set; }
    public bool IsRead { get; set; }
}