using Roulette.Core;
using System;
using System.Collections.Generic;

namespace Roulette.UI
{
    public class RouletteUIConsole : RouletteUI
    {
        public double AmountInit { get; private set; }
        public Roulette.Core.Roulette Roulette { get; private set; }
        public RouletteUIConsole(double amountInit) : base()
        {
            AmountInit = amountInit;
        }

        public override void DisplayOptons()
        {
            Console.WriteLine($"Select a bet to make:\n\n" +
                $"1. Black or Red\n" +
                $"2. Even or Odd\n" +
                $"3. Single number\n" +
                $"4. 1er 12 (1-12), 2º 12(13-24), 3er 12(25-36) \n" +
                $"5. High or Low\n" +
                $"6. Show bet history\n" +
                $"7. Stop");
        }

        public override void DisplayAmount()
        {
            Console.Write("Your balance is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"${AmountInit}");
            Console.ResetColor();
        }

        public override void PlayRulette()
        {
            Roulette = new Core.Roulette(this.AmountInit);
            Roulette.OnWiningNumberEvent += Roulete_OnWiningNumberEvent;
            Roulette.OnUpdatePlayerAmountEvent += Roulete_OnUpdatePlayerAmountEvent;
            Roulette.OnShowErrorMessage += Roulette_OnShowErrorMessage;
            Roulette.StartRound(BetInput);
        }

        private void Roulette_OnShowErrorMessage(Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message);
        }

        private void Roulete_OnUpdatePlayerAmountEvent(double amount)
        {
            AmountInit = amount;
            if (AmountInit == 0)
                Console.WriteLine("You don't have money :(");
        }

        private void Roulete_OnWiningNumberEvent(Core.WheelNumber wheelNumber, bool isWinner)
        {
            OnDisplayResult(wheelNumber, isWinner);
        }

        public override void SetInput(BetInput betInput)
        {
            BetInput = betInput;
        }

        internal override void OnDisplayResult(Core.WheelNumber wheelNumber, bool isWinner)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Yout bet is: {BetInput.BetType} " +
                $"{(BetInput.BetType == BetType.SingleNumber ?  BetInput.Number : string.Empty)} " +
                $"with amount ${BetInput.Amount}");
            Console.WriteLine($"Result: {wheelNumber.Digit} {wheelNumber.ColorType}");

            if(isWinner)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your win!!!!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Your lose :(");
            }
            
            Console.ResetColor();
        }

        public override IList<BetDetails> GetAllBets()
        {
            return Roulette.Player.GetAllBets();
        }
    }
}
