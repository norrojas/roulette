using System.Linq;

namespace Roulette.Core
{
    public class Roulette
    {
        #region events

        public event WiningNumberEvent OnWiningNumberEvent;
        public event UpdatePlayerAmount OnUpdatePlayerAmountEvent;
        public event ShowErrorMessage OnShowErrorMessage;

        #endregion
        public Player Player { get; }
        public WheelRound Round { get; private set; }

        public Roulette(double initialMoney)
        {
            Player = new Player(initialMoney);            
        }

        public void StartRound(BetInput betInput)
        {
            try
            {
                Player.CreateBet(betInput);
                Play();
                Player.SaveRound(betInput);
            }
            catch (System.Exception ex)
            {
                OnShowErrorMessage?.Invoke(ex);
            }
        }
        

        private void Play()
        {
            Round = new WheelRound();
            var generateRandomResult = Round.GenerateRandomValue();

            var currentMoney = Player.Bets.Sum(b => b.CalculateAmount(generateRandomResult));
            OnWiningNumberEvent?.Invoke(generateRandomResult, Player.CurrentBet.WasWin);

            Player.AddMoney(currentMoney);
            OnUpdatePlayerAmountEvent?.Invoke(Player.Money);
        }

        
    }
}
