using MTCG.cards.enums;
using MTCG.Cards.monster;
using NUnit.Framework;

namespace MTCG.Test.monster
{
    [TestFixture]
    public class KrakenTest
    {
        private Kraken _kraken;
        [SetUp]
        public void Setup()
        {
            _kraken = new Kraken(CardType.Monster, ElementType.Water, 170, "Krakie dakie do whatcha gonna do", CardProperty.Kraken, 100);
        }

        [Test]
        public void InitTest()
        {
            Assert.AreEqual(_kraken.CardType, CardType.Monster);
            Assert.AreEqual(_kraken.Element, ElementType.Water);
            Assert.AreEqual(_kraken.CardDamage, 170);
            Assert.AreEqual(_kraken.CardName, "Krakie dakie do whatcha gonna do");
            Assert.AreEqual(_kraken.CardProperty, CardProperty.Kraken);
            Assert.AreEqual(_kraken.CardHealth, 100);
        }
    }
}