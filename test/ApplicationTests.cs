using System.Threading.Tasks;
using FakeItEasy;
using MailToRss.Domain;
using Xunit;

namespace MailToRss.Test
{
    public class ApplicationTests
    {
        [Fact]
        public async Task Events_should_beStoredInEventStore()
        {
            //Given
            var dependencies = new DependencyBundle();
            dependencies.EventStore = A.Fake<IEventStore>();
            var event1 = A.Fake<IEvent>();
            var application = new Application(dependencies);

            //When
            await application.EventBus.PublishEventAsync(event1);

            //Then
            A.CallTo(() => dependencies.EventStore.StoreEventAsync(event1)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task Events_should_notBeStoredIfEventStoreIsNull()
        {
            //Given
            var dependencies = new DependencyBundle();
            var event1 = A.Fake<IEvent>();
            var application = new Application(dependencies);

            //When
            await application.EventBus.PublishEventAsync(event1);

            //Then
            Assert.Null(dependencies.EventStore);
            // Just check it didn't throw
        }
    }
}