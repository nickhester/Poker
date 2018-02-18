using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.WinCriteria
{
    public class Flush : IWinCriteria
    {
        public string WinName { get { return Ranker.WinType.Flush.ToString(); } set { } }

        public List<Hand> Compare(List<Hand> handsToCompare)
        {
            Logger.Log($"Entering criteria check for {nameof(Flush)}.");

            // create the hand wrappers from the given hands
            List<HandWrapper> handWrappers = new List<HandWrapper>();
            handsToCompare.ForEach(x => handWrappers.Add(new HandWrapper(x)));

            // first check to see if each one qualifies at all
            for (int i = 0; i < handWrappers.Count; i++)
            {
                handWrappers[i].Result = Ranker.CompareResult.None;
                CheckIfQualifies(handWrappers[i]);
            }

            // next check if any met criteria
            List<HandWrapper> winningHandWrappers = handWrappers.Where(x => x.Result == Ranker.CompareResult.Win).ToList();
            int numWinners = winningHandWrappers.Count();
            if (numWinners <= 0)       // if there are no winners, return null
            {
                Logger.Log($"Exiting criteria check for {nameof(Flush)} with no winner.");
                return null;
            }
            else if (numWinners == 1)  //  or if there's a single winner, return results
            {
                Logger.Log($"Exiting criteria check for {nameof(Flush)} with a winner (immediately).");
                return winningHandWrappers.Select(x => x.Hand).ToList();
            }

            // try to break the tie with best winning cards
            List<HandWrapper> winningTiedHands = DetermineHighestWinners(winningHandWrappers);
            if (winningTiedHands.Count > 0)
            {
                Logger.Log($"Exiting criteria check for {nameof(Flush)} with a winner (tie breaker with higher cards).");
                return winningTiedHands.Select(x => x.Hand).ToList();
            }

            Logger.Log($"Exiting criteria check for {nameof(Flush)} with no winner.");
            return null;
        }

        // if it qualifies, this will re-arrange the cards in the hand in the order that
        // the cards should be compared in the case of a tie
        void CheckIfQualifies(HandWrapper handWrapper)
        {
            // if all suits match (or if it's wild)
            handWrapper.WorkingCards.Sort();
            if (handWrapper.WorkingCards.All(x => x.Suit == handWrapper.WorkingCards.First().Suit || x.Suit == Card.Suits.Wild))
            {
                handWrapper.WinningCards = handWrapper.WorkingCards;
                handWrapper.WinningCards.Sort();
                handWrapper.Result = Ranker.CompareResult.Win;
            }
            return;
        }

        List<HandWrapper> DetermineHighestWinners(List<HandWrapper> handWrappers)
        {
            // copy winning cards into remaining card hands, to break the tie as if they're the "remaining" cards
            handWrappers.ForEach(x => { x.RemainingCards = x.WinningCards; });
            return WinCriteriaHelpers.FindHighestHandByRemainingCards(handWrappers);
        }
    }
}
