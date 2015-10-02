using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCowsGame.Models;

namespace TestBullsAndCows
{
    [TestClass]
    public class TestHumanPlayer
    {
        [TestMethod]
        public void TestCreateNewHumanPlayer()
        {
            Player humanPlayer = new HumanPlayer("Ivan", "2345");

            Assert.AreEqual("Ivan", humanPlayer.Name);
            Assert.AreEqual(0, humanPlayer.Attempts);
        }

        [TestMethod]
        public void TestHumanPlayerGetSecretNumber()
        {
            Player humanPlayer = new HumanPlayer("Ivan", "2345");

            Assert.AreEqual("2345", humanPlayer.GetSecretNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestHumanPlayerWithInvalidName()
        {
            Player humanPlayer = new HumanPlayer(null, "2345");
        }

        [TestMethod]
        public void TestHumanPlayerCompareTo()
        {
            Player humanPlayer = new HumanPlayer("Ivan", "2345");
            humanPlayer.Attempts = 10;
            Player anotherHumanPlayer = new HumanPlayer("Petko", "6789");
            anotherHumanPlayer.Attempts = 5;

            int comparePlayer = humanPlayer.CompareTo(anotherHumanPlayer);

            Assert.AreEqual(-5, comparePlayer);
        }
    }
}
