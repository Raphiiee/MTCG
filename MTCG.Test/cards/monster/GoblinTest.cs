﻿using MTCG.cards.enums;
using MTCG.Cards.monster;
using NUnit.Framework;

namespace MTCG.Test.monster
{
    [TestFixture]
    public class GoblinTest
    {
        private Goblin _goblin;
        private Dragon _dragon;

        [SetUp]
        public void Setup()
        {
            _goblin = new Goblin(CardType.Monster, ElementType.Fire, 100, "Gobster the Robster", CardProperty.Goblin);
            _dragon = new Dragon(CardType.Monster, ElementType.Fire, 10, "Drache oder so", CardProperty.Dragon);
        }

        [Test]
        public void InitTest()
        {
            Assert.AreEqual(CardType.Monster, _goblin.CardType);
            Assert.AreEqual(ElementType.Fire, _goblin.Element);
            Assert.AreEqual(100, _goblin.CardDamage);
            Assert.AreEqual("Gobster the Robster", _goblin.CardName);
            Assert.AreEqual(CardProperty.Goblin, _goblin.CardProperty);
        }

        [Test]
        public void ZeroAttackPoints()
        {
            Assert.AreEqual(_goblin.GetCardDamagePoints(_dragon), 0);
        }
    }
}