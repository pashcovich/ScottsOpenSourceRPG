using Microsoft.VisualStudio.TestTools.UnitTesting;

using Engine;

namespace TestEngine
{
    [TestClass]
    public class TestServiceManager
    {
        [TestMethod]
        public void TestWorldPopulation()
        {
            ReferenceData.AddLocation(0, 0, "Town Square", "This is the town square", "", "");
            ReferenceData.AddLocation(0, -1, "Your Home", "This is your home", "", "");
            ReferenceData.AddLocation(0, -2, "Your Garden", "This is your garden", "", "");
            ReferenceData.AddLocation(-1, -2, "Hill", "This is a hill", "", "");
            ReferenceData.AddLocation(1, -2, "Cave", "This is a cave", "", "");

            Assert.IsFalse(ReferenceData.ThereIsLocationNorthOf(0, 0));
            Assert.IsFalse(ReferenceData.ThereIsLocationEastOf(0, 0));
            Assert.IsTrue(ReferenceData.ThereIsLocationSouthOf(0, 0));
            Assert.IsFalse(ReferenceData.ThereIsLocationWestOf(0, 0));

            Assert.IsTrue(ReferenceData.ThereIsLocationNorthOf(0, -1));
            Assert.IsFalse(ReferenceData.ThereIsLocationEastOf(0, -1));
            Assert.IsTrue(ReferenceData.ThereIsLocationSouthOf(0, -1));
            Assert.IsFalse(ReferenceData.ThereIsLocationWestOf(0, -1));

            Assert.IsTrue(ReferenceData.ThereIsLocationNorthOf(0, -2));
            Assert.IsTrue(ReferenceData.ThereIsLocationEastOf(0, -2));
            Assert.IsFalse(ReferenceData.ThereIsLocationSouthOf(0, -2));
            Assert.IsTrue(ReferenceData.ThereIsLocationWestOf(0, -2));
        }
    }
}
