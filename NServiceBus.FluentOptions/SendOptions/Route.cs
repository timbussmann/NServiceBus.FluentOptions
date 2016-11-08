using System;

namespace NServiceBus.FluentOptions
{
    public class Route : SendOption
    {
        private readonly Action<SendOptions> configuration;
        private readonly Func<SendOptions, bool> verify;

        private Route(Action<SendOptions> configuration, Func<SendOptions, bool> verify)
        {
            this.configuration = configuration;
            this.verify = verify;
        }

        public static Route ToThisEndpoint { get; } = new Route(o => o.RouteToThisEndpoint(), o => o.IsRoutingToThisEndpoint());

        public static Route ToThisInstance { get; } = new Route(o => o.RouteToThisInstance(), o => o.IsRoutingToThisInstance());

        public static Route ToSpecificInstance(string instanceId)
        {
            return new Route(o => o.RouteToSpecificInstance(instanceId), o => o.GetRouteToSpecificInstance() == instanceId);
        }

        public static Route ToDestination(string destination)
        {
            return new Route(o => o.SetDestination(destination), o => o.GetDestination() == destination);
        }

        internal override void Apply(SendOptions options)
        {
            configuration(options);
        }

        internal override bool IsApplied(SendOptions options)
        {
            return verify(options);
        }
    }
}