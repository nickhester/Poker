using System.Collections.Generic;

namespace Poker.WinCriteria
{
    // The StraightFlush will determine any hands that meet the criteria that all cards are of the same suit,
    // and that all numbers can be ordered sequentially, and will return the hand(s) with the highest value
    public class StraightFlush : IWinCriteria
    {
        public string WinName { get { return Ranker.WinType.StraightFlush.ToString(); } set { } }

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
