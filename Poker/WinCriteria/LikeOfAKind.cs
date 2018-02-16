using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.WinCriteria
{
    public class LikeOfAKind : IWinCriteria
    {
        int numberRequirement;
        public LikeOfAKind(int num)
        {
            numberRequirement = num;
        }

        public Hand Compare(List<Hand> handsToCompare)
        {
            Logger.Log($"Entering criteria check for {numberRequirement} of a kind with {handsToCompare.Count} hands.");

            // first check to see if each one qualifies at all
            for (int i = 0; i < handsToCompare.Count; i++)
            {
                CheckIfQualifies(handsToCompare[i]);
            }

            // next check if any won
            List<Hand> winningHands = handsToCompare.Where(x => x.Result == Ranker.CompareResult.Win).ToList();
            int numWinners = winningHands.Count();
            if (numWinners <= 0)       // if there are no winners, return null
            {
                Logger.Log($"Exiting criteria check for {numberRequirement} of a kind with no winner.");
                return null;
            }
            else if (numWinners == 1)  //  or if there's a single winner, return results
            {
                Logger.Log($"Exiting criteria check for {numberRequirement} of a kind with a winner (immediately).");
                return winningHands.Single();
            }

            // try to break the tie with best winning cards
            List<Hand> winningTiedHands = DetermineHighestWinners(winningHands);
            if (winningTiedHands.Count == 1)
            {
                Logger.Log($"Exiting criteria check for {numberRequirement} of a kind with a winner (tie breaker with higher match).");
                return winningTiedHands.Single();
            }

            // break the tie with remaining cards
            List<Hand> winningRemainingTiedHands = Hand.HighestRemainingCardValue(winningTiedHands);
            if (winningRemainingTiedHands.Count == 1)
            {
                Logger.Log($"Exiting criteria check for {numberRequirement} of a kind with a winner (tie breaker with higher kickers).");
                return winningRemainingTiedHands.Single();
            }

            Logger.Log($"Exiting criteria check for {numberRequirement} of a kind with no winner.");
            return null;
        }

        // if it qualifies, this will re-arrange the cards in the hand in the order that
        // the cards should be compared in the case of a tie
        void CheckIfQualifies(Hand hand)
        {
            foreach (var card in hand.Cards)
            {
                // if there's a match of the required number of cards
                List<Card> qualifyingCards = hand.Cards.Where(x => x == card).ToList();
                if (qualifyingCards.Count() >= numberRequirement)
                {
                    hand.Result = Ranker.CompareResult.Win;
                    // organize qualifying hand to check for tie later
                    hand.WinningCards = qualifyingCards;
                    hand.RemainingCards = hand.Cards.Where(x => x != card).ToList();
                    return;
                }
            }
            return;
        }

        List<Hand> DetermineHighestWinners(List<Hand> hands)
        {
            // get highest card
            Card highestCard = hands.Max(x => x.WinningCards[0]);
            // return any that match that highest value card
            return hands.Where(x => x.WinningCards[0] == highestCard).ToList();
        }
    }
}
