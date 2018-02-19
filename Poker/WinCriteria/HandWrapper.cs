using System.Collections.Generic;

namespace Poker.WinCriteria
{
    // this class is used within a Win Criteria to reference the player's hand,
    // and copy the cards into working lists, while preserving the original
    public class HandWrapper
    {
        public readonly Hand Hand;
        public Ranker.CompareResult Result;
        public List<Card> WorkingCards;
        public List<Card> WinningCards;
        public List<Card> RemainingCards;

        public HandWrapper(Hand hand)
        {
            Hand = hand;
            WorkingCards = Hand.Cards;
        }
    }
}
