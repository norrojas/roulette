namespace Roulette.Core
{
    public class WheelNumber
    {
        /// <summary>
        /// Represents a digit of Number
        /// </summary>
        public int Digit { get; set; }

        /// <summary>
        /// Represents a color of Number
        /// </summary>
        public ColorType ColorType { get; set; }

        public bool IsEven()
        {
            return Digit % 2 == 0;
        }

        public bool IsOdd()
        {
            return !IsEven();
        }

        public WheelNumber(int digit, ColorType colorType)
        {
            Digit = digit;
            ColorType = colorType;
        }
    }
}
