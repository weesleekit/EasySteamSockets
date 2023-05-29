using System;
using System.Collections.Generic;
using System.Linq;

namespace EasySteamSockets.Classes.Payloads.BytePayloads
{
    internal class ByteHeaderManager
    {
        // Constants

        public const byte JSONPlayoadTypeHeader = 0;

        // Fields

        private static Dictionary<Type, byte> bytePayloadTypeHeaders = null;

        // Public Methods

        public static byte GetHeaderType(Type type)
        {
            return bytePayloadTypeHeaders[type];
        }

        // Private Methods

        internal static void CreateTypesDictionary(IEnumerable<Type> bytePayloadTypes)
        {
            bytePayloadTypeHeaders = new Dictionary<Type, byte>();

            var sortedPayloadTypesByName = bytePayloadTypes.OrderBy(x => x.Name).ToList();

            byte type = JSONPlayoadTypeHeader;
            type++;

            foreach (Type? payloadType in sortedPayloadTypesByName)
            {
                bytePayloadTypeHeaders.Add(payloadType, type);
                type++;
            }
        }
    }
}
