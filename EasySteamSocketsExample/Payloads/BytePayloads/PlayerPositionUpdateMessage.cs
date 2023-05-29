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

        public override void Serialise(BinarySerialiser writer)
        {
            writer.Serialise(ref Id);
            writer.Serialise(ref X);
            writer.Serialise(ref Y);
        }
    }
}
