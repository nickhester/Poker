using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.WinCriteria
{
    public interface IWinCriteria
    {
        List<Hand> Compare(List<Hand> handsToCompare);
        string WinName { get; set; }
    }
}
