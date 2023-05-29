using EasySteamSockets.Classes.Payloads.BytePayloads;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace EasySteamSockets.Classes.Payloads.JSONPayloads
{
    public abstract class JSONPayload : AbstractPayload
    {
        // Public Methods

        public override byte[] GetByteArray()
        {
            using MemoryStream stream = new MemoryStream();

            // Write the initial header
            stream.WriteByte(ByteHeaderManager.JSONPlayoadTypeHeader);

            // Write the second header that describes the class to deseralise into
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                // Write the second header that describes the class to deseralise into
                string derivedClassName = GetType().Name;
                writer.Write(derivedClassName);

                // Add delimiter
                writer.Write('\n');

                // Write the serialised JSON
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, this);
                writer.Flush();
            }

            return stream.ToArray();
        }
    }
}