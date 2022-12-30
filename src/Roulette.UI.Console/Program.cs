using Roulette.Core;
using System;

namespace Roulette.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();
            Console.WriteLine("WELCOME to Roulette Game!");
            Console.Write("Please enter your init amount money: "); 
            Console.ForegroundColor = ConsoleColor.Green;
            var amountInit = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();

            bool keepBetting = true;

            BetInput betInput = new BetInput();
            var rouletteUI = new Roulette.UI.RouletteUIConsole(amountInit);

            do
            {
                Console.WriteLine(Environment.NewLine);
                rouletteUI.DisplayAmount();
                rouletteUI.DisplayOptons();
                if (int.TryParse(Console.ReadLine(), out int userInput))
                {
                    switch (userInput)
                    {
                        case 1:
                            betInput = MenuOptions.BlackOrRed();
                            break;
                        case 2:
                            betInput = MenuOptions.OddOrEven();
                            break;
                        case 3:
                            betInput = MenuOptions.SingleNumber();
                            break;
                        case 4:
                            betInput = MenuOptions.TwelveOptions();
                            break;
                        case 5:
                            betInput = MenuOptions.OptionLowHigh();
                            break;
                        case 6:
                            var bets = rouletteUI.GetAllBets();
                            Console.WriteLine(new string('-', 80));
                            Console.WriteLine(string.Format("|{0,25}|{1,25}|{2,25}|", "Type", "Amount", "Winner"));
                            Console.WriteLine(new string('-', 80));
                            foreach (var bet in bets)
                            {
                                Console.WriteLine(string.Format("|{0,25}|{1,25}|{2,25}|", bet.BetType, bet.Amount, bet.IsWinner));
                            }
                            Console.WriteLine(new string('-', 80));
                            break;
                        case 7:
                            keepBetting = false;
                            break;
                        default:
                            MenuOptions.WronSelection();
                            break;
                    }                    

                    if(keepBetting && userInput != 6)
                    {
                        betInput.Amount = MenuOptions.GetAmount();
                        rouletteUI.SetInput(betInput);
                        rouletteUI.PlayRulette();
                    }                    
                }
                else
                {
                    MenuOptions.WronSelection();
                }

            } while (keepBetting);
        }        
    }
}
