namespace MailToRss.Domain
{
    public class Application
    {
        public EventBus EventBus { get; private set; }
        public Application(DependencyBundle dependencies)
        {
            EventBus = new EventBus(dependencies.EventStore);
            RegisterReactors(dependencies);
        }

        private void RegisterReactors(DependencyBundle dependencies)
        {
            EventBus.RegisterReactor(new StoreNewFeedReactor(dependencies.FeedStore));
            EventBus.RegisterReactor(new StoreNewEntryReactor(dependencies.FeedEntryStore));
        }
    }
}