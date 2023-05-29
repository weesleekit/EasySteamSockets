using EasySteamSockets.Classes.Payloads.BytePayloads.BinarySerialisers;
using System;
using System.Collections.Generic;
using System.IO;

namespace EasySteamSockets.Classes.Payloads.BytePayloads
{
    internal static class ByteDeserialiser
    {
        // Fields

        private static Dictionary<byte, BytePayload> PayloadCaches = null;

        // Public Methods

        /// <summary>
        /// Note: returns a cached instance of the class. There are only ever one instance of each type for purpose of receiving messages.
        /// Therefore, use it immediately and don't keep a reference to it because it will soon enough be modified the next time a message of the same type is recieved.
        /// </summary>
        internal static AbstractPayload? GetPayloadFromIntPtr(IntPtr ptr, int size, byte payloadType)
        {
            if (!PayloadCaches.TryGetValue(payloadType, out BytePayload? cachedPayload))
            {
                return null;
            }

            if (cachedPayload.Buffer == null)
            {
                return null;
            }

            if (size != cachedPayload.Buffer.Length)
            {
                return null;
            }

            System.Runtime.InteropServices.Marshal.Copy(ptr, cachedPayload.Buffer, 0, size);

            using MemoryStream stream = new MemoryStream(cachedPayload.Buffer);
            using BinaryReader reader = new BinaryReader(stream);

            _ = reader.ReadByte();

            BinarySerialiserReader binarySerialiserReader = new BinarySerialiserReader(reader);

            cachedPayload.Serialise(binarySerialiserReader);

            return cachedPayload;
        }

        internal static void CreateInstanceCachesDictionary(IEnumerable<Type> bytePayloadTypes)
        {
            PayloadCaches = new Dictionary<byte, BytePayload>();

            foreach (Type? payloadType in bytePayloadTypes)
            {
                var instance = Activator.CreateInstance(payloadType);
                if (instance is BytePayload abstractBytePayloadInstance)
                {
                    abstractBytePayloadInstance.InitialiseBuffer();

                    byte payloadTypeHeader = ByteHeaderManager.GetHeaderType(payloadType);
                    PayloadCaches.Add(payloadTypeHeader, abstractBytePayloadInstance);
                }
            }
        }
    }
}
