namespace TestBullsAndCows
{
    using System;
    using BullsAndCowsGame.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for Human Player
    /// </summary>
    [TestClass]
    public class TestHumanPlayer
    {
        /// <summary>
        /// Tests if creating new human player works.
        /// </summary>
        [TestMethod]
        public void TestCreateNewHumanPlayer()
        {
            Player humanPlayer = new HumanPlayer("Ivan", "2345");

            Assert.AreEqual("Ivan", humanPlayer.Name);
            Assert.AreEqual(0, humanPlayer.Attempts);
        }

        /// <summary>
        /// Tests if method GetSecretNumber of class HumanPlayer works correctly.
        /// </summary>
        [TestMethod]
        public void TestHumanPlayerGetSecretNumber()
        {
            Player humanPlayer = new HumanPlayer("Ivan", "2345");

            Assert.AreEqual("2345", humanPlayer.GetSecretNumber);
        }

        /// <summary>
        /// Tests if creating HumanPlayer with invalid name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestHumanPlayerWithInvalidName()
        {
            Player humanPlayer = new HumanPlayer(null, "2345");
        }

        /// <summary>
        /// Tests if method CompareTo of class HumanPlayer works correctly.
        /// </summary>
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
