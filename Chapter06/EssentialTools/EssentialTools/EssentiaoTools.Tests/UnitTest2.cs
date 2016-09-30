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

        private Product[] createProduct(decimal value)
        {
            return new[] {new Product {Price = value}};
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Pass_Through_Variable_Discounts()
        {
            //arrange
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>()))
                .Returns<decimal>(total => total);
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v == 0)))
                .Throws<System.ArgumentOutOfRangeException>();//mock for specific values 
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v > 100)))
                .Returns<decimal>(total => (total*0.9M));//mocking for a range of values
            mock.Setup(m => m.ApplyDiscount(It.IsInRange<decimal>(10, 100, Range.Inclusive)))
                .Returns<decimal>(total => total - 5);
            var target = new LinqValueCalculator(mock.Object);

            //act
            decimal FiveDollarDiscount = target.ValueProducts(createProduct(5));
            decimal TenDollarDiscount = target.ValueProducts(createProduct(10));
            decimal FiftyDollarDiscount = target.ValueProducts(createProduct(50));
            decimal HundredDollarDiscount = target.ValueProducts(createProduct(100));
            decimal fiveHundredDollarDiscount = target.ValueProducts(createProduct(500));

            //assert
            Assert.AreEqual(5, FiveDollarDiscount, "$5 Fail");
            Assert.AreEqual(5, TenDollarDiscount,"$10 Fail");
            Assert.AreEqual(45, FiftyDollarDiscount,"$50 Fail");
            Assert.AreEqual(95, HundredDollarDiscount,"$100 Fail");
            Assert.AreEqual(450, fiveHundredDollarDiscount, "$500 Fail");
            target.ValueProducts(createProduct(0));
        }
    }
}
