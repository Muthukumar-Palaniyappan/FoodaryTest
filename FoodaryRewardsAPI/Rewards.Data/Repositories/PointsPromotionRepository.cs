using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Rewards.Data.DTO;
using Rewards.Data.Models;
using Rewards.DataContract;


namespace Rewards.Data.Repositories
{
    public class PointsPromotionRepository : IPointsPromotionRepository
    {
        public List<PointsPromotionDto> GetProductPoints(RewardsRequest requestData)
        {
            using (var _rewardEntities = new RewardsEntities())
            {
                return _rewardEntities.Products
                                      .Join(requestData.Basket,
                                            d => d.ProductId,
                                            b => b.ProductId,
                                            (d, b) => new { d.ProductId,d.UnitPrice, d.Category, b.Quantity })
                                      .Join(_rewardEntities.PointsPromotions,  //Doing Cartesian Join and matching category in where clause
                                            d => "Any", 
                                            pr => "Any",
                                            (d, pr) => new { d.ProductId, d.Category,PromoCategory= pr.Category, pr.PointsPerDollar, pr.StartDate, pr.EndDate })
                                       .Where(pr => pr.StartDate <= requestData.TransactionDate && pr.EndDate >= requestData.TransactionDate
                                       && ( pr.Category ==pr.PromoCategory || pr.PromoCategory=="Any"))
                                       .Select(res => new PointsPromotionDto { ProductId = res.ProductId,
                                                                                 PointsPerDollar = res.PointsPerDollar })
                                       .ToList();
            }
        }
    }
}
