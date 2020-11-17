using MTCG.cards.enums;
using MTCG.Cards.monster;
using NUnit.Framework;

namespace MTCG.Test.monster
{
    [TestFixture]
    public class Tests
    {
        private Dragon _dragon;
        [SetUp]
        public void Setup()
        {
            _dragon = new Dragon(CardType.Monster, ElementType.Fire, CardProperty.Dragon, 10, "Drache oder so");
        }

        [Test]
        public void InitTest()
        {
            Assert.AreEqual(_dragon.CardType, CardType.Monster);
            Assert.AreEqual(_dragon.Element, ElementType.Fire);
            Assert.AreEqual(_dragon.CardProperty, CardProperty.Dragon);
            Assert.AreEqual(_dragon.CardDamage, 10);
            Assert.AreEqual(_dragon.CardName, "Drache oder so");
        }
    }
}