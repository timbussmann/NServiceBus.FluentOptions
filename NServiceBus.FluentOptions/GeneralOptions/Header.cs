using NServiceBus.Extensibility;

namespace NServiceBus.FluentOptions
{
    public class Header : MessageOption
    {
        private readonly string key;
        private readonly string value;

        public Header(string key, string value)
        {
            this.key = key;
            this.value = value;
        }

        public static Header Add(string key, string value)
        {
            return new Header(key, value);
        }

        internal override void Apply(ExtendableOptions options)
        {
            options.SetHeader(key, value);
        }

        internal override bool IsApplied(ExtendableOptions options)
        {
            string headerValue;
            if (options.GetHeaders().TryGetValue(key, out headerValue))
            {
                return headerValue == value;
            }

            return false;
        }
    }
}