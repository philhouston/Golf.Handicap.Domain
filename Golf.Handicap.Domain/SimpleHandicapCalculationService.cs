using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf.Handicap.Domain {
    public class SimpleHandicapCalculationService : IHandicapCalculationService {

        public decimal CalculateExactHandicap(decimal initialHandicap, IEnumerable<Card> cards) {

            if (cards.Count() == 0)
                return initialHandicap;

            // Lets use a simple method for the time being
            var totalDifference = cards.Sum(x => x.Difference());
            var cardCount = cards.Count();
            decimal average = totalDifference / cardCount;

            decimal newHandicap = (initialHandicap + average) / 2;

            return Math.Round(newHandicap, 1);
        }
    }
}
