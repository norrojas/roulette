using System.Collections.Generic;

namespace Roulette.Data
{
    public class RepositoryRulette<T>
    {
        public void DeleteAll()
        {
            RuletteData<T>.DataBets.Clear();
        }

        public IList<T> GetAllBets()
        {
            return RuletteData<T>.DataBets;
        }

        public void SaveBet(T bet)
        {
            RuletteData<T>.DataBets.Add(bet);
        }
    }
}
