using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public static class DataSets
    {
        public static string Steve = "Steve";
        public static string John = "John";
        public static string Carry = "Carry";

        public static DataSet GetHands_OnePair()  // winner with one pair
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Steve;
            dataSet.IntendedWin = Ranker.WinType.OnePair.ToString();
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
                new Hand(Steve, new List<Card>()
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
        public static DataSet GetHands_OnePairTieWinningCards()  // winner with one pair, and higher winning cards
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = John;
            dataSet.IntendedWin = Ranker.WinType.OnePair.ToString();
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
        public static DataSet GetHands_OnePairTieRemainingCards()  // winner with one pair, and higher remaining cards (kickers)
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = John;
            dataSet.IntendedWin = Ranker.WinType.OnePair.ToString();
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
                new Hand(Steve, new List<Card>()
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
        public static DataSet GetHands_OnePairWithJoker()  // winner with one pair, using a joker
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Carry;
            dataSet.IntendedWin = Ranker.WinType.OnePair.ToString();
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
        public static DataSet GetHands_OnePairWithTie()  // winner with one pair with a complete tie
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = John + "," + Steve;
            dataSet.IntendedWin = Ranker.WinType.OnePair.ToString();
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
                new Hand(Steve, new List<Card>()
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
            dataSet.IntendedWin = Ranker.WinType.ThreeOfAKind.ToString();
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
            dataSet.IntendedWin = Ranker.WinType.FourOfAKind.ToString();
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
            dataSet.IntendedWin = Ranker.WinType.FiveOfAKind.ToString();
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
            dataSet.IntendedWin = Ranker.WinType.FiveOfAKind.ToString();
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
            dataSet.IntendedWin = Ranker.WinType.FullHouse.ToString();
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
            dataSet.IntendedWin = Ranker.WinType.FullHouse.ToString();
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
            dataSet.IntendedWin = Ranker.WinType.FullHouse.ToString();
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
            dataSet.IntendedWin = Ranker.WinType.TwoPair.ToString();
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
            dataSet.IntendedWin = Ranker.WinType.Flush.ToString();
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
            dataSet.IntendedWin = Ranker.WinType.Flush.ToString();
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
            dataSet.IntendedWin = Ranker.WinType.Flush.ToString();
            dataSet.Hands = new List<Hand>()
            {
                new Hand(Steve, new List<Card>()
                {
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Heart),
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
        public static DataSet GetHands_FlushWithTie()  // winner with flush and a tie
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Steve + "," + John;
            dataSet.IntendedWin = Ranker.WinType.Flush.ToString();
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
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Club),
                    new Card(Card.Numbers.Seven, Card.Suits.Club)
                })
            };
            return dataSet;
        }
        public static DataSet GetHands_Straight()  // winner with straight
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Carry;
            dataSet.IntendedWin = Ranker.WinType.Straight.ToString();
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
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Nine, Card.Suits.Club),
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
        public static DataSet GetHands_StraightWithAJoker()  // winner with straight using a joker
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Carry;
            dataSet.IntendedWin = Ranker.WinType.Straight.ToString();
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
            dataSet.IntendedWin = Ranker.WinType.Straight.ToString();
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
        public static DataSet GetHands_StraightWithTie()  // winner with straight and a tie
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = John + "," + Steve;
            dataSet.IntendedWin = Ranker.WinType.Straight.ToString();
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Nine, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Ten, Card.Suits.Diamond)
                }),
                new Hand(Steve, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Nine, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Ten, Card.Suits.Diamond)
                })
            };
            return dataSet;
        }
        public static DataSet GetHands_StraightFlush()  // winner with straight flush
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = John;
            dataSet.IntendedWin = Ranker.WinType.StraightFlush.ToString();
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Diamond),
                    new Card(Card.Numbers.Eight, Card.Suits.Diamond),
                    new Card(Card.Numbers.Nine, Card.Suits.Diamond),
                    new Card(Card.Numbers.Jack, Card.Suits.Diamond),
                    new Card(Card.Numbers.Ten, Card.Suits.Diamond)
                }),
                new Hand(Steve, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Nine, Card.Suits.Heart),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Ten, Card.Suits.Diamond)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Two, Card.Suits.Heart),
                    new Card(Card.Numbers.Eight, Card.Suits.Heart),
                    new Card(Card.Numbers.Nine, Card.Suits.Heart),
                    new Card(Card.Numbers.Jack, Card.Suits.Heart),
                    new Card(Card.Numbers.Queen, Card.Suits.Heart)
                })
            };
            return dataSet;
        }
        public static DataSet GetHands_StraightFlushWithTieBreaker()  // winner with straight flush and a tie breaker
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Steve;
            dataSet.IntendedWin = Ranker.WinType.StraightFlush.ToString();
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Seven, Card.Suits.Diamond),
                    new Card(Card.Numbers.Eight, Card.Suits.Diamond),
                    new Card(Card.Numbers.Nine, Card.Suits.Diamond),
                    new Card(Card.Numbers.Jack, Card.Suits.Diamond),
                    new Card(Card.Numbers.Ten, Card.Suits.Diamond)
                }),
                new Hand(Steve, new List<Card>()
                {
                    new Card(Card.Numbers.Ten, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Nine, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Queen, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Two, Card.Suits.Heart),
                    new Card(Card.Numbers.Eight, Card.Suits.Heart),
                    new Card(Card.Numbers.Nine, Card.Suits.Heart),
                    new Card(Card.Numbers.Jack, Card.Suits.Heart),
                    new Card(Card.Numbers.Queen, Card.Suits.Heart)
                })
            };
            return dataSet;
        }
        public static DataSet GetHands_StraightFlushWithTie()  // winner with straight flush and a tie
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = John + "," + Steve;
            dataSet.IntendedWin = Ranker.WinType.StraightFlush.ToString();
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Ten, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Nine, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Queen, Card.Suits.Club)
                }),
                new Hand(Steve, new List<Card>()
                {
                    new Card(Card.Numbers.Ten, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Nine, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Club),
                    new Card(Card.Numbers.Queen, Card.Suits.Club)
                })
            };
            return dataSet;
        }
        public static DataSet GetHands_HighCard()  // winner with high card
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = John;
            dataSet.IntendedWin = Ranker.WinType.HighCard.ToString();
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Diamond),
                    new Card(Card.Numbers.Three, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Heart),
                    new Card(Card.Numbers.Queen, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Five, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Diamond),
                    new Card(Card.Numbers.Nine, Card.Suits.Spade),
                    new Card(Card.Numbers.Jack, Card.Suits.Spade),
                    new Card(Card.Numbers.Queen, Card.Suits.Club)
                })
            };
            return dataSet;
        }
        public static DataSet GetHands_HighCardTieBreaker()  // winner with high card and tie breaker
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Carry;
            dataSet.IntendedWin = Ranker.WinType.HighCard.ToString();
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Diamond),
                    new Card(Card.Numbers.Nine, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Heart),
                    new Card(Card.Numbers.Queen, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Diamond),
                    new Card(Card.Numbers.Nine, Card.Suits.Spade),
                    new Card(Card.Numbers.Jack, Card.Suits.Spade),
                    new Card(Card.Numbers.Queen, Card.Suits.Club)
                })
            };
            return dataSet;
        }
        public static DataSet GetHands_HighCardTie()  // winner with high card and tie
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = John + "," + Carry;
            dataSet.IntendedWin = Ranker.WinType.HighCard.ToString();
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Diamond),
                    new Card(Card.Numbers.Nine, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Heart),
                    new Card(Card.Numbers.Queen, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Diamond),
                    new Card(Card.Numbers.Nine, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Heart),
                    new Card(Card.Numbers.Queen, Card.Suits.Club)
                })
            };
            return dataSet;
        }
        public static DataSet GetHands_OneHand()  // game with one hand
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = John;
            dataSet.IntendedWin = Ranker.WinType.HighCard.ToString();
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Diamond),
                    new Card(Card.Numbers.Nine, Card.Suits.Club),
                    new Card(Card.Numbers.Jack, Card.Suits.Heart),
                    new Card(Card.Numbers.Queen, Card.Suits.Club)
                })
            };
            return dataSet;
        }
        public static DataSet GetHands_TwoCards()  // hands have only two cards
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Carry;
            dataSet.IntendedWin = Ranker.WinType.HighCard.ToString();
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Two, Card.Suits.Diamond)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Ace, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Diamond)
                })
            };
            return dataSet;
        }
        public static DataSet GetHands_OneCard()  // hands have only one card
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Carry;
            dataSet.IntendedWin = Ranker.WinType.StraightFlush.ToString();
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Two, Card.Suits.Diamond)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Five, Card.Suits.Diamond)
                })
            };
            return dataSet;
        }
        public static DataSet GetHands_TenCards()  // hands have ten cards
        {
            DataSet dataSet = new DataSet();
            dataSet.Winners = Carry;
            dataSet.IntendedWin = Ranker.WinType.HighCard.ToString();
            dataSet.Hands = new List<Hand>()
            {
                new Hand(John, new List<Card>()
                {
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Diamond),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Heart),
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Nine, Card.Suits.Diamond),
                    new Card(Card.Numbers.Ten, Card.Suits.Club),
                    new Card(Card.Numbers.Queen, Card.Suits.Heart),
                    new Card(Card.Numbers.King, Card.Suits.Club)
                }),
                new Hand(Carry, new List<Card>()
                {
                    new Card(Card.Numbers.Two, Card.Suits.Club),
                    new Card(Card.Numbers.Three, Card.Suits.Diamond),
                    new Card(Card.Numbers.Four, Card.Suits.Club),
                    new Card(Card.Numbers.Five, Card.Suits.Heart),
                    new Card(Card.Numbers.Seven, Card.Suits.Club),
                    new Card(Card.Numbers.Eight, Card.Suits.Club),
                    new Card(Card.Numbers.Nine, Card.Suits.Diamond),
                    new Card(Card.Numbers.Ten, Card.Suits.Club),
                    new Card(Card.Numbers.Queen, Card.Suits.Heart),
                    new Card(Card.Numbers.Ace, Card.Suits.Club)
                })
            };
            return dataSet;
        }
    }
}
