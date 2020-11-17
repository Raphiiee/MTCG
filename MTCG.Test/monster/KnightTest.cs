using MTCG.cards.enums;
using MTCG.Cards.monster;
using NUnit.Framework;

namespace MTCG.Test.monster
{
    [TestFixture]
    public class KnightTest
    {
        private Knight _knight;
        [SetUp]
        public void Setup()
        {
            _knight = new Knight(CardType.Monster, ElementType.Normal, CardProperty.Knight, 150, "Knight in the Night, just Right");
        }

        [Test]
        public void InitTest()
        {
            Assert.AreEqual(_knight.CardType, CardType.Monster);
            Assert.AreEqual(_knight.Element, ElementType.Normal);
            Assert.AreEqual(_knight.CardProperty, CardProperty.Knight);
            Assert.AreEqual(_knight.CardDamage, 150);
            Assert.AreEqual(_knight.CardName, "Knight in the Night, just Right");
        }
    }
}