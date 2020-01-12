using System;
using System.Collections.Generic;

namespace Rewards.DataContract
{
    public class RewardsRequest
    {
        public Guid CustomerId { get; set; }
        public string LoyaltyCard { get; set; }
        public DateTime TransactionDate { get; set; }
        public List<BasketItem> Basket { get; set; }
    }

    public class BasketItem
    {
        public string ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}