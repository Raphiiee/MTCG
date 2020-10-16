using Cards;
using Enums;

namespace MTCG.Cards.monster
{
    public class Goblin : BaseCards
    {
        public Goblin() : base()
        {
            this.CardProperty = cardProperty.Goblin;
            this.Element = elementType.Water;
            this.CardType = cardType.Monster;
        }
    }
}