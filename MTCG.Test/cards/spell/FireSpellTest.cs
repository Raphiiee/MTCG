using MTCG.cards.enums;
using MTCG.cards.monster;
using MTCG.cards.spell;
using NUnit.Framework;

namespace MTCG.Test.spell
{
    [TestFixture]
    public class FireSpellTest
    {
        private FireSpell _fireSpell;
        private Kraken _kraken;
        private Goblin _goblinWater;
        private Goblin _goblinNormal;

        [SetUp]
        public void Setup()
        {
            _fireSpell = new FireSpell(CardType.Spell, ElementType.Fire, 20, "Hotter Spell");
            _kraken = new Kraken(CardType.Monster, ElementType.Water, 170, "Krakie dakie do whatcha gonna do", CardProperty.Kraken);
            _goblinWater = new Goblin(CardType.Monster, ElementType.Water, 100, "Gobster the Robster", CardProperty.Goblin);
            _goblinNormal = new Goblin(CardType.Monster, ElementType.Normal, 100, "Gobster the Robster", CardProperty.Goblin);
        }

        [Test]
        public void InitTest()
        {
            Assert.AreEqual(CardType.Spell, _fireSpell.CardType);
            Assert.AreEqual(ElementType.Fire, _fireSpell.Element);
            Assert.AreEqual(20, _fireSpell.CardDamage);
            Assert.AreEqual("Hotter Spell", _fireSpell.CardName);
        }

        [Test]
        public void ZeroAttackPoints()
        {
            Assert.AreEqual(0, _fireSpell.GetCardDamagePoints(_kraken));
        }

        [Test]
        public void DoubleAttackPoints()
        {
            Assert.AreEqual(40, _fireSpell.GetCardDamagePoints(_goblinNormal));
        }

        [Test]
        public void HalfAttackPoints()
        {
            Assert.AreEqual(10, _fireSpell.GetCardDamagePoints(_goblinWater));
        }
    }
}