using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public static class DataSets
    {
        public static List<Hand> GetHands_1()
        {
            return new List<Hand>()
            {
                new Hand("Steve", new List<Card>()
                {
                    new Card(Card.Numbers.Six, Card.Suits.Club),
                    new Card(Card.Numbers.Six, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Club)
                }),
                new Hand("John", new List<Card>()       // john should win with a pair, and higher remaining cards
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Club)
                }),
                new Hand("Carry", new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                }),
                new Hand("Mary", new List<Card>()
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Club)
                })
            };
        }
    }
}
