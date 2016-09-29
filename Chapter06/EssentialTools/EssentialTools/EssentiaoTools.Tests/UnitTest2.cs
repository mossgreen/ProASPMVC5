using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools.Models;
using System.Linq;
using Moq;

namespace EssentiaoTools.Tests
{
    [TestClass]
    public class UnitTest2
    {
        private Product[] products =
        {
            new Product {Name = "Kayak", Category = "WaterSports", Price = 275M},
            new Product {Name = "Lifejacket", Category = "WaterSports", Price = 48.95M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M},
        };

        [TestMethod]
        public void Sum_Products_Correctly()
        {
            //arrange
            //var discounter = new MinimumDiscountHelper();
            //var target = new LinqValueCalculator(discounter);
            //var goalTotal = products.Sum(e => e.Price);

            /*Creating a Mock Object. moq relies heavily on type parameters, 
             to create a mock IDiscountHelper implementation*/
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();

            /*Selecting a method. */
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>()))
                .Returns<decimal>(total => total);// defining the result 

            /*using the mock object*/
            var target = new LinqValueCalculator(mock.Object);
            //act
            var result = target.ValueProducts(products);

            //assert
            //Assert.AreEqual(goalTotal, result);
            Assert.AreEqual(products.Sum(e => e.Price), result);
        }
    }
}
