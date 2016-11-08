# NServiceBus.FluentOptions
Provides an alternative API to specify options for outgoing messages.

## Usage

Instead of:

```
var sendOptions = new SendOptions();
sendOptions.SetMessageId("123");
sendOptions.SetHeader("key", "value");
sendOptions.RequireImmediateDispatch();
sendOptions.RouteToThisEndpoint();
await session.Send(new MyMessage(), sendOptions);
```

Write:

```
await session.Send(new MyMessage(),
    MessageId.Set("123"),
    Header.Add("key", "value"), 
    Dispatch.Immediately, 
    Route.ToThisEndpoint);
```
