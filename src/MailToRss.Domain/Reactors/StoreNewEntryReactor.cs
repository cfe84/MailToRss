using System.Threading.Tasks;

namespace MailToRss.Domain
{
    public class StoreNewEntryReactor : IReactor<MailReceivedEvent>
    {
        public bool RunOnReplay => true;
        private IFeedEntryStore entryStore;
        public StoreNewEntryReactor(IFeedEntryStore store)
        {
            this.entryStore = store;
        }

        public async Task OnAsync(MailReceivedEvent evt)
        {
            var feedId = GetFeedId(evt);
            var entry = new FeedEntry
            {
                FeedEntryId = evt.MailId,
                FeedId = feedId,
                PublishedDateTime = evt.ReceivedDate,
                TextContent = evt.TextContent,
                Title = evt.Subject
            };
            await entryStore.CreateFeedEntryAsync(entry);
        }

        private static string GetFeedId(MailReceivedEvent evt)
        {
            return evt.ReceivedOn.Split('@')[0];
        }
    }
}