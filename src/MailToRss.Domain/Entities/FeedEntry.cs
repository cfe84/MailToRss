using System;

namespace MailToRss.Domain
{
    public class FeedEntry
    {
        public string FeedEntryId { get; set; }
        public DateTime PublishedDateTime { get; set; }
        public string Title { get; set; }
        public string TextContent { get; set; }
        public string FeedId { get; set; }
    }
}