using Cards;
using Enums;

namespace MTCG.Cards.monster
{
    public class Wizard : BaseCards
    {
        public Wizard() : base()
        {
            this.CardProperty = cardProperty.Wizard;
            this.Element = elementType.Fire;
            this.CardType = cardType.Monster;
        }
    }
}