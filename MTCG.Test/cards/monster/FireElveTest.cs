using MTCG.cards.enums;
using MTCG.Cards.monster;
using NUnit.Framework;

namespace MTCG.Test.monster
{
    [TestFixture]
    public class FireElveTest
    {
        private FireElve _fireElves;
        [SetUp]
        public void Setup()
        {
            _fireElves = new FireElve(CardType.Monster, ElementType.Fire, 10, "I am Fry the FireFly", CardProperty.FireElve);
        }

        [Test]
        public void InitTest()
        {
            Assert.AreEqual(CardType.Monster, _fireElves.CardType);
            Assert.AreEqual(ElementType.Fire, _fireElves.Element);
            Assert.AreEqual(10, _fireElves.CardDamage);
            Assert.AreEqual("I am Fry the FireFly", _fireElves.CardName);
            Assert.AreEqual(CardProperty.FireElve, _fireElves.CardProperty);
        }
    }
}