using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Core
{
    public class BetDetails
    {
        public double Amount { get; set; }
        public BetType BetType { get; set; }
        public bool IsWinner { get; set; }
    }
}
