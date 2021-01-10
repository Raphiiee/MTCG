using MTCG.cards.enums;
using MTCG.cards.monster;
using NUnit.Framework;

namespace MTCG.Test.cards.monster
{
    [TestFixture]
    public class DragonTest
    {
        private Dragon _dragon;
        private FireElve _fireElve;

        [SetUp]
        public void Setup()
        {
            _dragon = new Dragon(CardType.Monster, ElementType.Fire, 10, "Drache oder so", CardProperty.Dragon,1);
            _fireElve = new FireElve(CardType.Monster, ElementType.Fire, 10, "Drache oder so", CardProperty.FireElve,1);
        }

        [Test]
        public void InitTest()
        {
            Assert.AreEqual(CardType.Monster, _dragon.CardType);
            Assert.AreEqual(ElementType.Fire, _dragon.Element);
            Assert.AreEqual(10, _dragon.CardDamage);
            Assert.AreEqual("Drache oder so", _dragon.CardName);
            Assert.AreEqual(CardProperty.Dragon, _dragon.CardProperty);
        }

        [Test]
        public void ZeroAttackPoints()
        {
            Assert.AreEqual(_dragon.GetCardDamagePoints(_fireElve), 0);
        }


    }
}