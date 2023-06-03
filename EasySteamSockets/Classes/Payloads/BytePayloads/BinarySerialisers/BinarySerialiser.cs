namespace EasySteamSockets.Classes.Payloads.BytePayloads.BinarySerialisers
{
    public abstract class BinarySerialiser
    {
        public abstract void Serialise(ref bool field);
        public abstract void Serialise(ref byte field);
        public abstract void Serialise(ref int field);
        public abstract void Serialise(ref uint field);
        public abstract void Serialise(ref float field);
    }
}
