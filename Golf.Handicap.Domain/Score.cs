using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf.Handicap.Domain {
    public class Score {

        public Score(int par, int shotsPlayed) {
            if (par < 3 || par > 5)
                throw new ArgumentOutOfRangeException(String.Format("Par cannot be {0}, it can only be in the range of 3 to 5 ", par));

            if (shotsPlayed < 1)
                throw new ArgumentOutOfRangeException("Shots Played cannot be less than 1");

            Par = par;
            ShotsPlayed = shotsPlayed;
            AdjustedShots = AdjustShots(par, shotsPlayed);
        }
       

        public int Par { get; }
        public int ShotsPlayed { get; }
        public int AdjustedShots { get; }

        int AdjustShots(int par, int shotsPlayed) {
            if (shotsPlayed > par + 2)
                return par + 2;
            else
                return shotsPlayed;
        }
    }
}
