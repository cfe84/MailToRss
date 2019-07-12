using System.Threading.Tasks;

namespace MailToRss.Domain
{
    public class StoreNewFeedReactor : IReactor<FeedCreatedEvent>
    {
        public bool RunOnReplay => true;
        private IFeedStore feedStore;
        public StoreNewFeedReactor(IFeedStore feedStore)
        {
            this.feedStore = feedStore;
        }

        public async Task OnAsync(FeedCreatedEvent evt)
        {
            var feed = new Feed
            {
                FeedId = evt.FeedId,
                FeedName = evt.FeedName
            };
            await feedStore.CreateFeedAsync(feed);
        }
    }
}