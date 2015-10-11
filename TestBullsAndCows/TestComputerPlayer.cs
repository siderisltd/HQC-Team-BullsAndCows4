namespace TestBullsAndCows
{
    using System;
    using BullsAndCowsGame.Exceptions;
    using BullsAndCowsGame.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for Computer Player.
    /// </summary>
    [TestClass]
    public class TestComputerPlayer
    {
        /// <summary>
        /// Tests if creating new computer player work.
        /// </summary>
        [TestMethod]
        public void TestCreateNewComputerPlayer()
        {
            Player computerPlayer = new ComputerPlayer("Ivan", "2345");

            Assert.AreEqual("Ivan", computerPlayer.Name);
            Assert.AreEqual(0, computerPlayer.Attempts);
        }

        /// <summary>
        /// Tests if method GetSecretNumber of class ComputerPlayer works correctly.
        /// </summary>
        [TestMethod]
        public void TestComputerPlayerGetSecretNumber()
        {
            Player computerPlayer = new ComputerPlayer("Ivan", "2345");

            Assert.AreEqual("2345", computerPlayer.GetSecretNumber);
        }

        /// <summary>
        /// Tests if computer players throws exception with given invalid name.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestComputerPlayerWithInvalidName()
        {
            Player computerPlayer = new ComputerPlayer(null, "2345");
        }

        /// <summary>
        /// Tests if method CompareTo of class ComputerPlayer works correctly.
        /// </summary>
        [TestMethod]
        public void TestComputerPlayerCompareTo()
        {
            Player computerPlayer = new ComputerPlayer("Ivan", "2345");
            computerPlayer.Attempts = 10;
            Player anotherHumanPlayer = new ComputerPlayer("Petko", "6789");
            anotherHumanPlayer.Attempts = 5;

            int comparePlayer = computerPlayer.CompareTo(anotherHumanPlayer);

            Assert.AreEqual(-5, comparePlayer);
        }
    }
}
