using eVideoPrime.Core.Entities;
using eVideoPrime.Core.Interfaces;
using eVideoPrime.Models;
using Microsoft.EntityFrameworkCore;

namespace eVideoPrime.Core.Implementations
{
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        private AppDbContext dbContext
        {
            get
            {
                return _dbContext as AppDbContext;
            }
        }
        public SubscriptionRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public Subscription GetUserSubscription(int UserId)
        {
            return dbContext.Subscriptions.Where(c => c.UserId == UserId).FirstOrDefault();
        }
        public IEnumerable<SubscriptionModel> GetAllUserSubscription()
        {
            IEnumerable<SubscriptionModel> subs = (from s in dbContext.Subscriptions
                                              join ur in dbContext.Users on s.UserId equals ur.Id
                                              join p in dbContext.Plans on s.PlanId equals p.Id
                                              select new SubscriptionModel
                                              {
                                                  Id = s.Id,
                                                  UserName= ur.Name,
                                                  UserId = s.UserId,
                                                  SubscribedOn = s.SubscribedOn,
                                                  ExpiryOn = s.ExpiryOn,
                                                  PlanId = s.PlanId,
                                                  PlanName= p.Name,
                                              }).ToList();
            return subs;
        }
    }
}
