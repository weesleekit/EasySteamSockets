using EasySteamSockets.Classes.Payloads.BytePayloads;
using EasySteamSockets.Classes.Payloads.BytePayloads.BinarySerialisers;

namespace EasySteamSocketsExample.Payloads.BytePayloads
{
    public class PlayerPositionUpdateMessage : BytePayload
    {
        // Properties

        public int Id;

        public float X;

        public float Y;

        // Overrides

        public override void Serialise(BinarySerialiser serialiser)
        {
            serialiser.Serialise(ref Id);
            serialiser.Serialise(ref X);
            serialiser.Serialise(ref Y);
        }
    }
}
