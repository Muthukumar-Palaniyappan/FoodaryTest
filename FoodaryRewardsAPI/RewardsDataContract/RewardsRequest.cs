using System;
using System.Collections.Generic;

namespace RewardsDataContract
{
    public class RewardsRequest
    {
        public Guid CustomerId { get; set; }
        public string LoyaltyCard { get; set; }
        public string TransactionDate { get; set; }
        public List<BasketItem> Basket { get; set; }
    }

    public class BasketItem
    {
        public string ProductId { get; set; }
        public string UnitPrice { get; set; }
        public string Quantity { get; set; }
    }
}