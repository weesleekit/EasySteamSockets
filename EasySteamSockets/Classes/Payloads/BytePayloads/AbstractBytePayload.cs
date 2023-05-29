using EasySteamSockets.Classes.Payloads.BytePayloads.BinarySerialisers;
using System.IO;

namespace EasySteamSockets.Classes.Payloads.BytePayloads
{
    public abstract class BytePayload : AbstractPayload
    {
        // Constants

        private const int headerSize = sizeof(byte);


        // Fields

        public byte[]? Buffer { get; private set; }


        // Abstract Methods

        public abstract void Serialise(BinarySerialiser writer);


        // Public Methods

        public override byte[] GetByteArray()
        {
            if (Buffer == null)
            {
                Buffer = CreateNewBuffer();
            }
            else
            {
                UpdateBuffer();
            }

            return Buffer;
        }

        internal void InitialiseBuffer()
        {
            Buffer = CreateNewBuffer();
        }

        // Private Methods

        private byte[] CreateNewBuffer()
        {
            using MemoryStream stream = new MemoryStream();
            using BinaryWriter writer = new BinaryWriter(stream);

            writer.Write(ByteHeaderManager.GetHeaderType(GetType()));

            BinarySerialiserWriter binarySerialiserWriter = new BinarySerialiserWriter(writer);

            Serialise(binarySerialiserWriter);

            writer.Flush();

            return stream.ToArray();
        }

        private void UpdateBuffer()
        {
            using MemoryStream stream = new MemoryStream(Buffer);
            using BinaryWriter writer = new BinaryWriter(stream);

            // Seek to the appropriate position in the stream
            writer.Seek(headerSize, SeekOrigin.Begin);

            BinarySerialiserWriter binarySerialiserWriter = new BinarySerialiserWriter(writer);

            Serialise(binarySerialiserWriter);

            writer.Flush();
        }
    }
}
