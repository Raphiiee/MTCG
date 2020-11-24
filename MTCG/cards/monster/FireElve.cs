using MTCG.cards;
using MTCG.cards.enums;

namespace MTCG.Cards.monster
{
    public class FireElve : BaseCards
    {
        public FireElve(CardType cardType, ElementType element, int cardDamage, string cardName, CardProperty cardProperty)
            : base(cardType, element, cardDamage, cardName, cardProperty)
        {

        }

        public int GetCardDamagePoints(BaseCards opponent)
        {
            return this.CardDamage;
        }
    }
}