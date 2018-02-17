using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.WinCriteria
{
    public interface IWinCriteria
    {
        List<Hand> Compare(List<Hand> handsToCompare);
        string WinName { get; set; }
    }
}
