namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class Message
{
    private Message(int id, string heading, string body, int importanceLevel)
    {
        Heading = heading;
        Body = body;
        ImportanceLevel = importanceLevel;
        Id = id;
    }

    public static IIdBuilder Builder => new MessageBuilder();
    public int Id { get; protected set; }
    public string Heading { get; protected set; }
    public string Body { get; protected set; }
    public int ImportanceLevel { get; protected set; }

    private class MessageBuilder : IIdBuilder, IBodyBuilder, IHeadingBuilder, IImportanceLevelBuilder
    {
        private string _heading = string.Empty;
        private string _body = string.Empty;
        private int _importanceLevel;
        private int _id;

        public IImportanceLevelBuilder WithBody(string body)
        {
            this._body = body;
            return this;
        }

        public IBodyBuilder WithHeading(string heading)
        {
            this._heading = heading;
            return this;
        }

        public IImportanceLevelBuilder ImportanceLevel(int importanceLevel)
        {
            this._importanceLevel = importanceLevel;
            return this;
        }

        public IHeadingBuilder WithId(int id)
        {
            this._id = id;
            return this;
        }

        public Message Build()
        {
            return new Message(this._id, this._body, this._heading, this._importanceLevel);
        }
    }
}