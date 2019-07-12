using System.Threading.Tasks;

namespace MailToRss.Domain
{
    public interface IReactor<T> where T : IEvent
    {
        bool RunOnReplay { get; }
        Task OnAsync(T evt);
    }
}