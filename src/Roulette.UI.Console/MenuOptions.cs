using Roulette.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.UI
{
    public static class MenuOptions
    {
        public static BetInput BlackOrRed()
        {
            BetType betType = BetType.Black;
            Console.WriteLine($"Please select a one option:\n" +
                              $"1. Black\n" +
                              $"2. Red\n");
            int colorInput = GetSelectedOption(1,2);

            if (colorInput == 2) betType = BetType.Red;
            return new BetInput { BetType = betType };
        }

        public static BetInput OddOrEven()
        {
            BetType betType = BetType.Odd;
            Console.WriteLine($"Please select a one option:\n" +
                              $"1. Odd\n" +
                              $"2. Even\n");
            int colorInput = GetSelectedOption(1, 2);

            if (colorInput == 2) betType = BetType.Even;
            return new BetInput { BetType = betType };
        }

        public static BetInput SingleNumber()
        {
            Console.Write($"Please insert your number: ");
            var singleNumber = GetSelectedOption(1, 36);
            return new BetInput { BetType = BetType.SingleNumber, Number = singleNumber };
        }

        public static BetInput TwelveOptions()
        {
            BetType betType = BetType.TwelveOne;
            Console.WriteLine($"Please select a one option:\n" +
                               $"1. 1er 12 (1-12)\n" +
                               $"2. 2º 12(13-24)\n" +
                               $"3. 3er 12(25-36)\n");

            int twelveInput = GetSelectedOption(1, 3);
           
            if (twelveInput == 2) betType = BetType.TwelveTwo;
            else if (twelveInput == 3) betType = BetType.TwelveThree;
            return new BetInput { BetType = betType };

        }

        public static BetInput OptionLowHigh()
        {
            BetType betType = BetType.Low;

            Console.WriteLine($"Please select a one option:\n" +
                               $"1. Low\n" +
                               $"2. High\n");

            int lowOrHighInput = GetSelectedOption(1, 2);

            if (lowOrHighInput == 2) betType = BetType.High;
            return new BetInput { BetType = betType };
        }


        public static double GetAmount()
        {
            double amount;
            do
            {
                Console.Write("Please enter amount for your bet: ");
                Console.ForegroundColor = ConsoleColor.Green;
                if (!double.TryParse(Console.ReadLine(), out amount))
                    Console.WriteLine("\nWrong input, please insert valid amount");
            }
            while (amount == 0);
            Console.ResetColor();
            return amount;
        }

        private static int GetSelectedOption(int min, int max)
        {
            int inputOption;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out inputOption))
                    WronSelection();
                if (inputOption < min || inputOption > max)
                {
                    WronSelection();
                    inputOption = 0;
                }
            }
            while (inputOption == 0);
            return inputOption;
        }

        public static void WronSelection()
        {
            Console.WriteLine("Wrong selection. Lets try that again...");
            //Console.ReadLine();
        }
    }
}
