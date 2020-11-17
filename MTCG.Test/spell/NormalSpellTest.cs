using Enums;
using MTCG.cards.spell;
using NUnit.Framework;

namespace MTCG.Test.spell
{
    [TestFixture]
    public class NormalSpellTest
    {
        private NormalSpell _normalSpell;
        [SetUp]
        public void Setup()
        {
            _normalSpell = new NormalSpell(CardType.Spell, ElementType.Normal, 10, "Normal Spell");
        }

        [Test]
        public void InitTest()
        {
            Assert.AreEqual(_normalSpell.CardType, CardType.Spell);
            Assert.AreEqual(_normalSpell.Element, ElementType.Normal);
            Assert.AreEqual(_normalSpell.CardDamage, 10);
            Assert.AreEqual(_normalSpell.CardName, "Normal Spell");
        }
    }
}