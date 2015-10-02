using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCowsGame.Models;

namespace TestBullsAndCows
{
    [TestClass]
    public class TestComputerPlayer
    {
        [TestMethod]
        public void TestCreateNewComputerPlayer()
        {
            Player computerPlayer = new ComputerPlayer("Ivan", "2345");

            Assert.AreEqual("Ivan", computerPlayer.Name);
            Assert.AreEqual(0, computerPlayer.Attempts);
        }

        [TestMethod]
        public void TestComputerPlayerGetSecretNumber()
        {
            Player computerPlayer = new ComputerPlayer("Ivan", "2345");

            Assert.AreEqual("2345", computerPlayer.GetSecretNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestComputerPlayerWithInvalidName()
        {
            Player computerPlayer = new ComputerPlayer(null, "2345");
        }

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
