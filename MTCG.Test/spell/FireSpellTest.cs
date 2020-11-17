using MTCG.cards.enums;
using MTCG.cards.spell;
using NUnit.Framework;

namespace MTCG.Test.spell
{
    [TestFixture]
    public class FireSpellTest
    {
        private FireSpell _fireSpell;
        [SetUp]
        public void Setup()
        {
            _fireSpell = new FireSpell(CardType.Spell, ElementType.Fire, 15, "Hotter Spell");
        }

        [Test]
        public void InitTest()
        {
            Assert.AreEqual(_fireSpell.CardType, CardType.Spell);
            Assert.AreEqual(_fireSpell.Element, ElementType.Fire);
            Assert.AreEqual(_fireSpell.CardDamage, 15);
            Assert.AreEqual(_fireSpell.CardName, "Hotter Spell");
        }
    }
}