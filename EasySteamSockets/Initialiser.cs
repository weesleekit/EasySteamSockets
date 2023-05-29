using EasySteamSockets.Classes.Payloads;
using EasySteamSockets.Classes.Payloads.BytePayloads;
using EasySteamSockets.Classes.Payloads.JSONPayloads;
using System.Linq;
using System.Reflection;

namespace EasySteamSockets
{
    public static class Initialiser
    {
        public static bool Initialised { get; private set; } = false;

        public static void Initialise(Assembly assembly)
        {
            var bytePayloadTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(BytePayload)) && !t.IsAbstract);

            ByteHeaderManager.CreateTypesDictionary(bytePayloadTypes);

            ByteDeserialiser.CreateInstanceCachesDictionary(bytePayloadTypes);


            var jsonPayloadTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(JSONPayload)) && !t.IsAbstract);

            JSONDeserialiser.CreateTypesDictionary(jsonPayloadTypes);


            PayloadEventAggregator.StoreJSONPayloadTypesDuringInitialisation(bytePayloadTypes, jsonPayloadTypes);

            Initialised = true;
        }
    }
}
