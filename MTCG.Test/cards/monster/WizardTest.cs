﻿using MTCG.cards.enums;
using MTCG.cards.monster;
using NUnit.Framework;

namespace MTCG.Test.cards.monster
{
    [TestFixture]
    public class WizardTest
    {
        private Wizard _wizard;
        [SetUp]
        public void Setup()
        {
            _wizard = new Wizard(CardType.Monster, ElementType.Fire, 200, "Ich bin ein Witz art", CardProperty.Wizard,1);
        }

        [Test]
        public void InitTest()
        {
            Assert.AreEqual(_wizard.CardType, CardType.Monster);
            Assert.AreEqual(_wizard.Element, ElementType.Fire);
            Assert.AreEqual(_wizard.CardDamage, 200);
            Assert.AreEqual(_wizard.CardName, "Ich bin ein Witz art");
            Assert.AreEqual(_wizard.CardProperty, CardProperty.Wizard);
        }
    }
}