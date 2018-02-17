using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.WinCriteria
{
    public class Flush : IWinCriteria
    {
        public string WinName { get { return "Flush"; } set { } }

        public List<Hand> Compare(List<Hand> handsToCompare)
        {
            Logger.Log($"Entering criteria check for {nameof(Flush)}.");

            // first check to see if each one qualifies at all
            for (int i = 0; i < handsToCompare.Count; i++)
            {
                CheckIfQualifies(handsToCompare[i]);
            }

            // next check if any met criteria
            List<Hand> winningHands = handsToCompare.Where(x => x.Result == Ranker.CompareResult.Win).ToList();
            int numWinners = winningHands.Count();
            if (numWinners <= 0)       // if there are no winners, return null
            {
                Logger.Log($"Exiting criteria check for {nameof(Flush)} with no winner.");
                return null;
            }
            else if (numWinners == 1)  //  or if there's a single winner, return results
            {
                Logger.Log($"Exiting criteria check for {nameof(Flush)} with a winner (immediately).");
                return winningHands;
            }

            // try to break the tie with best winning cards
            List<Hand> winningTiedHands = DetermineHighestWinners(winningHands);
            if (winningTiedHands.Count == 1)
            {
                Logger.Log($"Exiting criteria check for {nameof(Flush)} with a winner (tie breaker with higher cards).");
                return winningTiedHands;
            }

            Logger.Log($"Exiting criteria check for {nameof(Flush)} with no winner.");
            return null;
        }

        // if it qualifies, this will re-arrange the cards in the hand in the order that
        // the cards should be compared in the case of a tie
        void CheckIfQualifies(Hand hand)
        {
            // if all suits match (or if it's wild)
            hand.Cards.Sort();
            if (hand.Cards.All(x => x.Suit == hand.Cards.First().Suit || x.Suit == Card.Suits.Wild))
            {
                hand.WinningCards = hand.Cards;
                hand.WinningCards.Sort();
                hand.Result = Ranker.CompareResult.Win;
            }
            return;
        }

        List<Hand> DetermineHighestWinners(List<Hand> hands)
        {
            // copy winning cards into remaining card hands, to break the tie as if they're the "remaining" cards
            hands.ForEach(x => { x.RemainingCards = x.WinningCards; });
            return WinCriteriaHelpers.FindHighestHandByRemainingCards(hands);
        }
    }
}
