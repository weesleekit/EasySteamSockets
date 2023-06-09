# EasySteamSockets' Purpose

EasySteamSockets is a library that builds on the Steam socket server networking provided in [Facepunch.Steamworks](https://github.com/Facepunch/Facepunch.Steamworks). The sample project is a lightweight WinForm app to demonstrate sending two types of payloads:

| Payload Type | Example | Purpose |
|-|-|-|
| "JSON" | [ChatMessage](https://github.com/weesleekit/EasySteamSockets/blob/main/EasySteamSocketsExample/Payloads/JSONPayloads/ChatMessage.cs) | "JSON" payloads that can easily support complex objects without the developer having to worry about how it is encoded |
| "Byte" | [PlayerPositionMessage](https://github.com/weesleekit/EasySteamSockets/blob/main/EasySteamSocketsExample/Payloads/BytePayloads/PlayerPositionUpdateMessage.cs) | "Byte" payloads that the developer has more control over how to read and write the bytes |

![Networking Milestone](https://github.com/weesleekit/EasySteamSockets/assets/42421376/64c55f95-56a0-4897-a084-20cfcbe736fb)

# How to use

## Initial Setup

Note: that the library needs a one-time initialisation by providing it the assembly that has the payloads defined in it.

```
{
    EasySteamSockets.Initialiser.Initialise(Assembly.GetExecutingAssembly());
}
```

## Sending a message

See [FormClient.cs](https://github.com/weesleekit/EasySteamSockets/blob/main/EasySteamSocketsExample/Forms/FormClient.cs) for a fully worked example. The code snippets below are taken from this class.

Note that for byte type payloads that might be sent often, it is possible to re-use messages.

```
{
    PlayerPositionUpdateMessage playerPositionUpdateMessage = new()
    {
        Id = 123,
        X = x,
        Y = y,
    };

    client?.SendMessage(playerPositionUpdateMessage, SendType.Reliable);
}
```

## Receiving a message

Periodically call Receive on the client or server as appropriate e.g.
```
    client?.Receive();
    server?.Receive();
```
Note that the received messages are reused the next time the same type is received therefore don't keep a reference to it.

```
{   
    client?.Events.Subscribe<ChatMessage>(ChatMessageReceived);
}

private void ChatMessageReceived(ChatMessage chatMessage)
{
    // Consume chatMessage here.
}

```
