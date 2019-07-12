using System.Collections.Generic;
using System.Threading.Tasks;

namespace MailToRss.Domain
{
    public interface IFeedStore
    {
        Task CreateFeedAsync(Feed feed);
        Task UpdateFeedAsync(Feed feed);
        Task<IEnumerable<Feed>> ListFeedsAsync();
        Task<Feed> GetFeedAsync(string FeedId);
    }
}