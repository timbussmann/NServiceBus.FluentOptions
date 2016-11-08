using System;
using NUnit.Framework;

namespace NServiceBus.FluentOptions.Tests
{
    [TestFixture]
    public class DelayTests
    {
        [Test]
        public void WhenApplyingDelayDate()
        {
            var sendOptions = new SendOptions();
            var deliveryDate = DateTimeOffset.Now;

            Delay.Until(deliveryDate).Apply(sendOptions);

            Assert.AreEqual(deliveryDate, sendOptions.GetDeliveryDate());
            Assert.IsTrue(Delay.Until(deliveryDate).IsApplied(sendOptions));
        }

        [Test]
        public void WhenNotApplyingDelayDate()
        {
            var sendOptions = new SendOptions();

            Assert.IsFalse(Delay.Until(DateTimeOffset.Now).IsApplied(sendOptions));
        }

        [Test]
        public void WhenApplyingDelayTimespan()
        {
            var sendOptions = new SendOptions();
            var deliveryDelay = TimeSpan.FromMinutes(42);

            Delay.By(deliveryDelay).Apply(sendOptions);

            Assert.AreEqual(deliveryDelay, sendOptions.GetDeliveryDelay());
            Assert.IsTrue(Delay.By(deliveryDelay).IsApplied(sendOptions));
        }

        [Test]
        public void WhenNotApplyingDeliveryDelay()
        {
            var sendOptions = new SendOptions();

            Assert.IsFalse(Delay.By(TimeSpan.FromHours(5)).IsApplied(sendOptions));
        }
    }
}