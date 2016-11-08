using NUnit.Framework;

namespace NServiceBus.FluentOptions.Tests
{
    [TestFixture]
    public class RouteTests
    {
        [Test]
        public void WhenApplyingToThisEndpoint()
        {
            var sendOptions = new SendOptions();

            Route.ToThisEndpoint.Apply(sendOptions);

            Assert.IsTrue(sendOptions.IsRoutingToThisEndpoint());
            Assert.IsTrue(Route.ToThisEndpoint.IsApplied(sendOptions));
        }

        [Test]
        public void WhenNotApplyingToThisEndpoint()
        {
            var sendOptions = new SendOptions();

            Assert.IsFalse(Route.ToThisEndpoint.IsApplied(sendOptions));
        }

        [Test]
        public void WhenApplyingToThisInstance()
        {
            var sendOptions = new SendOptions();

            Route.ToThisInstance.Apply(sendOptions);

            Assert.IsTrue(sendOptions.IsRoutingToThisInstance());
            Assert.IsTrue(Route.ToThisInstance.IsApplied(sendOptions));
        }

        [Test]
        public void WhenNotApplyingToThisInstance()
        {
            var sendOptions = new SendOptions();

            Assert.IsFalse(Route.ToThisInstance.IsApplied(sendOptions));
        }

        [Test]
        public void WhenApplyingToDestination()
        {
            var sendOptions = new SendOptions();
            string destination = "demoDestination";

            Route.ToDestination(destination).Apply(sendOptions);

            Assert.AreEqual(destination, sendOptions.GetDestination());
            Assert.IsTrue(Route.ToDestination(destination).IsApplied(sendOptions));
        }

        [Test]
        public void WhenNotApplyingToDestination()
        {
            var sendOptions = new SendOptions();

            Assert.IsFalse(Route.ToDestination("test").IsApplied(sendOptions));
        }

        [Test]
        public void WhenApplyingToSpecificInstance()
        {
            var sendOptions = new SendOptions();
            string instanceId = "demoInstanceId";

            Route.ToSpecificInstance(instanceId).Apply(sendOptions);

            Assert.AreEqual(instanceId, sendOptions.GetRouteToSpecificInstance());
            Assert.IsTrue(Route.ToSpecificInstance(instanceId).IsApplied(sendOptions));
        }

        [Test]
        public void WhenNotApplyingToSpecificInstance()
        {
            var sendOptions = new SendOptions();

            Assert.IsFalse(Route.ToSpecificInstance("test").IsApplied(sendOptions));
        }
    }
}