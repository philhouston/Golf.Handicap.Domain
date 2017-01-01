using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf.Handicap.Domain {
    public class Golfer {

        public Golfer(Guid personId, SexEnum sex, decimal initialHandicap, IEnumerable<Card> cards) {
            if ((sex == SexEnum.Male || sex == SexEnum.Unknown) && (initialHandicap > 28)) {
                throw new ArgumentOutOfRangeException(String.Format("Maximum permitted Initial Handicap is 28 for {0}", sex.ToString()));
            }

            if (sex == SexEnum.Female && initialHandicap > 36) {
                throw new ArgumentOutOfRangeException(String.Format("Maximum permitted Initial Handicap is 36 for {0}", sex.ToString()));
            }

            PersonId = personId;
            Sex = sex;
            InitialHandicap = initialHandicap;
            Cards = cards.ToList();
            CurrentHandicap = CalculateExactHandicap(initialHandicap, cards);
            PlayingHandicap = CalculatePayingHandicap(CurrentHandicap);
        }

        private int CalculatePayingHandicap(decimal currentHandicap) {
            return (int)Math.Round(currentHandicap, 0, MidpointRounding.AwayFromZero);
        }

        private decimal CalculateExactHandicap(decimal initialHandicap, IEnumerable<Card> cards) {

            if (cards.Count() == 0)
                return initialHandicap;

            // Lets use a simple method for the time being
            var totalDifference = Cards.Sum(x => x.Difference());
            var cardCount = Cards.Count();
            decimal average = totalDifference / cardCount;

            decimal newHandicap = (InitialHandicap + average) / 2;

            return Math.Round(newHandicap, 1);
        }

        public Guid PersonId { get; }

        public SexEnum Sex { get; }

        private List<Card> Cards { get; set; }

        public decimal InitialHandicap { get; private set; }

        public decimal CurrentHandicap { get; private set; }

        public int PlayingHandicap { get; private set; }

        public void AddCard(Card card) {
            Cards.Add(card);
            CurrentHandicap =  CalculateExactHandicap(InitialHandicap, Cards);
            PlayingHandicap = CalculatePayingHandicap(CurrentHandicap);
        }

        public void PurgeCards() {
            InitialHandicap = CurrentHandicap;
            Cards = new List<Card>();
        }
    }
}
