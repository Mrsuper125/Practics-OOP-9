using System;
using System.Collections.Generic;
using System.Linq;

namespace Игры_с_картами
{
    public enum Cards
    {
        Шестёрка = 0,
        Семёрка,
        Восьмёрка,
        Девятка,
        Десятка,
        Валет,
        Королева,
        Король,
        Туз
    }

    class Deck
    {
        private List<Cards> deck;

        public Deck()
        {
            deck = new List<Cards>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = (int)Cards.Шестёрка; j <= (int)Cards.Туз; j++)
                {
                    deck.Add((Cards)j);
                }
            }
        }

        public Cards this[int position]
        {
            get
            {
                if (position >= deck.Count || position < 0) throw new ArgumentException("Card index must be non-negative and not exceed the index of the last card");
                return deck[position-1];
            }
        }

        // public void Pop(int position)
        // {
        //     deck.RemoveAt(position-1);
        // }

        public void Shuffle()
        {
            if (deck.Count == 0) throw new Exception("Can't shuffle an empty deck");
            List<Cards> auxillary = new List<Cards>();
            foreach (Cards item in deck)
            {
                auxillary.Add(item);
            }

            deck = new List<Cards>();
            int len = auxillary.Count;
            Random rn = new Random();
            for (int i = 0; i < len; i++)
            {
                int index = rn.Next(0, auxillary.Count);
                deck.Add(auxillary[index]);
                auxillary.RemoveAt(index);
            }
        }

        public void Give(Player player, int amount)
        {
            if (amount > deck.Count || amount < 1) throw new ArgumentException("Cards count mustn't exceed deck size or be less than 1");
            List<Cards> toGive;
            toGive = deck.GetRange(0, amount);
            player.Get(toGive);
            deck.RemoveRange(0, amount);
        }
    }

    public class Player
    {
        private List<Cards> deck;
        public List<Cards> openedDeck;
        public int number;

        public Player(int number)
        {
            deck = new List<Cards>();
            openedDeck = new List<Cards>();
            this.number = number;
        }

        public void Get(List<Cards> cards)
        {
            openedDeck = new List<Cards>();
            deck.AddRange(cards);
            //Console.WriteLine($"Игрок {number} получил {cards.Count} карт");
        }

        public void Open(int amount)
        {
            if (amount < 0) throw new ArgumentException("Can't open less than 1 cards");
            if (deck.Count < amount)
            {
                Console.WriteLine($"У игрока {number} недостаточно карт. Игра окончена. Победил игрок {3 - number}.");
                Environment.Exit(0);
            }
            else
            {
                openedDeck.AddRange(deck.GetRange(0, amount));
                deck.RemoveRange(0, amount);
            }
        }

        public static List<Cards> Compose(List<Cards> list1, List<Cards> list2)
        {
            if (list1.Count < 1 || list2.Count < 1) throw new ArgumentException("Can't compose empty decks");
            List<Cards> list1Copy = new List<Cards>(list1);
            List<Cards> list2Copy = new List<Cards>(list2);
            int minLength = Math.Min(list1Copy.Count, list2Copy.Count);
            list1Copy = list1Copy.GetRange(0, minLength);
            list2Copy = list2Copy.GetRange(0, minLength);
            List<Cards> res = new List<Cards>();
            res.Add(list1[0]);
            res.Add(list2[0]);
            list1Copy.RemoveAt(0);
            list2Copy.RemoveAt(0);
            while (list1Copy.Count != 0)
            {
                res.AddRange(list1Copy.GetRange(0, 2));
                list1Copy.RemoveRange(0, 2);
                res.AddRange(list2Copy.GetRange(0, 2));
                list2Copy.RemoveRange(0, 2);
            }
            return res;
        }
        
        /*public static List<Cards> Compose(List<Cards> list1, List<Cards> list2)
        {
            List<Cards> res = new List<Cards>();
            res.Add(list1[0]);
            res.Add(list2[0]);
            list1.RemoveAt(0);
            list2.RemoveAt(0);
            while (list1.Count != 0)
            {
                res.AddRange(list1.GetRange(0, 2));
                list1.RemoveRange(0, 2);
                res.AddRange(list2.GetRange(0, 2));
                list2.RemoveRange(0, 2);
            }
            return res;
        }*/
        
        public static void Compare(Player player1, Player player2)
        {
            player1.Open(1);
            Console.WriteLine("Первый игрок вскрывает карту, и это " + player1.openedDeck[0] + ".");
            player2.Open(1);
            Console.WriteLine("Второй игрок вскрывает карту, и это " + player2.openedDeck[0] + ".");
            if (player1.openedDeck.Last() > player2.openedDeck.Last())
            {
                player1.Get(Compose(player1.openedDeck, player2.openedDeck));
                Console.WriteLine("Первый игрок победил, и забирает обе карты.");
                player2.openedDeck = new List<Cards>();
            }
            else if (player1.openedDeck.Last() < player2.openedDeck.Last())
            {
                player2.Get(Compose(player1.openedDeck, player2.openedDeck));
                Console.WriteLine("Второй игрок победил, и забирает обе карты.");
                player1.openedDeck = new List<Cards>();
            }
            else
            {
                Console.WriteLine("Началась война.");
                while (player1.openedDeck.Last() == player2.openedDeck.Last())
                {
                    player1.Open(2);
                    Console.WriteLine("Первый игрок вскрывает карту, и это " + player1.openedDeck.Last() + ".");
                    player2.Open(2);
                    Console.WriteLine("Второй игрок вскрывает карту, и это " + player2.openedDeck.Last() + ".");
                }
                if (player1.openedDeck.Last() > player2.openedDeck.Last())
                { 
                    Console.WriteLine("Первый игрок победил, и забирает " + (player1.openedDeck.Count*2) +" карт.");
                    player1.Get(Compose(player1.openedDeck, player2.openedDeck));
                    player2.openedDeck = new List<Cards>();
                }
                else if (player1.openedDeck.Last() < player2.openedDeck.Last())
                {
                    Console.WriteLine("Второй игрок победил, и забирает " + (player1.openedDeck.Count*2) +" карт.");
                    player2.Get(Compose(player1.openedDeck, player2.openedDeck));
                    player1.openedDeck = new List<Cards>();
                }
            }
            //Console.WriteLine(player1.deck.Count + player2.deck.Count);
            //Console.WriteLine(player1.openedDeck.Count + player2.openedDeck.Count);
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.Shuffle();
            Player player1 = new Player(1);
            Player player2 = new Player(2);
            
            deck.Give(player1, 18);
            deck.Give(player2, 18);

            while (true)
            {
                Player.Compare(player1, player2);
            }
        }
    }
    
    // internal class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         List list = new List(3);
    //         for (int i = 0; i < list.Length; i++)
    //         {
    //             Console.WriteLine(list[i]);
    //         }
    //         Console.WriteLine(list.Length);
    //         list[1] = 1;
    //         list[2] = 2;
    //         list.Pop(1);
    //         for (int i = 0; i < list.Length; i++)
    //         {
    //             Console.WriteLine(list[i]);
    //         }
    //     }
    // }
}