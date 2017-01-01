using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf.Handicap.Domain.Test {
    public static class TestDataCreator {

        public static List<Score> Scores9Holes() {
            return new List<Score>() {
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
        }

        public static Card Card() {
            return new Card(DateTime.Now.AddDays(-10), Scores9Holes());
        }

    }
}
