using NServiceBus.Extensibility;
using NUnit.Framework;

namespace NServiceBus.FluentOptions.Tests
{
    [TestFixture]
    public class DispatchTests
    {
        [TestCaseSource(typeof(AllSendOptions))]
        public void ShouldApplyImmediateDispatch(ExtendableOptions options)
        {
            Dispatch.Immediately.Apply(options);

            Assert.IsTrue(options.RequiredImmediateDispatch());
            Assert.IsTrue(Dispatch.Immediately.IsApplied(options));
        }

        [TestCaseSource(typeof(AllSendOptions))]
        public void WhenNotApplied(ExtendableOptions options)
        {
            Assert.IsFalse(options.RequiredImmediateDispatch());
            Assert.IsFalse(Dispatch.Immediately.IsApplied(options));
        }
    }
}