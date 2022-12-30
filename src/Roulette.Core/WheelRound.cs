using Roulette.Core.Bets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Roulette.Core
{
    public class WheelRound
    {
        private ICollection<WheelNumber> Numbers { get; }

        public WheelNumber WinningNumber { get; private set; }


        public double Amount { get; set; }


        public WheelRound()
        {
            Numbers = new List<WheelNumber>();
            BindNumbers();
        }

        public WheelNumber GenerateRandomValue()
        {
            var result = new Random().Next(-1, 36);
            var winNumber = Numbers.FirstOrDefault(n => n.Digit == result);

            if (winNumber == null) return new WheelNumber(-1, ColorType.Green); // default
            WinningNumber = winNumber;
            return winNumber;
        }

        private void BindNumbers()
        {
            for (int i = -1; i < 37; i++)
            {
                if (i < 1)
                    Numbers.Add(new WheelNumber(i, ColorType.Green));
                else if (i % 2 == 0)
                    Numbers.Add(new WheelNumber(i, ColorType.Red));
                else
                    Numbers.Add(new WheelNumber(i, ColorType.Blak));
            }
        }
    }
}
