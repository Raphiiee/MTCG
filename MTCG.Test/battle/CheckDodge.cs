using NUnit.Framework;
using MTCG.battle;
using MTCG.cards;
using MTCG.cards.enums;

namespace MTCG.Test.battle
{
    [TestFixture]
    public class CheckDodgeTest
    {
        private BattleHandler _battle;
        private Card _goblin;
        private Card _ork;
        private Card _dragon;
        private Card _wizard;
        private Card _fireElve;
        private int _attackCardDamage;

        [SetUp]
        public void Setup()
        {
            _battle = new BattleHandler();
            _goblin = new Card(CardType.Spell, ElementType.Water, 100, "", CardProperty.Goblin, 1);
            _ork = new Card(CardType.Spell, ElementType.Fire, 100, "", CardProperty.Ork, 1);
            _dragon = new Card(CardType.Spell, ElementType.Normal, 100, "", CardProperty.Dragon, 1);
            _wizard = new Card(CardType.Monster, ElementType.Normal, 100, "", CardProperty.Wizard, 1);
            _fireElve = new Card(CardType.Monster, ElementType.Water, 100, "", CardProperty.FireElve, 1);
            _attackCardDamage = 100;
        }

        [Test]
        public void DodgeGoblin()
        {
            _battle.DodgeAttack(_goblin, _dragon, ref _attackCardDamage);
            Assert.AreEqual(0, _attackCardDamage);
        }

        [Test]
        public void DodgeOrk()
        {
            _battle.DodgeAttack(_ork, _wizard, ref _attackCardDamage);
            Assert.AreEqual(0, _attackCardDamage);
        }

        [Test]
        public void DodgeDragon()
        {
            _battle.DodgeAttack(_dragon, _fireElve, ref _attackCardDamage);
            Assert.AreEqual(0, _attackCardDamage);
        }

        [Test]
        public void NotDodge()
        {
            _battle.DodgeAttack(_dragon, _goblin, ref _attackCardDamage);
            Assert.AreEqual(100, _attackCardDamage);

            _battle.DodgeAttack(_wizard, _ork, ref _attackCardDamage);
            Assert.AreEqual(100, _attackCardDamage);

            _battle.DodgeAttack(_fireElve, _dragon, ref _attackCardDamage);
            Assert.AreEqual(100, _attackCardDamage);
        }



    }
}