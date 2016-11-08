using System.Collections;

namespace NServiceBus.FluentOptions.Tests
{
    public class AllSendOptions : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new SendOptions();
            yield return new PublishOptions();
            yield return new ReplyOptions();
        }
    }
}