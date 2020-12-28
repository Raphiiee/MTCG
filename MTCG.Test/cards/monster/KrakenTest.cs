using MTCG.cards.enums;
using MTCG.cards.monster;
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
            _kraken = new Kraken(CardType.Monster, ElementType.Water, 170, "Krakie dakie do whatcha gonna do", CardProperty.Kraken);
        }

        [Test]
        public void InitTest()
        {
            Assert.AreEqual(CardType.Monster, _kraken.CardType);
            Assert.AreEqual(ElementType.Water, _kraken.Element);
            Assert.AreEqual(170, _kraken.CardDamage);
            Assert.AreEqual("Krakie dakie do whatcha gonna do", _kraken.CardName);
            Assert.AreEqual(CardProperty.Kraken, _kraken.CardProperty);
        }

    }
}