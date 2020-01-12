using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rewards.Business.Interfaces;
using Rewards.DataContract;

namespace FoodaryRewardsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardsController : ControllerBase
    {
        private readonly IRewardsService _discountService;
        //private readonly IPointsPromotionService _pointsPromotionService;

        public RewardsController(IRewardsService discountService)
        {
            _discountService = discountService ?? throw new ArgumentNullException(nameof(discountService));
          //  _pointsPromotionService = pointsPromotionService ?? throw new ArgumentNullException(nameof(pointsPromotionService));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] RewardsRequest request)
        {
            var response = _discountService.Calculate(request);
            return Ok(response); 
        }

     
    }
}
