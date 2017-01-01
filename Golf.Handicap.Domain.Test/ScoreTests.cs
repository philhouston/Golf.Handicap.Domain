using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Golf.Handicap.Domain.Test {
    [TestClass]
    public class ScoreTests {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Score_Constructore_Par2_CausesException() {
            var score = new Score(2, 10);
        }

        [TestMethod]
        public void Score_Constructore_Par3_CreatesInstance() {

            var score = new Score(3, 10);
            Assert.IsNotNull(score);
        }

        [TestMethod]
        public void Score_Constructore_Par4_CreatesInstance() {
            var score = new Score(4, 10);
            Assert.IsNotNull(score);
        }

        [TestMethod]
        public void Score_Constructore_Par5_CreatesInstance() {
            var score = new Score(5, 10);
            Assert.IsNotNull(score);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Score_Constructore_Par6_CausesException() {
            var score = new Score(6, 10);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Score_Constructore_ShotsPlayedIsZero_CausesException() {
            var score = new Score(4, 0);
        }

        [TestMethod]
        public void Score_AdjustedShots_5Over_CalculatesToDoubleBogie() {
            var score = new Score(5, 10);
            Assert.IsTrue(score.AdjustedShots == 7);
        }

        [TestMethod]
        public void Score_AdjustedShots_Eagle_CalculatesToEagle() {
            var score = new Score(5, 3);
            Assert.IsTrue(score.AdjustedShots == 3);
        }



    }
}
