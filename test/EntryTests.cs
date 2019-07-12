using System;
using System.Threading.Tasks;
using FakeItEasy;
using MailToRss.Domain;
using Xunit;

namespace MailToRss.Test
{
    public class EntryTests
    {
        [Fact]
        public async Task MailReceived_should_storeFeedEntry()
        {
            //Given
            var dependencies = new DependencyBundle();
            dependencies.FeedEntryStore = A.Fake<IFeedEntryStore>();
            var application = new Application(dependencies);
            var id = "this-is-an-id";
            var evt = new MailReceivedEvent()
            {
                ReceivedOn = id + "@something.com",
                MailId = "this-is-a-mail-id",
                Subject = "this is the subject",
                TextContent = "bla",
                ReceivedDate = new DateTime(2018, 12, 13, 1, 2, 3)
            };

            //When
            await application.EventBus.PublishEventAsync(evt);

            //Then
            A.CallTo(() => dependencies.FeedEntryStore.CreateFeedEntryAsync(

                A<FeedEntry>.That.Matches(entry =>
                    entry.FeedId == id &&
                    entry.FeedEntryId == evt.MailId &&
                    entry.PublishedDateTime == evt.ReceivedDate &&
                    entry.TextContent == evt.TextContent &&
                    entry.Title == evt.Subject
                )

            )).MustHaveHappenedOnceExactly();
        }
    }
}