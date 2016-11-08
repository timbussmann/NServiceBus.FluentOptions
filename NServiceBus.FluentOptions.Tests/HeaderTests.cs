using System.Collections.Generic;
using NServiceBus.Extensibility;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace NServiceBus.FluentOptions.Tests
{
    [TestFixture]
    public class HeaderTests
    {
        [TestCaseSource(typeof(AllSendOptions))]
        public void ShouldAddHeader(ExtendableOptions options)
        {
            var header = Header.Add("key", "value");
            header.Apply(options);

            Assert.That(options.GetHeaders(), Contains.Item(new KeyValuePair<string, string>("key", "value")));
        }

        [TestCaseSource(typeof(AllSendOptions))]
        public void ShouldAllowCtorUsage(ExtendableOptions options)
        {
            var header = new Header("key", "value");
            header.Apply(options);

            Assert.That(options.GetHeaders(), Contains.Item(new KeyValuePair<string, string>("key", "value")));
        }

        [TestCaseSource(typeof(AllSendOptions))]
        public void ShouldAddMultipleHeaders(ExtendableOptions options)
        {
            var header1 = Header.Add("key1", "value1");
            var header2 = Header.Add("key2", "value2");
            var header3 = Header.Add("key3", "value3");
            header1.Apply(options);
            header2.Apply(options);
            header3.Apply(options);

            Assert.That(options.GetHeaders(), Contains.Item(new KeyValuePair<string, string>("key1", "value1")));
            Assert.That(options.GetHeaders(), Contains.Item(new KeyValuePair<string, string>("key2", "value2")));
            Assert.That(options.GetHeaders(), Contains.Item(new KeyValuePair<string, string>("key3", "value3")));
        }

        [TestCaseSource(typeof(AllSendOptions))]
        public void ShouldBeVerifyable(ExtendableOptions options)
        {
            var header1 = Header.Add("key1", "value1");
            var header2 = Header.Add("key2", "value2");

            // only apply header1
            header1.Apply(options);

            Assert.IsTrue(header1.IsApplied(options));
            Assert.IsFalse(header2.IsApplied(options));
        }
    }
}