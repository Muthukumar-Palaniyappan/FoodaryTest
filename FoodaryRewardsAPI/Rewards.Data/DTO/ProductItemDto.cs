using System;
using System.Collections.Generic;
using System.Text;

namespace Rewards.Data.DTO
{
    public class ProductItemDto
    {
        public string ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
