using MTCG.cards.enums;

namespace MTCG.cards.monster
{
    public class Knight : BaseCards
    {
        public Knight(CardType cardType, ElementType element, int cardDamage, string cardName, CardProperty cardProperty)
            : base(cardType, element, cardDamage, cardName, cardProperty)
        {

        }

        public int GetCardDamagePoints(BaseCards opponent)
        {
            if (opponent.CardType == CardType.Spell && opponent.Element == ElementType.Water)
            {
                return 0;
            }

            return this.CardDamage;
        }
    }
}