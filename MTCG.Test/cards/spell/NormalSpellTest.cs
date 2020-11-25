﻿using MTCG.cards.enums;
using MTCG.Cards.monster;
using MTCG.cards.spell;
using NUnit.Framework;

namespace MTCG.Test.spell
{
    [TestFixture]
    public class NormalSpellTest
    {
        private NormalSpell _normalSpell;
        private Kraken _kraken;
        private Goblin _goblinFire;
        private Goblin _goblinWater;
        private Goblin _goblinNormal;

        [SetUp]
        public void Setup()
        {
            _normalSpell = new NormalSpell(CardType.Spell, ElementType.Normal, 20, "Normal Spell");
            _kraken = new Kraken(CardType.Monster, ElementType.Water, 170, "Krakie dakie do whatcha gonna do", CardProperty.Kraken);
            _goblinFire = new Goblin(CardType.Monster, ElementType.Fire, 100, "Gobster the Robster", CardProperty.Goblin);
            _goblinWater = new Goblin(CardType.Monster, ElementType.Water, 100, "Gobster the Robster", CardProperty.Goblin);
        }

        [Test]
        public void InitTest()
        {
            Assert.AreEqual(CardType.Spell, _normalSpell.CardType);
            Assert.AreEqual(ElementType.Normal, _normalSpell.Element);
            Assert.AreEqual(20, _normalSpell.CardDamage);
            Assert.AreEqual("Normal Spell", _normalSpell.CardName);
        }

        [Test]
        public void ZeroAttackPoints()
        {
            Assert.AreEqual(0, _normalSpell.GetCardDamagePoints(_kraken));
        }

        [Test]
        public void DoubleAttackPoints()
        {
            Assert.AreEqual(40, _normalSpell.GetCardDamagePoints(_goblinWater));
        }

        [Test]
        public void HalfAttackPoints()
        {
            Assert.AreEqual(10, _normalSpell.GetCardDamagePoints(_goblinFire));
        }
    }
}