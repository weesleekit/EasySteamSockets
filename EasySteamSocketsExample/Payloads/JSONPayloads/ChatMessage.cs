using EasySteamSockets.Classes.Payloads.JSONPayloads;

namespace EasySteamSocketsExample.Payloads.JSONPayloads
{
    public class ChatMessage : JSONPayload
    {
        public string Message { get; set; }

        public int ColourARGB { get; set; }
    }
}
