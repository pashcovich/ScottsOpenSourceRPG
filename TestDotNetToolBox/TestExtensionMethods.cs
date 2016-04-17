using DotNetToolBox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDotNetToolBox
{
    [TestClass]
    public class TestExtensionMethods
    {
        [TestMethod]
        public void TestWithLimitsOf_BelowLowerLimit()
        {
            Assert.AreEqual(5, 3.WithLimitsOf(5, 10));
        }

        [TestMethod]
        public void TestWithLimitsOf_EqualToLowerLimit()
        {
            Assert.AreEqual(3, 3.WithLimitsOf(3, 10));
        }

        [TestMethod]
        public void TestWithLimitsOf_AboveUpperLimit()
        {
            Assert.AreEqual(10, 13.WithLimitsOf(5, 10));
        }

        [TestMethod]
        public void TestWithLimitsOf_EqualToUpperLimit()
        {
            Assert.AreEqual(10, 10.WithLimitsOf(5, 10));
        }

        [TestMethod]
        public void TestWithLowerLimit_BelowLowerLimit()
        {
            Assert.AreEqual(5, 3.WithLowerLimitOf(5));
        }

        [TestMethod]
        public void TestWithLowerLimit_EqualToLowerLimit()
        {
            Assert.AreEqual(5, 5.WithLowerLimitOf(5));
        }

        [TestMethod]
        public void TestWithUpperLimit_AboveUpperLimit()
        {
            Assert.AreEqual(5, 10.WithUpperLimitOf(5));
        }

        [TestMethod]
        public void TestWithUpperLimit_EqualToUpperLimit()
        {
            Assert.AreEqual(10, 10.WithUpperLimitOf(10));
        }
    }
}
