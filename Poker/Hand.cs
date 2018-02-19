using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class Hand
    {
        public readonly string Name;
        public readonly List<Card> Cards = new List<Card>();
        
        public Hand(string name, List<Card> cards)
        {
            Name = name;
            Cards = cards;
        }

        public Hand(string name, string cardNames)
        {
            Name = name;

            string[] cardNameLists = cardNames.Split(',');
            foreach (var cardName in cardNameLists)
            {
                if (!String.IsNullOrWhiteSpace(cardName))
                {
                    string trimmedCardName = cardName.Trim();
                    string[] cardNameSplit = trimmedCardName.Split(' ');

                    if (cardNameSplit.Count() != 2)
                    {
                        Console.WriteLine("INPUT ERROR: " + trimmedCardName + " is not a valid card");
                        return;
                    }

                    Cards.Add(new Card(cardNameSplit[0].Trim(), cardNameSplit[1].Trim()));
                }
            }
        }

        public override string ToString()
        {
            string cards = string.Join(", ", Cards.Select(x => x.ToString()));
            return Name + "'s hand: " + cards;
        }
    }
}
