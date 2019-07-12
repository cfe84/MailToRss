using System;
using System.Threading.Tasks;
using FakeItEasy;
using MailToRss.Domain;
using Xunit;

namespace MailToRss.Test
{
    public class FeedTests
    {
        [Fact]
        public async Task FeedCreatedEvent_should_storeFeed()
        {
            //Given
            var dependencies = new DependencyBundle();
            dependencies.FeedStore = A.Fake<IFeedStore>();
            var application = new Application(dependencies);
            var evt = new FeedCreatedEvent()
            {
                FeedId = "an-id",
                FeedName = "a name"
            };

            //When
            await application.EventBus.PublishEventAsync(evt);

            //Then
            A.CallTo(() => dependencies.FeedStore.CreateFeedAsync(

                A<Feed>.That.Matches(feed =>
                                feed.FeedName == evt.FeedName &&
                                feed.FeedId == evt.FeedId
                            )

            )).MustHaveHappenedOnceExactly();
        }
    }
}