using Cards;
using Enums;

namespace MTCG.Cards.monster
{
    public class Kraken : BaseCards
    {
        public Kraken() : base()
        {
            this.CardProperty = cardProperty.Kraken;
            this.Element = elementType.Fire;
            this.CardType = cardType.Monster;
        }
    }
}