namespace Roulette.Core.Bets
{
    public class OddEvenBet : Bet
    {
        public BetType BetTypeOddOrEven { get; }
        public OddEvenBet(BetType betType, double amount) : base(amount)
        {
            if (betType != BetType.Even && betType != BetType.Odd)
                throw new System.ArgumentException("Invalid value for betType");

            BetTypeOddOrEven = betType;
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
            if(BetType.Even == BetTypeOddOrEven)
                return wheelNumber.IsEven();
            return wheelNumber.IsOdd();
        }
    }
}
