using System;
using NServiceBus.Extensibility;
using NUnit.Framework;

namespace NServiceBus.FluentOptions.Tests
{
    [TestFixture]
    public class MessageIdTests
    {
        [TestCaseSource(typeof(AllSendOptions))]
        public void ShouldApplyMessageId(ExtendableOptions options)
        {
            var messageId = Guid.NewGuid().ToString();

            MessageId.Set(messageId).Apply(options);

            Assert.AreEqual(options.GetMessageId(), messageId);
            Assert.IsTrue(MessageId.Set(messageId).IsApplied(options));
        }

        [TestCaseSource(typeof(AllSendOptions))]
        public void WhenNotApplied(ExtendableOptions options)
        {
            Assert.IsFalse(MessageId.Set(Guid.NewGuid().ToString()).IsApplied(options));
        }
    }
}