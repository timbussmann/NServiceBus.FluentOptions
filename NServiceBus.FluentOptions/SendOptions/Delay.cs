using System;

namespace NServiceBus.FluentOptions
{
    public class Delay
    {
        public static DelayUntil Until(DateTimeOffset deliveryDate)
        {
            return new DelayUntil(deliveryDate);
        }

        public static DelayBy By(TimeSpan deliveryDelay)
        {
            return new DelayBy(deliveryDelay);
        }

        public class DelayUntil : SendOption
        {
            private readonly DateTimeOffset deliveryDate;

            internal DelayUntil(DateTimeOffset deliveryDate)
            {
                this.deliveryDate = deliveryDate;
            }

            internal override void Apply(SendOptions options)
            {
                options.DoNotDeliverBefore(deliveryDate);
            }

            internal override bool IsApplied(SendOptions options)
            {
                return options.GetDeliveryDate() == deliveryDate;
            }
        }

        public class DelayBy : SendOption
        {
            private readonly TimeSpan deliveryDelay;

            internal DelayBy(TimeSpan deliveryDelay)
            {
                this.deliveryDelay = deliveryDelay;
            }

            internal override void Apply(SendOptions options)
            {
                options.DelayDeliveryWith(deliveryDelay);
            }

            internal override bool IsApplied(SendOptions options)
            {
                return options.GetDeliveryDelay() == deliveryDelay;
            }
        }
    }
}