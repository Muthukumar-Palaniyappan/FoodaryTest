using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rewards.Data.Models
{
    public class PointsPromotion
    {
        public string PointsPromotionId { get; set; }
        public string PromotionName { get; set; }
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }
        public string Category { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PointsPerDollar { get; set; }
    }
}
