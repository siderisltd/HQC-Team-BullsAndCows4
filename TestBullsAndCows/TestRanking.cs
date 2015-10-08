using System;
using BullsAndCowsGame.Interfaces;
using BullsAndCowsGame.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBullsAndCows
{
    [TestClass]
    public class TestRanking
    {
        [TestMethod]
        public void TestRankingMethod()
        {
            var ranklist = new Ranking<IPlayer>();
            var expect = 0;

            Assert.AreEqual(expect, ranklist.Count);
        }

        [TestMethod]
        public void TestRankingMethodAdd()
        {
            var humanPlayer = new HumanPlayer("Ivan", "3456");
            var ranklist = new Ranking<IPlayer>();
            ranklist.Add(humanPlayer);
            var expect = 1;

            Assert.AreEqual(expect, ranklist.Count);
        }

        [TestMethod]
        public void TestRankingMethodMoveNext()
        {
            var humanPlayer = new HumanPlayer("Ivan", "3456");
            var ranklist = new Ranking<IPlayer>();
            ranklist.Add(humanPlayer);
            var move = ranklist.MoveNext();

            Assert.IsTrue(move);
        }

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
