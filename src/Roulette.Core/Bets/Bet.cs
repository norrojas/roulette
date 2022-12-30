namespace Roulette.Core
{
    public abstract class Bet
    {
        public double Money { get; }

        internal bool WasWin { get; set; }

        protected Bet(double money)
        {
            Money = money;
        }

        
        protected abstract bool IsWon(WheelNumber wheelNumber);

        public abstract double CalculateAmount(WheelNumber wheelNumber);
    }

}
