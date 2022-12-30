namespace Roulette.Core.Bets
{
    public class ColorBet : Bet
    {
        public ColorType ColorTypeBet { get;  }
        public ColorBet(ColorType colorTypeBet, double amount) : base(amount)
        {
            ColorTypeBet = colorTypeBet;
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
            return wheelNumber.ColorType == ColorTypeBet;
        }
    }
}
