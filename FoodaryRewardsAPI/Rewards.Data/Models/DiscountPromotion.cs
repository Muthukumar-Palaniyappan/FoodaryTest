using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rewards.Data.Models
{
    public class DiscountPromotion
    {
        public string DiscountPromotionId { get; set; }
        public string PromotionName { get; set; }
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountPercent { get; set; }

        public List<DiscountPromotionProduct> DiscountPromotionProducts { get; set; }
    }
    
}
