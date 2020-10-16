using Cards;
using Enums;

namespace MTCG.cards.spell
{
    public class NormalSpell : BaseCards
    {
        public NormalSpell() : base()
        {
            this.CardType = cardType.Spell;
            this.Element = elementType.Normal;
        }
    }
}