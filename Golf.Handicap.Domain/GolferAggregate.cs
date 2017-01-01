using Golf.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf.Handicap.Domain {
    public class GolferAggregate : Entity<Guid> {

        private List<Card> _cards;

        public GolferAggregate(Guid id, SexEnum sex, decimal currentHandicap) : base(id) {
            Sex = sex;
            SetCurrentHandicap(currentHandicap);
            ClearoutCards();
        }

        public GolferAggregate(Guid id, SexEnum sex, decimal currentHandicap, List<Card> cards) : this(id,sex,currentHandicap) {
            if (cards == null)
                throw new ArgumentNullException("Cards cannot be null");

            _cards = cards;
        }

        public SexEnum Sex { get; }
        public decimal CurrentHandicap { get; private set; }

        public int PlayingHandicap
        {
            get
            {
                return (int)Math.Round(CurrentHandicap, 0, MidpointRounding.AwayFromZero);
            }
        }

        public void CalculateNewHandicap(IHandicapCalculationService service) {
            var newHandicap = CalculateHandicap(service, _cards);
            ClearoutCards();
            SetCurrentHandicap(newHandicap);
        }

        public void AppendCards(List<Card> cards) {
            _cards.AddRange(cards);
        }

        private void ClearoutCards() {
            _cards = new List<Card>();
        }

        private void SetCurrentHandicap(decimal currentHandicap) {
            if ((Sex == SexEnum.Male || Sex == SexEnum.Unknown) && (currentHandicap > 28)) {
                throw new ArgumentOutOfRangeException(String.Format("Maximum permitted Initial Handicap is 28 for {0}", Sex.ToString()));
            }

            if (Sex == SexEnum.Female && currentHandicap > 36) {
                throw new ArgumentOutOfRangeException(String.Format("Maximum permitted Initial Handicap is 36 for {0}", Sex.ToString()));
            }

            CurrentHandicap = currentHandicap;
        }

        private decimal CalculateHandicap(IHandicapCalculationService service, IEnumerable<Card> cards) {
            if (service == null)
                throw new ArgumentNullException("Service cannot be null");

            if (cards == null)
                throw new ArgumentNullException("Cards cannot be null");

            return service.CalculateExactHandicap(CurrentHandicap, cards);
        }


    }
}
