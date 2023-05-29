using System;
using System.Collections.Generic;
using System.Linq;

namespace EasySteamSockets.Classes.Payloads
{
    public class PayloadEventAggregator
    {
        // Static Cache From Assembly

        private static IEnumerable<Type> bytePayloadTypes = null;
        private static IEnumerable<Type> jsonPayloadTypes = null;

        public static void StoreJSONPayloadTypesDuringInitialisation(IEnumerable<Type> bytePayloadTypes, IEnumerable<Type> jsonPayloadTypes)
        {
            PayloadEventAggregator.bytePayloadTypes = bytePayloadTypes.ToArray();
            PayloadEventAggregator.jsonPayloadTypes = jsonPayloadTypes.ToArray();
        }


        // Delegates

        public delegate void PayloadArrivedEventHandler<T>(T receivedPayload) where T : AbstractPayload;


        // Fields

        private readonly Dictionary<Type, Delegate> events = new Dictionary<Type, Delegate>();


        // Constructor

        public PayloadEventAggregator()
        {
            AddPayloadsToDictionary(bytePayloadTypes);
            AddPayloadsToDictionary(jsonPayloadTypes);
        }


        // Private Methods

        private void AddPayloadsToDictionary(IEnumerable<Type> payloadTypes)
        {
            foreach (Type payloadType in payloadTypes)
            {
                events[payloadType] = null;
            }
        }


        // Public Methods

        public void Subscribe<T>(PayloadArrivedEventHandler<T> handler) where T : AbstractPayload
        {
            var type = typeof(T);
            if (events.ContainsKey(type))
            {
                events[type] = Delegate.Combine(events[type], handler);
            }
            else
            {
                events[type] = handler;
            }
        }

        public void Unsubscribe<T>(PayloadArrivedEventHandler<T> handler) where T : AbstractPayload
        {
            var type = typeof(T);
            if (events.ContainsKey(type) && events[type] != null)
            {
                events[type] = Delegate.Remove(events[type], handler);
            }
        }

        public void Notify<T>(T payload) where T : AbstractPayload
        {
            var type = payload.GetType();
            if (events.TryGetValue(type, out Delegate value))
            {
                dynamic dynamicPayload = payload;
                dynamic dynamicHandler = value;
                dynamicHandler(dynamicPayload);
            }
        }
    }
}
