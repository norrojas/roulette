using Roulette.Core.Bets;
using Roulette.Data;
using System;
using System.Collections.Generic;

namespace Roulette.Core
{
    public class Player
    {
        public IList<Bet> Bets { get; private set; }

        private RepositoryRulette<BetDetails> _repositoryRulette;

        public double Money { get; private set; }

        public Bet CurrentBet { get; private set; }

        public Player()
        {
            _repositoryRulette = new RepositoryRulette<BetDetails>();
            Bets = new List<Bet>();
        }

        public Player(double money) : this()
        {
            AddMoney(money);
        }

        public void AddMoney(double amount)
        {
            Money += amount;
        }

        public void CreateBet(BetInput betInput)
        {
            if (Money < betInput.Amount)
                throw new Exception("You don't have money than request a bet");

            var bet = OnCreateBet(betInput);
            Bets.Add(bet);
            CurrentBet = bet;
            Money -= bet.Money;
        }

        private static Bet OnCreateBet(BetInput betInput)
        {

            switch (betInput.BetType)
            {
                case BetType.Red:
                    return new ColorBet(ColorType.Red, betInput.Amount);
                case BetType.Black:
                    return new ColorBet(ColorType.Blak, betInput.Amount);
                case BetType.SingleNumber:
                    return new SingleNumberBet(betInput.Number, betInput.Amount);
                case BetType.TwelveOne:
                case BetType.TwelveTwo:
                case BetType.TwelveThree:
                    return new TwelveBet(betInput.BetType, betInput.Amount);
                case BetType.Low:
                case BetType.High:
                    return new LowOrHighBet(betInput.BetType, betInput.Amount);
                default:
                    return new OddEvenBet(betInput.BetType, betInput.Amount);

            }

        }

        public void AddBet(Bet bet)
        {
            if (Money < bet.Money)
                throw new Exception("You don't have money than request bet");

            Bets.Add(bet);
            CurrentBet = bet;
            Money -= bet.Money;
        }

        public void SaveRound(BetInput betInput)
        {
            var newBetDetail = new BetDetails
            {
                Amount = betInput.Amount,
                BetType = betInput.BetType,
                IsWinner = CurrentBet.WasWin
            };
            _repositoryRulette.SaveBet(newBetDetail);
        }

        public void Reset()
        {
            Bets.Clear();
        }

        public IList<BetDetails> GetAllBets()
        {
            return _repositoryRulette.GetAllBets();
        }
    }

}
