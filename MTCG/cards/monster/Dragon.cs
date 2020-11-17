using Cards;
using MTCG.cards.enums;

namespace MTCG.Cards.monster
{
    public class Dragon : BaseCards
    {
        public Dragon(CardType cardType, ElementType element, CardProperty cardProperty, int cardDamage, string cardName)
            : base(cardType, element, cardProperty, cardDamage, cardName)
        {

        }
    }
}