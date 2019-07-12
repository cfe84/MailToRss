using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailToRss.Domain
{
    public class EventBus
    {
        private IEventStore eventStore;
        public EventBus(IEventStore eventStore)
        {
            this.eventStore = eventStore;
        }

        public Dictionary<Type, List<Func<IEvent, Task>>> reactorCallbacks = new Dictionary<Type, List<Func<IEvent, Task>>>();
        public void RegisterReactor<T>(IReactor<T> reactor) where T : IEvent
        {
            Type eventType = typeof(T);
            if (!reactorCallbacks.ContainsKey(eventType))
                reactorCallbacks.Add(eventType, new List<Func<IEvent, Task>>());
            Func<IEvent, Task> delegateFunction = async (IEvent evt) => await reactor.OnAsync((T)evt);
            reactorCallbacks[eventType].Add(delegateFunction);
        }

        public async Task PublishEventAsync(IEvent evt)
        {
            Type eventType = evt.GetType();
            if (eventStore != null)
                await eventStore.StoreEventAsync(evt);
            if (reactorCallbacks.ContainsKey(eventType))
            {
                var callbacksForThatEventType = reactorCallbacks[eventType];
                Task.WaitAll(callbacksForThatEventType
                    .Select(callback => callback(evt))
                    .ToArray());
            }
        }
    }
}