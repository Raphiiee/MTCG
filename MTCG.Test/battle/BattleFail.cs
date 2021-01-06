using NUnit.Framework;
using MTCG.battle;
namespace MTCG.Test.battle
{
    [TestFixture]
    public class FailTest
    {
        //private Dragon _dragon;
        //private FireElve _fireElve;
        private BattleHandler battle;

        [SetUp]
        public void Setup()
        {
            // _dragon = new Dragon(CardType.Monster, ElementType.Fire, 10, "Drache oder so", CardProperty.Dragon, 1);
            //_fireElve = new FireElve(CardType.Monster, ElementType.Fire, 10, "Drache oder so", CardProperty.FireElve, 1);
        }

        [Test]
        public void InitTest()
        {
            /*Assert.AreEqual(CardType.Monster, _dragon.CardType);
            Assert.AreEqual(ElementType.Fire, _dragon.Element);
            Assert.AreEqual(10, _dragon.CardDamage);
            Assert.AreEqual("Drache oder so", _dragon.CardName);
            Assert.AreEqual(CardProperty.Dragon, _dragon.CardProperty);*/
        }

        [Test]
        public void ZeroAttackPoints()
        {
            //Assert.AreEqual(_dragon.GetCardDamagePoints(_fireElve), 0);
        }


    }
}