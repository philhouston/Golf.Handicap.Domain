using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf.Handicap.Domain
{
    public class Root
    {

        private Golfer _golfer;


        public Root(Golfer golfer) {
            if (golfer == null)
                throw new ArgumentNullException("Golfer cannot be null");

            _golfer = golfer;
        }

        public void CalculateHandicap(IHandicapCalculationService service) {
            if (service == null)
                throw new ArgumentNullException("Service cannot be null");

            _golfer.CalculateNewHandicap(service);
        }

        public void AppendCards(List<Card> cards) {
            if (cards == null)
                throw new ArgumentNullException("Cards cannot be null");

            _golfer.AppendCards(cards);
        }

        public decimal GetCurrentHandicap() {
            return _golfer.CurrentHandicap;
        }

    }
}
