using System;

namespace Rewards.DataContract
{
    public class RewardsResponse
    {
        public Guid CustomerId { get; set; }
        public string LoyaltyCard { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountApplied { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal PointsEarned { get; set; }
    }
}
