using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Rewards.Data.DTO;
using Rewards.Data.Models;
using Rewards.DataContract;

namespace Rewards.Data.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        public List<DiscountedProductDto> GetDiscountedProducts(RewardsRequest requestData)
        {
            using (var _rewardEntities = new RewardsEntities())
            {
                return _rewardEntities.DiscountPromotionProducts
                                 .Include(i => i.DiscountPromotion)
                                 .Include(p => p.Product)
                                 .Join(requestData.Basket,
                                 d => d.ProductId,
                                 b => b.ProductId,
                                 (d, b) => new { d.ProductId, d.DiscountPromotion, d.Product, b.Quantity })
                                 .Where(d => d.DiscountPromotion.StartDate <= requestData.TransactionDate
                                        && d.DiscountPromotion.EndDate >= requestData.TransactionDate).ToList()
                                 .GroupBy(s => s.ProductId).
                                 Select(g => new DiscountedProductDto { ProductId = g.Key, DiscountPercent = g.Sum(q => q.DiscountPromotion.DiscountPercent) }).ToList();

            }
        }

        public List<ProductItemDto> GetProductsInBasket(RewardsRequest requestData)
        {
            using (var _rewardEntities = new RewardsEntities())
            {
                return _rewardEntities.Products
                .Join(requestData.Basket,
                             d => d.ProductId,
                             b => b.ProductId,
                             (d, b) => new ProductItemDto
                             {
                                 ProductId= d.ProductId,
                                 UnitPrice= d.UnitPrice,
                                 Quantity= b.Quantity,
                             }).ToList();
            }
        }
    }
}
