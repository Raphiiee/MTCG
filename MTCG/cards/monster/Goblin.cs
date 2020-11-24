using MTCG.cards;
using MTCG.cards.enums;

namespace MTCG.Cards.monster
{
    public class Goblin : BaseCards
    {
        public Goblin(CardType cardType, ElementType element, int cardDamage, string cardName, CardProperty cardProperty)
            : base(cardType, element, cardDamage, cardName, cardProperty)
        {

        }

        public int GetCardDamagePoints(BaseCards opponent)
        {
            if (opponent.CardProperty == CardProperty.Dragon)
            {
                return 0;
            }

            return this.CardDamage;
        }
    }
}