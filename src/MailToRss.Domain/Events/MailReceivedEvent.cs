using System;
using System.Collections.Generic;

namespace MailToRss.Domain
{
    public class MailReceivedEvent : IEvent
    {
        public string From { get; set; }
        public string ReceivedOn { get; set; }
        public string MailId { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string TextContent { get; set; }
        public Dictionary<string, string> Attachments { get; set; }
        public int Version => 1;
        public string EventId { get; set; } = Guid.NewGuid().ToString();
        public string EventType => "MailReceivedEvent";
        public DateTime EventDateTime => throw new NotImplementedException();
    }
}