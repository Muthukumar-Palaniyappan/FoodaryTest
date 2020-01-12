using System;
using System.Collections.Generic;
using System.Text;

namespace Rewards.Data.Models
{
    public class DiscountPromotionProduct
    {
        public int DiscountPromotionsProductID { get; set; }
        public string DiscountPromotionId { get; set; }
        public string ProductId { get; set; }

        public Product Product { get; set; }
        public DiscountPromotion DiscountPromotion { get; set; }
    }
}
