using Roulette.Core;
using System.Collections.Generic;

namespace Roulette.UI
{
    public abstract class RouletteUI
    {
       

        public BetInput BetInput { get; protected set; }

        protected RouletteUI()
        {
        }

       

        public abstract void DisplayOptons();
        public abstract void DisplayAmount();
        internal abstract void OnDisplayResult(WheelNumber wheelNumber, bool isWinner);
        public abstract void SetInput(BetInput betInput);
        public abstract void PlayRulette();

        public abstract IList<BetDetails> GetAllBets();
        
    }
}
