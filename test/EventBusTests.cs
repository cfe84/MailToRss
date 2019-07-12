using System;
using System.Threading.Tasks;
using FakeItEasy;
using MailToRss.Domain;
using Xunit;

namespace MailToRss.Test
{
    public class EventBusTests
    {
        public class FakeEventType1 : IEvent
        {

            public string EventId => throw new NotImplementedException();

            public string EventType => throw new NotImplementedException();

            public DateTime EventDateTime => throw new NotImplementedException();

            public int Version => throw new NotImplementedException();
        }

        public class FakeEventType2 : IEvent
        {

            public string EventId => throw new NotImplementedException();

            public string EventType => throw new NotImplementedException();

            public DateTime EventDateTime => throw new NotImplementedException();

            public int Version => throw new NotImplementedException();
        }

        [Fact]
        public async Task EventShouldTriggerCorrespondingReactors()
        {
            // prepare
            var reactor = A.Fake<IReactor<FakeEventType1>>();
            var eventStore = A.Fake<IEventStore>();
            var eventBus = new EventBus(eventStore);
            var event1 = new FakeEventType1();
            var event2 = new FakeEventType2();

            // execute
            eventBus.RegisterReactor(reactor);
            await eventBus.PublishEventAsync(event1);
            await eventBus.PublishEventAsync(event2);

            // assert
            A.CallTo(() => reactor.OnAsync(event1)).MustHaveHappenedOnceExactly();
            A.CallTo(() => eventStore.StoreEventAsync(event1)).MustHaveHappenedOnceExactly();
            A.CallTo(() => eventStore.StoreEventAsync(event2)).MustHaveHappenedOnceExactly();
        }
    }
}
