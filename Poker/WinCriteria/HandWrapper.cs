using System.Collections.Generic;

namespace Poker.WinCriteria
{
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
