using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            Ranker ranker = new Ranker();

            // run test data sets
            bool runTests = true;
            Logger.LogDebug = false;

            if (runTests)
            {
                RunTests(ranker);
            }

            Hand winningHand = ranker.DetermineWinner(DataSets.GetHands_TwoOfAKindTieRemainingCards().Hands);

            if (winningHand == null)
            {
                Console.WriteLine($"Sorry, no winning hand could be determined.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Congratulations, {winningHand.Name} is the winner!");

            Console.ReadLine();
        }

        static void RunTests(Ranker ranker)
        {
            List<DataSet> dataSets = new List<DataSet>()
            {
                DataSets.GetHands_TwoOfAKind(),
                DataSets.GetHands_TwoOfAKindTieWinningCards(),
                DataSets.GetHands_TwoOfAKindTieRemainingCards(),
                DataSets.GetHands_TwoOfAKindWithJoker(),
                DataSets.GetHands_ThreeOfAKind(),
                DataSets.GetHands_FourOfAKind(),
                DataSets.GetHands_FiveOfAKind()
            };

            for (int i = 0; i < dataSets.Count; i++)
            {
                Hand testWinningHand = ranker.DetermineWinner(dataSets[i].Hands);
                if (testWinningHand.Name == dataSets[i].Winner)
                    Console.WriteLine($"Test Run {i}: SUCCESS");
                else
                    Console.WriteLine($"Test Run {i}: FAIL");
            }
        }
    }
}
