using Enums;
using MTCG.Cards.monster;
using NUnit.Framework;

namespace MTCG.Test.monster
{
    [TestFixture]
    public class OrgTest
    {
        private Org _org;
        [SetUp]
        public void Setup()
        {
            _org = new Org(CardType.Monster, ElementType.Normal, CardProperty.Org, 190, "Ich bin Orrg und du?");
        }

        [Test]
        public void InitTest()
        {
            Assert.AreEqual(_org.CardType, CardType.Monster);
            Assert.AreEqual(_org.Element, ElementType.Normal);
            Assert.AreEqual(_org.CardProperty, CardProperty.Org);
            Assert.AreEqual(_org.CardDamage, 190);
            Assert.AreEqual(_org.CardName, "Ich bin Orrg und du?");
        }
    }
}