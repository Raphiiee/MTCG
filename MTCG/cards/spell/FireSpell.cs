using Cards;
using Enums;

namespace MTCG.cards.spell
{
    public class FireSpell : BaseCards
    {
        public FireSpell() : base()
        {
            this.CardType = cardType.Spell;
            this.Element = elementType.Fire;
        }
    }
}