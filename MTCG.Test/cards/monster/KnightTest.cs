using MTCG.cards.enums;
using MTCG.cards.monster;
using MTCG.cards.spell;
using NUnit.Framework;

namespace MTCG.Test.cards.monster
{
    [TestFixture]
    public class KnightTest
    {
        private Knight _knight;
        private WaterSpell _waterSpell;

        [SetUp]
        public void Setup()
        {
            _knight = new Knight(CardType.Monster, ElementType.Normal, 150, "Knight in the Night, just Right", CardProperty.Knight,1);
            _waterSpell = new WaterSpell(CardType.Spell, ElementType.Water, 20, "Nasser Spell",0,1);
        }

        [Test]
        public void InitTest()
        {
            Assert.AreEqual(CardType.Monster, _knight.CardType);
            Assert.AreEqual(ElementType.Normal, _knight.Element);
            Assert.AreEqual(150, _knight.CardDamage);
            Assert.AreEqual("Knight in the Night, just Right", _knight.CardName);
            Assert.AreEqual(CardProperty.Knight, _knight.CardProperty);
        }

        [Test]
        public void ZeroAttackPoints()
        {
            Assert.AreEqual(0, _knight.GetCardDamagePoints(_waterSpell));
        }
    }
}