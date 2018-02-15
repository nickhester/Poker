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
            
            Hand winningHand = ranker.DetermineWinner(DataSets.GetHands_1());

            if (winningHand == null)
            {
                Console.WriteLine($"Sorry, no winning hand could be determined.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Congratulations, {winningHand.Name} is the winner!");

            Console.ReadLine();
        }
    }
}
