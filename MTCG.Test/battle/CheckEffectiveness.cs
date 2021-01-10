using NUnit.Framework;
using MTCG.battle;
using MTCG.cards;
using MTCG.cards.enums;

namespace MTCG.Test.battle
{
    [TestFixture]
    public class CheckEffectivenessTest
    {
        private BattleHandler _battle;
        private Card _attackSpellWater;
        private Card _attackSpellFire;
        private Card _attackSpellNormal;
        private Card _attackMonster;
        private Card _defenderKraken;
        private Card _defenderKnight;
        private Card _defenderWater;
        private Card _defenderFire;
        private Card _defenderNormal;
        private int _attackCardDamage;

        [SetUp]
        public void Setup()
        {
            _battle = new BattleHandler();
            _attackSpellWater = new Card(CardType.Spell, ElementType.Water, 100, "", 0, 1);
            _attackSpellFire = new Card(CardType.Spell, ElementType.Fire, 100, "", 0, 1);
            _attackSpellNormal = new Card(CardType.Spell, ElementType.Normal, 100, "", 0, 1);
            _attackMonster = new Card(CardType.Monster, ElementType.Normal, 100, "", CardProperty.Dragon, 1);
            _defenderKraken = new Card(CardType.Monster, ElementType.Water, 100, "", CardProperty.Kraken, 1);
            _defenderKnight = new Card(CardType.Monster, ElementType.Normal, 100, "", CardProperty.Knight, 1);
            _defenderWater = new Card(CardType.Monster, ElementType.Water, 100, "", CardProperty.Dragon, 1);
            _defenderFire = new Card(CardType.Monster, ElementType.Fire, 100, "", CardProperty.Dragon, 1);
            _defenderNormal = new Card(CardType.Monster, ElementType.Normal, 100, "", CardProperty.Dragon, 1);
            _attackCardDamage = 100;
        }

        [Test]
        public void SpecialDefenderKraken()
        {
            _battle.Effectiveness(_attackSpellWater, _defenderKraken, ref _attackCardDamage);
            Assert.AreEqual(0, _attackCardDamage);
        }

        [Test]
        public void SpecialDefenderKnight()
        {
            _battle.Effectiveness(_attackSpellWater, _defenderKnight, ref _attackCardDamage);
            Assert.AreEqual(10000, _attackCardDamage);
        }

        [Test]
        public void Effective()
        {
            _battle.Effectiveness(_attackSpellWater, _defenderFire, ref _attackCardDamage);
            Assert.AreEqual(200, _attackCardDamage);
            _attackCardDamage = 100;

            _battle.Effectiveness(_attackSpellFire, _defenderNormal, ref _attackCardDamage);
            Assert.AreEqual(200, _attackCardDamage);
            _attackCardDamage = 100;

            _battle.Effectiveness(_attackSpellNormal, _defenderWater, ref _attackCardDamage);
            Assert.AreEqual(200, _attackCardDamage);
            _attackCardDamage = 100;
        }

        [Test]
        public void NotEffective()
        {
            _battle.Effectiveness(_attackSpellWater, _defenderNormal, ref _attackCardDamage);
            Assert.AreEqual(100, _attackCardDamage);
            _attackCardDamage = 100;

            _battle.Effectiveness(_attackSpellFire, _defenderWater, ref _attackCardDamage);
            Assert.AreEqual(100, _attackCardDamage);
            _attackCardDamage = 100;

            _battle.Effectiveness(_attackSpellNormal, _defenderFire, ref _attackCardDamage);
            Assert.AreEqual(100, _attackCardDamage);
            _attackCardDamage = 100;

            _battle.Effectiveness(_attackMonster, _defenderFire, ref _attackCardDamage);
            Assert.AreEqual(100, _attackCardDamage);
            _attackCardDamage = 100;
        }
    }
}