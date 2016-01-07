using Microsoft.VisualStudio.TestTools.UnitTesting;

using Engine;

namespace TestEngine
{
    [TestClass]
    public class TestGame
    {
        [TestMethod]
        public void TestNewGame()
        {
            Game game = new Game("MyGame", 1, 2, 1999, "https://github.com/ScottLilly/ScottsOpenSourceRPG", "Scott's Open Source C# RPG");

            Assert.AreEqual("MyGame", game.Name);
            Assert.AreEqual("1.2", game.CurrentVersion.ToString());
        }
    }
}
