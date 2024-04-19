namespace eVideoPrime.Models
{
    public partial class SubscriptionModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime SubscribedOn { get; set; }
        public DateTime ExpiryOn { get; set; }
        public int PlanId { get; set; }
        public string UserName { get; set; }
        public string PlanName { get; set; }
    }
}