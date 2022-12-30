using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Core.Bets
{
    public class LowOrHighBet : Bet
    {
        public BetType BetTypeLowOrHigh { get; }
        public LowOrHighBet(BetType betType, double amount) : base(amount)
        {
            if (betType != BetType.High && betType != BetType.Low)
                throw new System.ArgumentException("Invalid value for betType");

            BetTypeLowOrHigh = betType;
        }

        public override double CalculateAmount(WheelNumber wheelNumber)
        {
            if (IsWon(wheelNumber))
            {
                WasWin = true;
                return Money * 2;
            }
            return 0;
        }

        protected override bool IsWon(WheelNumber wheelNumber)
        {
            if (BetType.High == BetTypeLowOrHigh)
                return wheelNumber.Digit > 18 && 37 > wheelNumber.Digit;
            return wheelNumber.Digit > 0 && 19 > wheelNumber.Digit;
        }
    }
}
