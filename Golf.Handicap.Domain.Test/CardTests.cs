using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Golf.Handicap.Domain.Test {
    [TestClass]
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



    }
}
