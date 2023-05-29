using System.IO;

namespace EasySteamSockets.Classes.Payloads.BytePayloads.BinarySerialisers
{
    internal class BinarySerialiserReader : BinarySerialiser
    {
        // Fields

        private readonly BinaryReader binaryReader;

        // Constructor

        public BinarySerialiserReader(BinaryReader binaryReader)
        {
            this.binaryReader = binaryReader;
        }

        // Public Methods

        public override void Serialise(ref bool field)
        {
            field = binaryReader.ReadBoolean();
        }

        public override void Serialise(ref byte field)
        {
            field = binaryReader.ReadByte();
        }

        public override void Serialise(ref int field)
        {
            field = binaryReader.ReadInt32();
        }

        public override void Serialise(ref float field)
        {
            field = binaryReader.ReadSingle();
        }
    }
}
