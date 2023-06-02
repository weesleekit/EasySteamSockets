using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace EasySteamSockets.Classes.Payloads.JSONPayloads
{
    internal static class JSONDeserialiser
    {
        // Constants

        private static Dictionary<string, Type> JSONPayloadDictionary = new Dictionary<string, Type>();


        // Static Public Methods

        internal static AbstractPayload? GetPayloadFromIntPtr(IntPtr ptr, int size)
        {
            byte[] byteArray = new byte[size];
            Marshal.Copy(ptr, byteArray, 0, size);

            using MemoryStream stream = new MemoryStream(byteArray);

            using StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            {
                // Read the initial header
                stream.Seek(0, SeekOrigin.Begin);
                byte header = (byte)stream.ReadByte();

                string? className = reader.ReadLine();

                if (className == null)
                {
                    return null;
                }

                // Get the type
                if (!JSONPayloadDictionary.TryGetValue(className, out Type? derivedType))
                {
                    return null;
                }

                if (derivedType == null)
                {
                    return null;
                }

                // Get the JSON
                string? json = reader.ReadLine();

                if (json == null)
                {
                    return null;
                }

                // Deserialize the JSON
                var output = JsonConvert.DeserializeObject(json, derivedType);

                if (output == null)
                {
                    return null;
                }


                return (JSONPayload)output;
            }
        }


        // Private Methods

        internal static void CreateTypesDictionary(IEnumerable<Type> jsonPayloadTypes)
        {
            JSONPayloadDictionary = new Dictionary<string, Type>();

            foreach (Type? payloadType in jsonPayloadTypes)
            {
                JSONPayloadDictionary[payloadType.Name] = payloadType;
            }
        }
    }
}
