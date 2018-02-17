using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.WinCriteria
{
    public static class WinCriteriaHelpers
    {
        public static List<Hand> FindHighestHandByRemainingCards(List<Hand> hands)
        {
            // sort remaining cards
            hands.ForEach(x => x.RemainingCards.Sort());

            // compare highest (last in the list), then next highest, etc. (assumes same number in each list)
            // go through once for each number of cards...
            for (int i = hands[0].RemainingCards.Count - 1; i >= 0; i--)
            {
                // make a list of the currently considered round of cards
                List<Card> cardsToCompare = new List<Card>();
                for (int j = 0; j < hands.Count; j++)
                {
                    cardsToCompare.Add(hands[j].RemainingCards[i]);
                }

                // find which ones aren't equal to the value of the highest card
                Card highestCard = cardsToCompare.Max();
                for (int j = 0; j < hands.Count; j++)
                {
                    // and remove them from the hand list
                    if (hands[j].RemainingCards[i] != highestCard)
                    {
                        hands.RemoveAt(j);
                        j--;
                    }
                }

                if (hands.Count == 1)
                    return hands;
            }
            
            return hands;
        }
    }
}
