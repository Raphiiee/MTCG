using MTCG.cards.enums;
using MTCG.cards.monster;
using MTCG.cards.spell;
using NUnit.Framework;

namespace MTCG.Test.spell
{
    [TestFixture]
    public class WaterSpellTest
    {
        private WaterSpell _waterSpell;
        private Kraken _kraken;
        private Goblin _goblinFire;
        private Goblin _goblinNormal;

        [SetUp]
        public void Setup()
        {
            _waterSpell = new WaterSpell(CardType.Spell, ElementType.Water, 20, "Nasser Spell");
            _kraken = new Kraken(CardType.Monster, ElementType.Water, 170, "Krakie dakie do whatcha gonna do", CardProperty.Kraken);
            _goblinFire = new Goblin(CardType.Monster, ElementType.Fire, 100, "Gobster the Robster", CardProperty.Goblin);
            _goblinNormal = new Goblin(CardType.Monster, ElementType.Normal, 100, "Gobster the Robster", CardProperty.Goblin);
        }

        [Test]
        public void InitTest()
        {
            Assert.AreEqual(CardType.Spell, _waterSpell.CardType);
            Assert.AreEqual(ElementType.Water, _waterSpell.Element);
            Assert.AreEqual(20, _waterSpell.CardDamage);
            Assert.AreEqual("Nasser Spell", _waterSpell.CardName);
        }

        [Test]
        public void ZeroAttackPoints()
        {
            Assert.AreEqual(0, _waterSpell.GetCardDamagePoints(_kraken));
        }

        [Test]
        public void DoubleAttackPoints()
        {
            Assert.AreEqual(40, _waterSpell.GetCardDamagePoints(_goblinFire));
        }

        [Test]
        public void HalfAttackPoints()
        {
            Assert.AreEqual(10, _waterSpell.GetCardDamagePoints(_goblinNormal));
        }
    }
}