using System.IO;

namespace EasySteamSockets.Classes.Payloads.BytePayloads.BinarySerialisers
{
    internal class BinarySerialiserWriter : BinarySerialiser
    {
        // Fields

        private readonly BinaryWriter binaryWriter;

        // Constructor

        public BinarySerialiserWriter(BinaryWriter binaryWriter)
        {
            this.binaryWriter = binaryWriter;
        }

        // Public Methods

        public override void Serialise(ref bool field)
        {
            binaryWriter.Write(field);
        }

        public override void Serialise(ref byte field)
        {
            binaryWriter.Write(field);
        }

        public override void Serialise(ref int field)
        {
            binaryWriter.Write(field);
        }

        public override void Serialise(ref float field)
        {
            binaryWriter.Write(field);
        }
    }
}
