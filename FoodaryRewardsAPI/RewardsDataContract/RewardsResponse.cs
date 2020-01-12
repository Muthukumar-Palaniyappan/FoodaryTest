using System;

namespace Rewards.DataContract
{
    public class RewardsResponse
    {
        public Guid CustomerId { get; set; }
        public string LoyaltyCard { get; set; }
        public string TransactionDate { get; set; }
        public string TotalAmount { get; set; }
        public string DiscountApplied { get; set; }
        public string GrandTotal { get; set; }
        public string PointsEarned { get; set; }
    }
}
