using Cards;
using Enums;

namespace MTCG.Cards.monster
{
    public class Dragon : BaseCards
    {
        public Dragon() : base()
        {
            this.CardProperty = cardProperty.Dragon;
            this.Element = elementType.Fire;
            this.CardType = cardType.Monster;
        }
    }
}