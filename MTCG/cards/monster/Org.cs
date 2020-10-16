using Cards;
using Enums;

namespace MTCG.Cards.monster
{
    public class Org : BaseCards
    {
        public Org() : base()
        {
            this.CardProperty = cardProperty.Org;
            this.Element = elementType.Normal;
            this.CardType = cardType.Monster;
        }
    }
}