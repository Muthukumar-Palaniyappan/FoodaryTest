using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rewards.Data.DTO;
using Rewards.Data.Repositories;
using Rewards.DataContract;

namespace Rewards.Business.Tests
{
    [TestClass]
    public class RewardsServiceTests
    {
        private Mock<IDiscountRepository> _discountRepositoryMock { get; set; }
        private Mock<IPointsPromotionRepository> _pointsPromotionRepositoryMock { get; set; }

        private RewardsService _rewardsService { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            _discountRepositoryMock = new Mock<IDiscountRepository>();
            _pointsPromotionRepositoryMock = new Mock<IPointsPromotionRepository>();

            _discountRepositoryMock.Setup(m=>m.GetDiscountedProducts(It.IsAny<RewardsRequest>())).Returns(getdiscountedProducts());
            _discountRepositoryMock.Setup(m => m.GetProductsInBasket(It.IsAny<RewardsRequest>())).Returns(getProductsInBasket());
            _pointsPromotionRepositoryMock.Setup(m => m.GetProductPoints(It.IsAny<RewardsRequest>())).Returns(getProductPoints());

            _rewardsService = new RewardsService(_discountRepositoryMock.Object, _pointsPromotionRepositoryMock.Object);
        }


        [TestMethod]
        public void DiscountCalculationTest()
        {
            var request = getRewardsRequest();
            var response = _rewardsService.Calculate(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(request.CustomerId, response.CustomerId);
            Assert.AreEqual(request.LoyaltyCard, response.LoyaltyCard);
            Assert.AreEqual(request.TransactionDate, response.TransactionDate);
            Assert.AreEqual(30, response.TotalAmount);
            Assert.AreEqual(8, response.DiscountApplied);
            Assert.AreEqual(22, response.GrandTotal);
            Assert.AreEqual(18, response.PointsEarned);

        }

        private List<DiscountedProductDto> getdiscountedProducts()
        {
            return new List<DiscountedProductDto>()
            {
                new DiscountedProductDto{ProductId="PRD01",DiscountPercent=50 },
                new DiscountedProductDto{ProductId="PRD02",DiscountPercent=25}
            };
        }
        private List<ProductItemDto> getProductsInBasket()
        {
            return new List<ProductItemDto>()
            {
                new ProductItemDto{ProductId="PRD01",UnitPrice=2M,Quantity=5 },
                new ProductItemDto{ProductId="PRD02",UnitPrice=4M,Quantity=3 },
                new ProductItemDto{ProductId="PRD03",UnitPrice=4M,Quantity=2 }

            };
        }
        private List<PointsPromotionDto> getProductPoints()
        {
            return new List<PointsPromotionDto>()
            {
                new PointsPromotionDto{ProductId="PRD01",PointsPerDollar=2 },
                new PointsPromotionDto{ProductId="PRD03",PointsPerDollar=1}
            };
        }
        private RewardsRequest getRewardsRequest()
        {
            return new RewardsRequest()
            {
                CustomerId = new Guid("8e4e8991-aaee-495b-9f24-52d5d0e509c5"),
                LoyaltyCard = "CTX0000001",
                TransactionDate = new DateTime(2020, 01, 06)

            };
        }
       
    }
}
