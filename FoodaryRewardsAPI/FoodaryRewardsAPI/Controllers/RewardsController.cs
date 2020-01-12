using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rewards.DataContract;

namespace FoodaryRewardsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardsController : ControllerBase
    {
   

        // POST api/values
        [HttpPost]
        public RewardsResponse Post([FromBody] RewardsRequest request)
        {
            throw new NotImplementedException();
        }

     
    }
}
