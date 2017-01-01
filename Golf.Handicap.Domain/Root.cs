using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf.Handicap.Domain
{
    public class Root
    {
        public Root(Golfer golfer) {
            if (golfer == null)
                throw new ArgumentNullException("Golfer cannot be null");

            Golfer = golfer;
        }

        public Golfer Golfer { get; }

    }
}
