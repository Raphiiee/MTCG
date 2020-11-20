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
            _fireElves = new FireElve(CardType.Monster, ElementType.Fire, 10, "Drache oder so", CardProperty.FireElve, 100);
        }

        [Test]
        public void InitTest()
        {
            Assert.AreEqual(_fireElves.CardType, CardType.Monster);
            Assert.AreEqual(_fireElves.Element, ElementType.Fire);
            Assert.AreEqual(_fireElves.CardDamage, 10);
            Assert.AreEqual(_fireElves.CardName, "Drache oder so");
            Assert.AreEqual(_fireElves.CardProperty, CardProperty.FireElve);
            Assert.AreEqual(_fireElves.CardHealth, 100);
        }
    }
}