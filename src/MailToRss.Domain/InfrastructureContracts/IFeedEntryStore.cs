using System.Collections.Generic;
using System.Threading.Tasks;

namespace MailToRss.Domain
{
    public interface IFeedEntryStore
    {
        Task CreateFeedEntryAsync(FeedEntry entry);
        Task<IEnumerable<FeedEntry>> GetOrderedEntriesForFeedAsync(string feedId);
    }
}