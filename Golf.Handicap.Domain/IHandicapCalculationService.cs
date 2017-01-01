using System.Collections.Generic;

namespace Golf.Handicap.Domain {
    public interface IHandicapCalculationService {
        decimal CalculateExactHandicap(decimal initialHandicap, IEnumerable<Card> cards);
    }
}