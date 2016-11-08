using NServiceBus.Extensibility;

namespace NServiceBus.FluentOptions
{
    public class MessageId : MessageOption
    {
        private readonly string messageId;

        public MessageId(string messageId)
        {
            this.messageId = messageId;
        }

        public static MessageId Set(string messageId)
        {
            return new MessageId(messageId);
        }

        internal override void Apply(ExtendableOptions options)
        {
            options.SetMessageId(messageId);
        }

        internal override bool IsApplied(ExtendableOptions options)
        {
            return options.GetMessageId() == messageId;
        }
    }
}