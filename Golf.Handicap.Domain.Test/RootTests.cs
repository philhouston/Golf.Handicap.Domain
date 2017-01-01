using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Golf.Handicap.Domain.Test {
    [TestClass]
    [ExcludeFromCodeCoverageAttribute]

    public class RootTests {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Root_Constructor_Golfer_IsNull_CausesException() {
            var root = new Root(null);

            Assert.Fail("Expected Exception to bew raised");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Root_CalculateHandicap_WithNullService_RaisesException() {
            var root = new Root(new Golfer(Guid.NewGuid(), SexEnum.Male, 10.3M));

            root.CalculateHandicap(null);

            Assert.Fail("Expected exception to be raised");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Root_AppendCards_WithNullCards_RaisesException() {
            var root = new Root(new Golfer(Guid.NewGuid(), SexEnum.Male, 10.3M));

            root.AppendCards(null);

            Assert.Fail("Expected exception to be raised");
        }

        [TestMethod]
        public void Root_CalculateHandicap_10Point3HanicapWithOneCard_NewHandicapOf9Point2() {
            var root = new Root(new Golfer(Guid.NewGuid(), SexEnum.Male, 10.3M));

            root.AppendCards(new List<Card>() { TestDataCreator.Card() });
            root.CalculateHandicap(new SimpleHandicapCalculationService());

            Assert.AreEqual(9.2M, root.GetCurrentHandicap());
        }



    }
}
