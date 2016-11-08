using System;
using System.Threading.Tasks;
using NServiceBus.Extensibility;
using NServiceBus.Routing;

namespace NServiceBus.FluentOptions
{
    public static class SendExtensions
    {
        public static Task Send(this IMessageSession session, object message, params SendOption[] options)
        {
            var sendOptions = new SendOptions();
            foreach (var option in options)
            {
                option.Apply(sendOptions);
            }

            return session.Send(message, sendOptions);
        }
    }

    public abstract class MessageOption : SendOption
    {
        internal abstract void Apply(ExtendableOptions options);

        internal abstract bool IsApplied(ExtendableOptions options);

        internal override void Apply(SendOptions options)
        {
            Apply(options);
        }

        internal override bool IsApplied(SendOptions options)
        {
            return IsApplied(options);
        }
    }

    public abstract class SendOption
    {
        internal abstract void Apply(SendOptions options);

        internal abstract bool IsApplied(SendOptions options);
    }
}