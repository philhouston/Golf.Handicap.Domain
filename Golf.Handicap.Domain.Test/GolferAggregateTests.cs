using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Golf.Handicap.Domain.Test {
    [TestClass]
    [ExcludeFromCodeCoverageAttribute]
    public class GolferAggregateTests {


       
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Golfer_Constructor_SexMale_InitialHandicapOf29_CausesException() {
            var golfer = new GolferAggregate(Guid.NewGuid(), SexEnum.Male, 29);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Golfer_Constructor_SexUknown_InitialHandicapOf29_CausesException() {
            var golfer = new GolferAggregate(Guid.NewGuid(), SexEnum.Unknown, 29);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Golfer_Constructor_SexFemale_InitialHandicapOf37_CausesException() {
            var golfer = new GolferAggregate(Guid.NewGuid(), SexEnum.Female, 37);
        }

        [TestMethod]
        public void Golfer_Constructor_SexFemale_InitialHandicapOf29_DoesNotCausesException() {
            var golfer = new GolferAggregate(Guid.NewGuid(), SexEnum.Female, 29 );
            Assert.IsNotNull(golfer);
        }

        [TestMethod]
        public void Golfer_InitialHandicap10_withCardDifferenceOf8_CalculatesNewHandicapCorrectly() {

            var initialHandicap = 10m;
            var card = TestDataCreator.Card();
            var diff = card.Difference();
            var newHandicap = (initialHandicap + diff) / 2;

            var cards = new List<Card>() { card};
            var golfer = new GolferAggregate(Guid.NewGuid(), SexEnum.Female, initialHandicap, cards);

            golfer.CalculateNewHandicap(new SimpleHandicapCalculationService());
            Assert.AreEqual(newHandicap, golfer.CurrentHandicap);

        }


        [TestMethod]
        public void Golfer_InitialHandicap10Point3_HasPlayingHandicapOf10() {

            var initialHandicap = 10.3m;
            var playingHandicap = 10;

            var cards = new List<Card>();
            var golfer = new GolferAggregate(Guid.NewGuid(), SexEnum.Female, initialHandicap, cards);

            Assert.AreEqual(playingHandicap, golfer.PlayingHandicap);

        }
        
        [TestMethod]
        public void Golfer_InitialHandicap10Point5_HasPlayingHandicapOf11() {

            var initialHandicap = 10.5m;
            var playingHandicap = 11;

            var cards = new List<Card>();
            var golfer = new GolferAggregate(Guid.NewGuid(), SexEnum.Female, initialHandicap, cards);

            Assert.AreEqual(playingHandicap, golfer.PlayingHandicap);

        }

        [TestMethod]
        public void Golfer_InitialHandicap10Point6_HasPlayingHandicapOf11() {

            var initialHandicap = 10.6m;
            var playingHandicap = 11;

            var cards = new List<Card>();
            var golfer = new GolferAggregate(Guid.NewGuid(), SexEnum.Female, initialHandicap, cards);

            Assert.AreEqual(playingHandicap, golfer.PlayingHandicap);

        }


    }
}
