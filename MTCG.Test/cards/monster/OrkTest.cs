using MTCG.cards.enums;
using MTCG.Cards.monster;
using NUnit.Framework;

namespace MTCG.Test.monster
{
    [TestFixture]
    public class OrkTest
    {
        private Ork _ork;
        private Wizard _wizard;

        [SetUp]
        public void Setup()
        {
            _ork = new Ork(CardType.Monster, ElementType.Normal, 190, "Ich bin Orrg und du?", CardProperty.Org);
            _wizard = new Wizard(CardType.Monster, ElementType.Fire, 200, "Ich bin ein Witz art", CardProperty.Wizard);
        }

        [Test]
        public void InitTest()
        {
            Assert.AreEqual(_ork.CardType, CardType.Monster);
            Assert.AreEqual(_ork.Element, ElementType.Normal);
            Assert.AreEqual(_ork.CardDamage, 190);
            Assert.AreEqual(_ork.CardName, "Ich bin Orrg und du?");
            Assert.AreEqual(_ork.CardProperty, CardProperty.Org);
        }

        [Test]
        public void ZeroAttackPoints()
        {
            Assert.AreEqual(_ork.GetCardDamagePoints(_wizard), 0);
        }
    }
}