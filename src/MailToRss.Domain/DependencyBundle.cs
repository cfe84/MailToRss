namespace MailToRss.Domain
{
    public class DependencyBundle
    {
        public IEventStore EventStore { get; set; }
        public IFeedStore FeedStore { get; set; }
        public IFeedEntryStore FeedEntryStore { get; set; }
    }
}