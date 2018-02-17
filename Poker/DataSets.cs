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
            dataSet.Winners = John;
            dataSet.IntendedWin = "TwoOfAKind";
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()       
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Heart),
                    new Card(Card.Numbers.Three, Card.Suits.Spade),
                    new Card(Card.Numbers.Four, Card.Suits.Diamond),
                    new Card(Card.Numbers.Five, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Seven, Card.Suits.Heart),
                    new Card(Card.Numbers.Jack, Card.Suits.Heart),
                    new Card(Card.Numbers.Eight, Card.Suits.Heart),
                    new Card(Card.Numbers.Two, Card.Suits.Heart)
                }),
                new Hand(Mary, new List<Card>()
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Spade),
                    new Card(Card.Numbers.Four, Card.Suits.Spade),
                    new Card(Card.Numbers.Two, Card.Suits.Spade),
                    new Card(Card.Numbers.Five, Card.Suits.Spade)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_TwoOfAKindTieWinningCards()  // winner with 2 of a kind, and higher winning cards
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = John;
            dataSet.IntendedWin = "TwoOfAKind";
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Diamond),
                    new Card(Card.Numbers.Three, Card.Suits.Diamond),
                    new Card(Card.Numbers.Four, Card.Suits.Diamond),
                    new Card(Card.Numbers.Five, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Seven, Card.Suits.Heart),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_TwoOfAKindWithJoker()  // winner with 2 of a kind, using a joker
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Carry;
            dataSet.IntendedWin = "TwoOfAKind";
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Heart),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Diamond),
                    new Card(Card.Numbers.Jack, Card.Suits.Diamond),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Joker, Card.Suits.Wild)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_TwoOfAKindWithTie()  // winner with 2 of a kind with a complete tie
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = John + "," + Mary;
            dataSet.IntendedWin = "TwoOfAKind";
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Spade)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Queen, Card.Suits.Spade),
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
                    new Card(Card.Numbers.Five, Card.Suits.Spade)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_TwoOfAKind()  // winner with 2 of a kind
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Mary;
            dataSet.IntendedWin = "TwoOfAKind";
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Spade),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Queen, Card.Suits.Spade),
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
                    new Card(Card.Numbers.Five, Card.Suits.Spade)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_ThreeOfAKind()  // winner with 3 of a kind
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Steve;
            dataSet.IntendedWin = "ThreeOfAKind";
            dataSet.Hands = new List<Hand>()
            {
                new Hand(Steve, new List<Card>()       
                {
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Ace, Card.Suits.Heart),
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club)
                }),
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Heart),
                    new Card(Card.Numbers.Five, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Heart),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_FourOfAKind()  // winner with 4 of a kind
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Carry;
            dataSet.IntendedWin = "FourOfAKind";
            dataSet.Hands = new List<Hand>()
            {
                new Hand(Steve, new List<Card>()
                {
                    new Card(Card.Numbers.Ten, Card.Suits.Club),
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Ace, Card.Suits.Diamond),
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                }),
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Diamond),
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
                    new Card(Card.Numbers.Jack, Card.Suits.Diamond)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_FiveOfAKind()  // winner with 5 of a kind
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Steve;
            dataSet.IntendedWin = "FiveOfAKind";
            dataSet.Hands = new List<Hand>()
            {
                new Hand(Steve, new List<Card>()
                {
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Heart),
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                }),
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Heart)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Heart),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_FiveOfAKindWithAllJokers()  // winner with full house (3 pair and 2 pair), with a joker
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = John;
            dataSet.IntendedWin = "FiveOfAKind";
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Joker, Card.Suits.Wild),
                    new Card(Card.Numbers.Joker, Card.Suits.Wild),
                    new Card(Card.Numbers.Joker, Card.Suits.Wild),
                    new Card(Card.Numbers.Joker, Card.Suits.Wild),
                    new Card(Card.Numbers.Joker, Card.Suits.Wild)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Diamond),
                    new Card(Card.Numbers.Joker, Card.Suits.Wild),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                })
            };
            return dataSet;
        }
        
        public static DataSet GetHands_FullHouse()  // winner with full house (3 pair and 2 pair)
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Steve;
            dataSet.IntendedWin = "FullHouse";
            dataSet.Hands = new List<Hand>()
            {
                new Hand(Steve, new List<Card>()
                {
                    new Card(Card.Numbers.Two, Card.Suits.Diamond),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                }),
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Diamond),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Diamond),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_FullHouseTieBreaker()  // winner with full house (3 pair and 2 pair), and higher winning cards
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Carry;
            dataSet.IntendedWin = "FullHouse";
            dataSet.Hands = new List<Hand>()
            {
                new Hand(Steve, new List<Card>()
                {
                    new Card(Card.Numbers.Two, Card.Suits.Diamond),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                }),
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Diamond),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Diamond),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_FullHouseWithAJoker()  // winner with full house (3 pair and 2 pair), with a joker
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Carry;
            dataSet.IntendedWin = "FullHouse";
            dataSet.Hands = new List<Hand>()
            {
                new Hand(Steve, new List<Card>()
                {
                    new Card(Card.Numbers.Two, Card.Suits.Diamond),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                }),
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Diamond),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Diamond),
                    new Card(Card.Numbers.Joker, Card.Suits.Wild),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                })
            };
            return dataSet;
        }
        public static DataSet GetHands_TwoPair()  // winner with 2 pairs
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = John;
            dataSet.IntendedWin = "TwoPair";
            dataSet.Hands = new List<Hand>()
            {
                new Hand(Steve, new List<Card>()
                {
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Diamond),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Club)
                }),
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Queen, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Diamond),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Diamond)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_Flush()  // winner with flush
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Steve;
            dataSet.IntendedWin = "Flush";
            dataSet.Hands = new List<Hand>()
            {
                new Hand(Steve, new List<Card>()
                {
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Club),
                    new Card(Card.Numbers.Seven, Card.Suits.Club)
                }),
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Queen, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Diamond),
                    new Card(Card.Numbers.Two, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Diamond)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_FlushWithTieBreaker()  // winner with flush and a tie breaker
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = John;
            dataSet.IntendedWin = "Flush";
            dataSet.Hands = new List<Hand>()
            {
                new Hand(Steve, new List<Card>()
                {
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Club),
                    new Card(Card.Numbers.Seven, Card.Suits.Club)
                }),
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Queen, Card.Suits.Diamond),
                    new Card(Card.Numbers.Three, Card.Suits.Diamond),
                    new Card(Card.Numbers.Two, Card.Suits.Diamond),
                    new Card(Card.Numbers.Three, Card.Suits.Diamond),
                    new Card(Card.Numbers.Two, Card.Suits.Diamond)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Diamond)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_FlushWithAJoker()  // winner with flush with a joker as the tie breaker
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = John;
            dataSet.IntendedWin = "Flush";
            dataSet.Hands = new List<Hand>()
            {
                new Hand(Steve, new List<Card>()
                {
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Heart),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Club),
                    new Card(Card.Numbers.Six, Card.Suits.Club)
                }),
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Joker, Card.Suits.Wild),
                    new Card(Card.Numbers.Queen, Card.Suits.Diamond),
                    new Card(Card.Numbers.Two, Card.Suits.Diamond),
                    new Card(Card.Numbers.Three, Card.Suits.Diamond),
                    new Card(Card.Numbers.Ten, Card.Suits.Diamond)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Diamond)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_Straight()  // winner with straight
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Carry;
            dataSet.IntendedWin = "Straight";
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Queen, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Diamond),
                    new Card(Card.Numbers.Ten, Card.Suits.Club)
                }),
                new Hand(Steve, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Queen, Card.Suits.Club),
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Diamond)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Diamond),
                    new Card(Card.Numbers.Five, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Six, Card.Suits.Club)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_StraightWithAJoker()  // winner with straight using a joker
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Carry;
            dataSet.IntendedWin = "Straight";
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Queen, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Diamond),
                    new Card(Card.Numbers.Ten, Card.Suits.Club)
                }),
                new Hand(Steve, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Queen, Card.Suits.Club),
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Diamond)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Joker, Card.Suits.Wild),
                    new Card(Card.Numbers.Three, Card.Suits.Diamond),
                    new Card(Card.Numbers.Five, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Joker, Card.Suits.Wild)
                })
            };
            return dataSet;
        }

        public static DataSet GetHands_StraightWithTieBreaker()  // winner with straight and a tie breaker
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Steve;
            dataSet.IntendedWin = "Straight";
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Queen, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Diamond),
                    new Card(Card.Numbers.Ten, Card.Suits.Club)
                }),
                new Hand(Steve, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Nine, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Ten, Card.Suits.Diamond)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Diamond),
                    new Card(Card.Numbers.Five, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Six, Card.Suits.Club)
                })
            };
            return dataSet;
        }

        // todo: add pure tie
    }
}
