using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.WinCriteria
{
    // The HighCard will determine which given hand has the highest cards, when sorted and considered one by one
    public class HighCard : IWinCriteria
    {
        public string WinName { get { return Ranker.WinType.HighCard.ToString(); } set { } }

        public List<Hand> Compare(List<Hand> handsToCompare)
        {
            Logger.Log($"Entering criteria check for {nameof(HighCard)}.");

            // create the hand wrappers from the given hands
            List<HandWrapper> handWrappers = new List<HandWrapper>();
            handsToCompare.ForEach(x => handWrappers.Add(new HandWrapper(x)));

            // put all cards into remaining cards list so they can be evaluated like a tie-breaker
            handWrappers.ForEach(x => x.RemainingCards = x.WorkingCards);
            handWrappers = WinCriteriaHelpers.FindHighestHandByRemainingCards(handWrappers);

            if (handWrappers.Count > 0)
            {
                Logger.Log($"Exiting criteria check for {nameof(HighCard)} with winner(s).");
                return handWrappers.Select(x => x.Hand).ToList();
            }

            Logger.Log($"Exiting criteria check for {nameof(HighCard)} with no winner.");
            return null;
        }
    }
}
