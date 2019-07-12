using System;

namespace MailToRss.Domain
{
    public interface IEvent
    {
        int Version { get; }
        string EventId { get; }
        string EventType { get; }
        DateTime EventDateTime { get; }
    }
}
