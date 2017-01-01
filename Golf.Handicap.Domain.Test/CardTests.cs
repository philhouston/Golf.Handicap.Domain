using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Golf.Handicap.Domain.Test {
    [TestClass]
    [ExcludeFromCodeCoverageAttribute]

    public class CardTests {

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Card_Constructor_FutureDate_CausesException() {
            var card = new Card(DateTime.Now.AddDays(10), TestDataCreator.Scores9Holes());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Card_Constructor_10Scores_CausesException() {
            var scores = new List<Score>();
            scores.InsertRange(0, TestDataCreator.Scores9Holes());
            scores.Add(new Score(5, 4));

            var card = new Card(DateTime.Now.AddDays(-10), scores);
        }

        [TestMethod]
        public void Card_Constructor_9Scores_IsAccepted() {
            var scores = new List<Score>();
            scores.InsertRange(0, TestDataCreator.Scores9Holes());
            var card = new Card(DateTime.Now.AddDays(-10), scores);
            Assert.IsNotNull(card);
        }

        [TestMethod]
        public void Card_Constructor_18Scores_IsAccepted() {
            var scores = new List<Score>();
            scores.InsertRange(0, TestDataCreator.Scores9Holes());
            scores.InsertRange(0, TestDataCreator.Scores9Holes());

            var card = new Card(DateTime.Now.AddDays(-10), scores);
            Assert.IsNotNull(card);
        }

        [TestMethod]
        public void Card_9Scores_TotalScoreIs40() {
            var scores = new List<Score>();
            scores.InsertRange(0, TestDataCreator.Scores9Holes());

            var card = new Card(DateTime.Now.AddDays(-10), scores);
            Assert.AreEqual(40, card.TotalScore());
        }

        [TestMethod]
        public void Card_9Scores_ParTotalIs32() {
            var scores = new List<Score>();
            scores.InsertRange(0, TestDataCreator.Scores9Holes());

            var card = new Card(DateTime.Now.AddDays(-10), scores);
            Assert.AreEqual(32, card.ParTotal());
        }

        [TestMethod]
        public void Card_9Scores_DifferenceIs8() {
            var scores = new List<Score>();
            scores.InsertRange(0, TestDataCreator.Scores9Holes());

            var card = new Card(DateTime.Now.AddDays(-10), scores);
            Assert.AreEqual(8, card.Difference());
        }

        [TestMethod]
        public void Card_DatePlayed_ReturnsOriginalValue() {
            var scores = new List<Score>();
            scores.InsertRange(0, TestDataCreator.Scores9Holes());

            var date = DateTime.Now.AddDays(-10);
            
            var card = new Card(date, scores);
            Assert.AreEqual(date, card.DatePlayed);
        }
    }
}
