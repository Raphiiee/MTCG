using NUnit.Framework;
using MTCG.battle;
namespace MTCG.Test.battle
{
    [TestFixture]
    public class CheckCardsInStackTest
    {
        private BattleHandler _battle;

        [SetUp]
        public void Setup()
        {
            _battle = new BattleHandler();
        }

        [Test]
        public void PlayerWithNoCards()
        {
            Assert.AreEqual(false, _battle.LoadUserDecks("test", "test_with_no_cards"));
        }

        [Test]
        public void PlayerWithLessThanFour()
        {
            Assert.AreEqual(false, _battle.LoadUserDecks("test", "test_less_cards"));
        }

        [Test]
        public void PlayerWithFour()
        {
            Assert.AreEqual(true, _battle.LoadUserDecks("test", "fest"));
        }
    }
}