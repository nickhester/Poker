using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.WinCriteria
{
    public class HighCard : IWinCriteria
    {
        public string WinName { get { return "HighCard"; } set { } }

        public List<Hand> Compare(List<Hand> handsToCompare)
        {
            Logger.Log($"Entering criteria check for {nameof(HighCard)}.");

            // put all cards into remaining cards list so they can be evaluated like a tie-breaker
            handsToCompare.ForEach(x => x.RemainingCards = x.Cards);
            handsToCompare = WinCriteriaHelpers.FindHighestHandByRemainingCards(handsToCompare);

            if (handsToCompare.Count > 0)
            {
                Logger.Log($"Exiting criteria check for {nameof(HighCard)} with winner(s).");
                return handsToCompare;
            }

            Logger.Log($"Exiting criteria check for {nameof(HighCard)} with no winner.");
            return null;
        }
    }
}
