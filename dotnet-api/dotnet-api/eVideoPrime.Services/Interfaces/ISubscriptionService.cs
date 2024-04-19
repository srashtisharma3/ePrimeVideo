using eVideoPrime.Core.Entities;
using eVideoPrime.Models;

namespace eVideoPrime.Services.Interfaces
{
    public interface ISubscriptionService : IService<Subscription>
    {
        Subscription GetUserSubscription(int UserId);
        IEnumerable<SubscriptionModel> GetAllUserSubscription();
    }
}
