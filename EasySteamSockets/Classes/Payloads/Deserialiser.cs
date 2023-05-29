using EasySteamSockets.Classes.Payloads.BytePayloads;
using EasySteamSockets.Classes.Payloads.JSONPayloads;
using System;
using System.Runtime.InteropServices;

namespace EasySteamSockets.Classes.Payloads
{
    public static class Deserialiser
    {
        public static AbstractPayload? IntPtrToPayload(IntPtr ptr, int size)
        {
            byte payloadTypeHeader = Marshal.ReadByte(ptr);

            if (payloadTypeHeader == ByteHeaderManager.JSONPlayoadTypeHeader)
            {
                return JSONDeserialiser.GetPayloadFromIntPtr(ptr, size);
            }
            else
            {
                return ByteDeserialiser.GetPayloadFromIntPtr(ptr, size, payloadTypeHeader);
            }
        }
    }
}
