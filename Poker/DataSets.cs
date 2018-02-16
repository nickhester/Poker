using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public static class DataSets
    {
        public static string Steve = "Steve";
        public static string John = "John";
        public static string Carry = "Carry";
        public static string Mary = "Mary";

        public static DataSet GetHands_TwoOfAKindTieRemainingCards()  // winner with 2 of a kind, and higher remaining cards (kickers)
        {
            DataSet dataSet = new DataSet();
            dataSet.Winner = John;
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()       
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                }),
                new Hand(Mary, new List<Card>()
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Club)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_TwoOfAKindTieWinningCards()  // winner with 2 of a kind, and higher winning cards
        {
            DataSet dataSet = new DataSet();
            dataSet.Winner = John;
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_TwoOfAKindWithJoker()  // winner with 2 of a kind, and higher winning cards
        {
            DataSet dataSet = new DataSet();
            dataSet.Winner = Carry;
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Joker, Card.Suits.Club)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_TwoOfAKind()  // winner with 2 of a kind
        {
            DataSet dataSet = new DataSet();
            dataSet.Winner = Mary;
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Queen, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                }),
                new Hand(Mary, new List<Card>()
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Club)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_ThreeOfAKind()  // winner with 3 of a kind
        {
            DataSet dataSet = new DataSet();
            dataSet.Winner = Steve;
            dataSet.Hands = new List<Hand>()
            {
                new Hand(Steve, new List<Card>()       
                {
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                }),
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_FourOfAKind()  // winner with 4 of a kind
        {
            DataSet dataSet = new DataSet();
            dataSet.Winner = Carry;
            dataSet.Hands = new List<Hand>()
            {
                new Hand(Steve, new List<Card>()
                {
                    new Card(Card.Numbers.Ten, Card.Suits.Club),
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                }),
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_FiveOfAKind()  // winner with 5 of a kind
        {
            DataSet dataSet = new DataSet();
            dataSet.Winner = Steve;
            dataSet.Hands = new List<Hand>()
            {
                new Hand(Steve, new List<Card>()
                {
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                }),
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                })
            };
            return dataSet;
        }
    }
}
