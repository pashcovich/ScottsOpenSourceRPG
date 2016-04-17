using System;
using Engine.Models.Mutable;
using Engine.Services.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestEngine.Models.Mutable
{
    [TestClass]
    public class TestPlayer
    {
        [TestMethod]
        public void TestInitialValuesAreSetProperly()
        {
            Player player = PlayerBuilder.CreateNew("Test");

            Assert.AreEqual("Test", player.Name);
            Assert.AreEqual(10, player.CurrentHitPoints);
            Assert.AreEqual(10, player.MaximumHitPoints);
            Assert.AreEqual(1, player.Level);
            Assert.IsTrue(player.IsAlive);
            Assert.IsFalse(player.IsDead);
        }

        [TestMethod]
        public void TestApplyDamageAmountLessThanCurrentHitPoints()
        {
            Player player = PlayerBuilder.CreateNew("Test");

            player.ApplyDamage(6);

            Assert.AreEqual(4, player.CurrentHitPoints);
            Assert.IsTrue(player.IsAlive);
            Assert.IsFalse(player.IsDead);
        }

        [TestMethod]
        public void TestApplyDamageAmountMoreThanCurrentHitPoints()
        {
            Player player = PlayerBuilder.CreateNew("Test");

            player.ApplyDamage(12);

            Assert.AreEqual(0, player.CurrentHitPoints);
            Assert.IsFalse(player.IsAlive);
            Assert.IsTrue(player.IsDead);
        }

        [TestMethod]
        public void TestApplyHealWhenAtMaximumHitPoints()
        {
            Player player = PlayerBuilder.CreateNew("Test");

            player.ApplyHeal(5);

            Assert.AreEqual(10, player.CurrentHitPoints);
            Assert.IsTrue(player.IsAlive);
            Assert.IsFalse(player.IsDead);
        }

        [TestMethod]
        public void TestApplyHealAfterReceivingDamage_HealLessThanDamage()
        {
            Player player = PlayerBuilder.CreateNew("Test");

            player.ApplyDamage(6);
            player.ApplyHeal(5);

            Assert.AreEqual(9, player.CurrentHitPoints);
            Assert.IsTrue(player.IsAlive);
            Assert.IsFalse(player.IsDead);
        }

        [TestMethod]
        public void TestApplyHealAfterReceivingDamage_HealEqualToDamage()
        {
            Player player = PlayerBuilder.CreateNew("Test");

            player.ApplyDamage(6);
            player.ApplyHeal(6);

            Assert.AreEqual(10, player.CurrentHitPoints);
            Assert.IsTrue(player.IsAlive);
            Assert.IsFalse(player.IsDead);
        }

        [TestMethod]
        public void TestApplyHealAfterReceivingDamage_HealMoreThanDamage()
        {
            Player player = PlayerBuilder.CreateNew("Test");

            player.ApplyDamage(6);
            player.ApplyHeal(10);

            Assert.AreEqual(10, player.CurrentHitPoints);
            Assert.IsTrue(player.IsAlive);
            Assert.IsFalse(player.IsDead);
        }

        [TestMethod]
        public void TestLevelByGivingExperiencePoints()
        {
            Player player = PlayerBuilder.CreateNew("Test");

            Assert.AreEqual(1, player.Level);

            player.GiveExperiencePoints(99);
            Assert.AreEqual(1, player.Level);

            player.GiveExperiencePoints(1);
            Assert.AreEqual(2, player.Level);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "'amount' cannot be less than 0")]
        public void TestGiveGold_NegativeAmount()
        {
            Player player = PlayerBuilder.CreateNew("Test'");

            Assert.AreEqual(0, player.Gold);

            player.GiveGold(-5);
        }

        [TestMethod]
        public void TestGiveGold_PositiveAmount()
        {
            Player player = PlayerBuilder.CreateNew("Test'");

            Assert.AreEqual(0, player.Gold);

            player.GiveGold(5);

            Assert.AreEqual(5, player.Gold);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "'amount' cannot be less than 0")]
        public void TestTakeGold_NegativeAmount()
        {
            Player player = PlayerBuilder.CreateNew("Test'");

            player.GiveGold(10);

            player.TakeGold(-5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Player has 10 gold. Cannot take 15 gold.")]
        public void TestTakeGold_TakeMoreThanPlayerHas()
        {
            Player player = PlayerBuilder.CreateNew("Test'");

            player.GiveGold(10);

            player.TakeGold(-15);
        }

        [TestMethod]
        public void TestTakeGold_AmountEqualToPlayersGold()
        {
            Player player = PlayerBuilder.CreateNew("Test'");

            player.GiveGold(10);

            player.TakeGold(10);
            Assert.AreEqual(0, player.Gold);
        }

        [TestMethod]
        public void TestTakeGold_PositiveAmount()
        {
            Player player = PlayerBuilder.CreateNew("Test'");

            player.GiveGold(10);

            player.TakeGold(4);
            Assert.AreEqual(6, player.Gold);
        }
    }
}
