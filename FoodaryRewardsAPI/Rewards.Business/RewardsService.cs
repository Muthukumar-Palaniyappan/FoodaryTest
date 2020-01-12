using Rewards.Business.Interfaces;
using Rewards.DataContract;
using System;
using System.Linq;
using Rewards.Data.Repositories;

namespace Rewards.Business
{
    public class RewardsService : IRewardsService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IPointsPromotionRepository _pointsPromotionRepository;

        public RewardsService(IDiscountRepository discountRepository, IPointsPromotionRepository pointsPromotionRepository)
        {
            //Promotions repository and Discount reository are clubbed together as the reward points should be calculated on net dollar spent.
            _discountRepository = discountRepository??throw new ArgumentNullException(nameof(discountRepository));
            _pointsPromotionRepository = pointsPromotionRepository ?? throw new ArgumentNullException(nameof(pointsPromotionRepository));
        }

        public RewardsResponse Calculate(RewardsRequest requestData)
        {
            var response = new RewardsResponse() { CustomerId = requestData.CustomerId, TransactionDate = requestData.TransactionDate, LoyaltyCard = requestData.LoyaltyCard };
                var discountedProducts = _discountRepository.GetDiscountedProducts(requestData);
                var productsRetrieved = _discountRepository.GetProductsInBasket(requestData);
                var productWithPoints = _pointsPromotionRepository.GetProductPoints(requestData);

            foreach (var item in productsRetrieved)
                {
                    var discountpercent = discountedProducts.FirstOrDefault(p => p.ProductId == item.ProductId)?.DiscountPercent??0;
                    var discountedValue = discountpercent*item.UnitPrice*item.Quantity / 100;
                    var originalPrice = item.UnitPrice * item.Quantity;
                    var netPrice = originalPrice - discountedValue;
                    response.DiscountApplied += discountedValue;
                    response.TotalAmount += originalPrice;
                    response.GrandTotal += netPrice;

                    //Promotions repository and Discount reository are clubbed together as the reward points should be calculated on net dollar spent.
                    var PromotionPoints = productWithPoints.FirstOrDefault(p => p.ProductId == item.ProductId)?.PointsPerDollar??0;
                    response.PointsEarned += netPrice * PromotionPoints; 

            }
            return response;
        }
    }
}
