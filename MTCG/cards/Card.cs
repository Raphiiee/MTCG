using MTCG.cards.enums;

namespace MTCG.cards
{
    public class Card : BaseCards
    {
        public Card(CardType cardType, ElementType element, int cardDamage, string cardName, CardProperty cardProperty, int cardId)
            : base(cardType, element, cardDamage, cardName, cardProperty, cardId)
        {

        }
    }
}