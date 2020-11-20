using MTCG.cards.enums;
using MTCG.Cards.monster;
using NUnit.Framework;

namespace MTCG.Test.monster
{
    [TestFixture]
    public class GoblinTest
    {
        private Goblin _goblin;
        [SetUp]
        public void Setup()
        {
            _goblin = new Goblin(CardType.Monster, ElementType.Fire, 100, "Gobster the Robster", CardProperty.Goblin, 100);
        }

        [Test]
        public void InitTest()
        {
            Assert.AreEqual(_goblin.CardType, CardType.Monster);
            Assert.AreEqual(_goblin.Element, ElementType.Fire);
            Assert.AreEqual(_goblin.CardDamage, 100);
            Assert.AreEqual(_goblin.CardName, "Gobster the Robster");
            Assert.AreEqual(_goblin.CardProperty, CardProperty.Goblin);
            Assert.AreEqual(_goblin.CardHealth, 100);
        }
    }
}