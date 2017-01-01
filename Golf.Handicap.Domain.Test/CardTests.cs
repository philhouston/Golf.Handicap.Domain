using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Golf.Handicap.Domain.Test {
    [TestClass]
    [ExcludeFromCodeCoverageAttribute]

    public class CardTests {

        private List<Score> _9scores = new List<Score>() {
            new Score(3, 5),
            new Score(4, 4),
            new Score(3, 5),
            new Score(4, 4),
            new Score(3, 5),
            new Score(4, 4),
            new Score(3, 5),
            new Score(4, 4),
            new Score(4, 4)
        };


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Card_Constructor_FutureDate_CausesException() {
            var card = new Card(DateTime.Now.AddDays(10), _9scores);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Card_Constructor_10Scores_CausesException() {
            var scores = new List<Score>();
            scores.InsertRange(0, _9scores);
            scores.Add(new Score(5, 4));

            var card = new Card(DateTime.Now.AddDays(-10), scores);
        }

        [TestMethod]
        public void Card_Constructor_9Scores_IsAccepted() {
            var scores = new List<Score>();
            scores.InsertRange(0, _9scores);
            var card = new Card(DateTime.Now.AddDays(-10), scores);
            Assert.IsNotNull(card);
        }

        [TestMethod]
        public void Card_Constructor_18Scores_IsAccepted() {
            var scores = new List<Score>();
            scores.InsertRange(0, _9scores);
            scores.InsertRange(0, _9scores);

            var card = new Card(DateTime.Now.AddDays(-10), scores);
            Assert.IsNotNull(card);
        }

        [TestMethod]
        public void Card_9Scores_TotalScoreIs40() {
            var scores = new List<Score>();
            scores.InsertRange(0, _9scores);

            var card = new Card(DateTime.Now.AddDays(-10), scores);
            Assert.AreEqual(40, card.TotalScore());
        }

        [TestMethod]
        public void Card_9Scores_ParTotalIs32() {
            var scores = new List<Score>();
            scores.InsertRange(0, _9scores);

            var card = new Card(DateTime.Now.AddDays(-10), scores);
            Assert.AreEqual(32, card.ParTotal());
        }

        [TestMethod]
        public void Card_9Scores_DifferenceIs8() {
            var scores = new List<Score>();
            scores.InsertRange(0, _9scores);

            var card = new Card(DateTime.Now.AddDays(-10), scores);
            Assert.AreEqual(8, card.Difference());
        }

        [TestMethod]
        public void Card_DatePlayed_ReturnsOriginalValue() {
            var scores = new List<Score>();
            scores.InsertRange(0, _9scores);

            var date = DateTime.Now.AddDays(-10);
            
            var card = new Card(date, scores);
            Assert.AreEqual(date, card.DatePlayed);
        }



    }
}
