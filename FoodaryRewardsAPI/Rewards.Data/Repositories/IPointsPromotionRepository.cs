using Rewards.Data.DTO;
using Rewards.DataContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rewards.Data.Repositories
{
    public interface IPointsPromotionRepository
    {
        List<PointsPromotionDto> GetProductPoints(RewardsRequest requestData);

    }
}
