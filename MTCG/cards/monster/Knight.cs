using Cards;
using Enums;

namespace MTCG.Cards.monster
{
    public class Knight : BaseCards
    {
        public Knight() : base()
        {
            this.CardProperty = cardProperty.Knight;
            this.Element = elementType.Water;
            this.CardType = cardType.Monster;
        }
    }
}