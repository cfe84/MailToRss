using System.Threading.Tasks;

namespace MailToRss.Domain
{
    public interface IEventStore
    {
        Task StoreEventAsync(IEvent evt);
    }
}