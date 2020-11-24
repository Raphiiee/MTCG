using MTCG.cards.enums;

namespace MTCG.cards
{
    public abstract class BaseCards
    {
        public ElementType Element {  get; private set; }
        public CardProperty CardProperty { get; private set; }
        public CardType CardType { get; private set; }

        public int CardDamage { get; private set; }
        public string CardName { get; private set; }

        protected BaseCards(CardType cardType, ElementType element, int cardDamage, string cardName, CardProperty cardProperty)
        {
            this.CardType = cardType;
            this.Element = element;
            this.CardProperty = cardProperty;
            this.CardDamage = cardDamage;
            this.CardName = cardName;
        }

        // Effectiveness is used only by Spell Cards
        public int Effectiveness(BaseCards opponent)
        {
            if (this.Element == ElementType.Water && opponent.Element == ElementType.Fire)
            {
                return 1;
            }
            else if (this.Element == ElementType.Fire && opponent.Element == ElementType.Normal)
            {
                return 1;
            }
            else if (this.Element == ElementType.Normal && opponent.Element == ElementType.Water)
            {
                return 1;
            }
            else if (this.Element == ElementType.Fire && opponent.Element == ElementType.Water)
            {
                return -1;
            }
            else if (this.Element == ElementType.Normal && opponent.Element == ElementType.Fire)
            {
                return -1;
            }
            else if (this.Element == ElementType.Water && opponent.Element == ElementType.Normal)
            {
                return -1;
            }

            return 0;
        }

    }

}
