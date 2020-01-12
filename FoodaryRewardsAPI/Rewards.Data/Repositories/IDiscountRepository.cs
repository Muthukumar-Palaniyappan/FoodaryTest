using Rewards.Data.DTO;
using Rewards.DataContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rewards.Data.Repositories
{
    public interface IDiscountRepository
    {
        List<DiscountedProductDto> GetDiscountedProducts(RewardsRequest requestData);

        List<ProductItemDto> GetProductsInBasket(RewardsRequest requestData);
    }
}
