using eVideoPrime.Core.Entities;
using eVideoPrime.Models;

namespace eVideoPrime.Core.Interfaces
{
    public interface ISubscriptionRepository : IRepository<Subscription>
    {
        Subscription GetUserSubscription(int UserId);
        IEnumerable<SubscriptionModel> GetAllUserSubscription();
    }
}
