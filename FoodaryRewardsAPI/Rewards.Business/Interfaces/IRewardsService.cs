using Rewards.DataContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rewards.Business.Interfaces
{
    public interface IRewardsService
    {
        void Calculate(RewardsRequest requestData, RewardsResponse response);
    }
}
