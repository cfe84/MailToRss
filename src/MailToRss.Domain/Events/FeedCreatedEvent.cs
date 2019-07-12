using System;

namespace MailToRss.Domain
{
    public class FeedCreatedEvent : IEvent
    {
        public int Version => 1;
        public string EventId { get; set; } = Guid.NewGuid().ToString();
        public string EventType => "FeedCreatedEvent";
        public DateTime EventDateTime { get; set; }
        public string FeedName { get; set; }
        public string FeedId { get; set; }
    }
}