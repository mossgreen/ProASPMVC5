using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools.Models;

namespace EssentiaoTools.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IDiscountHelper getTestObject()
        {
            return new MinimumDiscountHelper();
        }
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            IDiscountHelper target = getTestObject();
            decimal total = 200;

            //act 
            var discountedTotal = target.ApplyDiscount(total);

            //assert
            Assert.AreEqual(total * 0.9M, discountedTotal);
        }
    }
}
