using NUnit.Framework;
using Roulette.Core;
using Roulette.Core.Bets;
using System;
using System.Linq;

namespace Roulette.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        [TestCase(2.6)]
        public void AddMoneShouldBeEqual(double amount)
        {
            var player = new Player();
            player.AddMoney(amount);

            Assert.That(player.Money, Is.EqualTo(amount));
        }

        [Test]
        [TestCase(BetType.Red, 20)]
        [TestCase(BetType.Red, 10)]
        public void MakeRedBet(BetType betType, double amount)
        {
            var initAmount = 50;
            var betInput = new BetInput { BetType = betType, Amount = amount };

            var player = new Player();
            player.AddMoney(initAmount);
            player.CreateBet(betInput);

            Assert.That(((ColorBet)player.Bets.First()).ColorTypeBet, Is.EqualTo(ColorType.Red));
            Assert.That(player.Bets.First().Money, Is.EqualTo(amount));
        }

        [Test]
        [TestCase(BetType.SingleNumber, 15, 5)]
        public void MakeNumberBet(BetType betType, double amount, int numberBet)
        {
            var initAmount = 50;
            var betInput = new BetInput { BetType = betType, Amount = amount, Number = numberBet };

            var player = new Player();
            player.AddMoney(initAmount);
            player.CreateBet(betInput);

            Assert.That(((SingleNumberBet)player.Bets.First()).Number, Is.EqualTo(numberBet));
            Assert.That(player.Bets.First().Money, Is.EqualTo(amount));
        }


        [Test]
        [TestCase(BetType.Odd, 10)]
        public void MakeOddBet(BetType betType, double amount)
        {
            var initAmount = 50;
            var betInput = new BetInput { BetType = betType, Amount = amount };

            var player = new Player();
            player.AddMoney(initAmount);
            player.CreateBet(betInput);

            Assert.That(((OddEvenBet)player.Bets.First()).BetTypeOddOrEven, Is.EqualTo(BetType.Odd));
            Assert.That(player.Bets.First().Money, Is.EqualTo(amount));
        }

        [Test]
        [TestCase(BetType.TwelveOne, 5)]
        public void MakeTwelveBet(BetType betType, double amount)
        {
            var initAmount = 50;
            var betInput = new BetInput { BetType = betType, Amount = amount };

            var player = new Player();
            player.AddMoney(initAmount);
            player.CreateBet(betInput);

            Assert.That(((TwelveBet)player.Bets.First()).BetTypeTwelve, Is.EqualTo(BetType.TwelveOne));
            Assert.That(player.Bets.First().Money, Is.EqualTo(amount));
        }


        [Test]
        [TestCase(BetType.High, 5)]
        public void MakeHighBet(BetType betType, double amount)
        {
            var initAmount = 50;
            var betInput = new BetInput { BetType = betType, Amount = amount };

            var player = new Player();
            player.AddMoney(initAmount);
            player.CreateBet(betInput);

            Assert.That(((LowOrHighBet)player.Bets.First()).BetTypeLowOrHigh, Is.EqualTo(BetType.High));
            Assert.That(player.Bets.First().Money, Is.EqualTo(amount));
        }

        [Test]
        [TestCase(BetType.High, 16.89)]
        public void ThrowExceptionIfDontHaveMoney(BetType betType, double amount)
        {
            var betInput = new BetInput { BetType = betType, Amount = amount };

            var player = new Player();

            TestDelegate testDelegate = () => player.CreateBet(betInput);

            Assert.Throws<Exception>(testDelegate, "You don't have money than request a bet");
        }
    }
}
