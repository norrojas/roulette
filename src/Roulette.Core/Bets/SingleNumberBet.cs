using System;

namespace Roulette.Core.Bets
{
    public class SingleNumberBet : Bet
    {
        public int Number { get; }
        public SingleNumberBet(int number, double amount) : base(amount)
        {
            Number = number;
        }

        public override double CalculateAmount(WheelNumber wheelNumber)
        {
            if(IsWon(wheelNumber))
            {
                WasWin = true;
                return Money * 35;

            }
            return 0;
        }

        protected override bool IsWon(WheelNumber wheelNumber)
        {
            return Number == wheelNumber.Digit;
        }
    }
}
