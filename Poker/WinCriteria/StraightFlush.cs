using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.WinCriteria
{
    public class StraightFlush : IWinCriteria
    {
        public string WinName { get { return "StraightFlush"; } set { } }

        public List<Hand> Compare(List<Hand> handsToCompare)
        {
            Logger.Log($"Entering criteria check for {nameof(StraightFlush)}.");

            Straight straight = new Straight();
            handsToCompare = straight.Compare(handsToCompare);

            if (handsToCompare != null)
            {
                Flush flush = new Flush();
                handsToCompare = flush.Compare(handsToCompare);

                if (handsToCompare != null && handsToCompare.Count > 0)
                {
                    Logger.Log($"Exiting criteria check for {nameof(StraightFlush)} with winner(s).");
                    return handsToCompare;
                }
            }
            
            Logger.Log($"Exiting criteria check for {nameof(StraightFlush)} with no winner.");
            return null;
        }
    }
}
