using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf.Handicap.Domain {
    public class Card {

        public Card(DateTime datePlayed, IEnumerable<Score> scores) {
            if (datePlayed > DateTime.Now)
                throw new ArgumentOutOfRangeException("Date Played must be in the past");
            if (scores.Count() != 9 || scores.Count() != 18)
                throw new ArgumentOutOfRangeException("Scores submitted must be for 9 or 18 holes only");

            DatePlayed = datePlayed;
            Scores = scores;
        }

        public DateTime DatePlayed { get; private set; }
        public IEnumerable<Score> Scores { get; private set; }

        public int TotalScore() {
            return Scores.Sum(x => x.AdjustedShots);
        }

        public int ParTotal() {
            return Scores.Sum(x => x.Par);
        }

        public int Difference() {
            return TotalScore() - ParTotal();
        }
    }
}
