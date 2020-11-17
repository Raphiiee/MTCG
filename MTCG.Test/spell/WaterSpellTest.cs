using Enums;
using MTCG.cards.spell;
using NUnit.Framework;

namespace MTCG.Test.spell
{
    [TestFixture]
    public class WaterSpellTest
    {
        private WaterSpell _waterSpell;
        [SetUp]
        public void Setup()
        {
            _waterSpell = new WaterSpell(CardType.Spell, ElementType.Water, 20, "Nasser Spell");
        }

        [Test]
        public void InitTest()
        {
            Assert.AreEqual(_waterSpell.CardType, CardType.Spell);
            Assert.AreEqual(_waterSpell.Element, ElementType.Water);
            Assert.AreEqual(_waterSpell.CardDamage, 20);
            Assert.AreEqual(_waterSpell.CardName, "Nasser Spell");
        }
    }
}