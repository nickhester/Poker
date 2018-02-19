using System.Collections.Generic;

namespace Poker.WinCriteria
{
    // interface to determine which of a list of hands pass a certain criteria
    public interface IWinCriteria
    {
        List<Hand> Compare(List<Hand> handsToCompare);
        string WinName { get; set; }
    }
}
