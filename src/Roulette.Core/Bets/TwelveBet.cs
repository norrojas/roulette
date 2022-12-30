using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Core.Bets
{
    public class TwelveBet : Bet
    {
        public BetType BetTypeTwelve { get; }
        public TwelveBet(BetType betType, double amount) : base(amount)
        {
            if (betType != BetType.TwelveOne && betType != BetType.TwelveTwo && betType != BetType.TwelveThree)
                throw new System.ArgumentException("Invalid value for betType");

            BetTypeTwelve = betType;
        }

        public override double CalculateAmount(WheelNumber wheelNumber)
        {
            if (IsWon(wheelNumber))
            {
                WasWin = true;
                return Money * 3;
            }
            return 0;
        }

        protected override bool IsWon(WheelNumber wheelNumber)
        {
            if (BetType.TwelveOne == BetTypeTwelve)
                return wheelNumber.Digit > 0 && 13 > wheelNumber.Digit;
            else if (BetType.TwelveTwo == BetTypeTwelve)
                return wheelNumber.Digit > 12 && 25 > wheelNumber.Digit;
            else
                return wheelNumber.Digit > 24 && 37 > wheelNumber.Digit;
        }
    }
}
