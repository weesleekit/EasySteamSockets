using EasySteamSockets.Classes;
using EasySteamSockets.Classes.Payloads;
using Steamworks;
using Steamworks.Data;
using System;

namespace EasySteamSockets
{
    public class EasySocketsClient : ConnectionManager
    {
        // Properties

        public ILogger? Logger { get; set; }

        public ClientPayloadEventAggregator Events = new ClientPayloadEventAggregator();


        // Public Methods

        public Result SendMessage(AbstractPayload abstractPayload, SendType sendType)
        {
            byte[] bytes = abstractPayload.GetByteArray();

            return Connection.SendMessage(bytes, sendType);
        }


        // Overrides

        public override void OnConnecting(ConnectionInfo info)
        {
            if (!Initialiser.Initialised)
            {
                throw new Exception("Initialiser.Initialise must be called first");
            }

            base.OnConnecting(info);
            Logger?.Log($"Client OnConnecting, {info.Identity}");

        }

        public override void OnConnected(ConnectionInfo info)
        {
            base.OnConnected(info);
            Logger?.Log($"Client OnConnected, {info.Identity}");
        }

        public override void OnDisconnected(ConnectionInfo info)
        {
            base.OnDisconnected(info);

            Logger?.Log($"Client OnDisconnected, {info.Identity}");
        }

        public override void OnMessage(IntPtr data, int size, long messageNum, long recvTime, int channel)
        {
            base.OnMessage(data, size, messageNum, recvTime, channel);

            AbstractPayload? message = Deserialiser.IntPtrToPayload(data, size);

            if (message == null)
            {
                Logger?.Log($"Client OnMessage, failed to deserialise message from server");
                return;
            }

            Logger?.Log($"Client OnMessage, message type: {message.GetType().Name}");

            Events.Notify(message);
        }
    }
}
