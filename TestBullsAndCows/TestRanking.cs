namespace TestBullsAndCows
{
    using System;
    using BullsAndCowsGame.Interfaces;
    using BullsAndCowsGame.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for ranking of players.
    /// </summary>
    [TestClass]
    public class TestRanking
    {
        /// <summary>
        /// Tests if creating new Ranking works correctly.
        /// </summary>
        [TestMethod]
        public void TestRankingMethod()
        {
            var ranklist = new Ranking<IPlayer>();
            var expect = 0;

            Assert.AreEqual(expect, ranklist.Count);
        }

        /// <summary>
        /// Tests if method Add of class Ranking works correctly.
        /// </summary>
        [TestMethod]
        public void TestRankingMethodAdd()
        {
            var humanPlayer = new HumanPlayer("Ivan", "3456");
            var ranklist = new Ranking<IPlayer>();
            ranklist.Add(humanPlayer);
            var expect = 1;

            Assert.AreEqual(expect, ranklist.Count);
        }

        /// <summary>
        /// Tests if method MoveNext of class Ranking works correctly.
        /// </summary>
        [TestMethod]
        public void TestRankingMethodMoveNext()
        {
            var humanPlayer = new HumanPlayer("Ivan", "3456");
            var ranklist = new Ranking<IPlayer>();
            ranklist.Add(humanPlayer);
            var move = ranklist.MoveNext();

            Assert.IsTrue(move);
        }

        /// <summary>
        /// Tests if method Dispose of class Ranking works correctly.
        /// </summary>
        [TestMethod]
        public void TestRankingMethodDispose()
        {
            var humanPlayer = new HumanPlayer("Ivan", "3456");
            var ranklist = new Ranking<IPlayer>();
            ranklist.Add(humanPlayer);

            ranklist.Dispose();

        ////TODO
        }
    }
}
