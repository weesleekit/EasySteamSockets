using EasySteamSockets.Classes;
using EasySteamSockets.Classes.Payloads;
using Steamworks;
using Steamworks.Data;
using System;

namespace EasySteamSockets
{
    public class EasySocketsServer : SocketManager
    {
        // Properties

        public ILogger? Logger { get; set; }

        public PayloadEventAggregator Events = new PayloadEventAggregator();


        // Public Methods

        public Result SendMessageToAll(AbstractPayload abstractPayload, SendType sendType)
        {
            byte[] bytes = abstractPayload.GetByteArray();

            Result output = Result.OK;

            foreach (Connection connection in Connected)
            {
                Result resultForThisConnection = connection.SendMessage(bytes, sendType);
                if (resultForThisConnection != Result.OK)
                {
                    output = resultForThisConnection;
                }
            }

            return output;
        }


        // Overrides

        public override void OnConnecting(Connection connection, ConnectionInfo data)
        {
            if (!Initialiser.Initialised)
            {
                throw new Exception("Initialiser.Initialise must be called first");
            }

            base.OnConnecting(connection, data);

            Logger?.Log($"Server OnConnecting, {data.Identity.SteamId.AccountId}");

            connection.Accept();
        }

        public override void OnConnected(Connection connection, ConnectionInfo data)
        {
            base.OnConnected(connection, data);

            Logger?.Log($"Server OnConnected, {data.Identity.SteamId.AccountId}");
        }

        public override void OnDisconnected(Connection connection, ConnectionInfo data)
        {
            base.OnDisconnected(connection, data);

            Logger?.Log($"Server OnDisconnected, {data.Identity.SteamId.AccountId}");
        }

        public override void OnMessage(Connection connection, NetIdentity identity, IntPtr data, int size, long messageNum, long recvTime, int channel)
        {
            base.OnMessage(connection, identity, data, size, messageNum, recvTime, channel);

            AbstractPayload? message = Deserialiser.IntPtrToPayload(data, size);

            if (message == null)
            {
                Logger?.Log($"Server OnMessage, failed to deserialise message from SteamID: {identity.SteamId.AccountId}");
                return;
            }

            Logger?.Log($"Server OnMessage, message type: {message.GetType().Name}");

            Events.Notify(message);
        }
    }
}
